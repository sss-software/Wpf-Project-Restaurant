using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bornander.Wpf.Meshes;
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;
using System.ComponentModel;

namespace Bornander.UI.TabCarousel
{
    public partial class Carousel : UserControl, INotifyPropertyChanged
    {
        private class SpinInstruction
        {
            public int From { get; private set; }
            public int To { get; private set; }

            public SpinInstruction(int from, int to)
            {
                From = from;
                To = to;
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private IList<Tab> tabs = new List<Tab>();
        private IList<FrameworkElement> elements = new List<FrameworkElement>();

        private Queue<SpinInstruction> instructions = new Queue<SpinInstruction>();

        private int currentIndex = 0;
        private int currentTabIndex = 0;

        private int animationDuration = 1000;
        private bool isAnimating = false;
        private bool alwaysOnlyOneStep = false;
        private bool wrapAtEnd = false;
        private double depth;

        
        public Carousel()
        {
            InitializeComponent();

            NumberOfTabs = 3;
            Depth = 0.1;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Organize(int numberOfTabs)
        {
            CarouselContainer.Children.Clear();

            foreach (Tab tab in tabs)
                tab.Element = null;

            IList<Tab> newTabs = new List<Tab>();
            for (int i = 0; i < numberOfTabs; ++i)
            {
                FrameworkElement element = i < elements.Count ? elements[i] : new Label { Content = i, Background = Brushes.CadetBlue };
                Tab tab = new Tab(element, Color, Depth);
                newTabs.Add(tab);

                CarouselContainer.Children.Add(tab.Model);
            }

            tabs = newTabs;
            currentIndex = 0;
            currentTabIndex = 0;
            CarouselContainer.Transform = new Transform3DGroup();

            RecalculateTransforms();
        }

        private static double DegreesToRadians(double degrees)
        {
            return (degrees / 180.0) * Math.PI;
        }

        private double CalculateRadius()
        {
            double splitAngle = 360.0 / tabs.Count;
            switch (tabs.Count)
            {
                case 1: return 0.0;
                case 2: return 0.25;
                default:
                    return 1.0 / Math.Abs(Math.Sin(DegreesToRadians(splitAngle)));
            }
        }

        private int GetSafeIndex(int unsafeIndex)
        {
            return unsafeIndex >= 0 ? unsafeIndex % tabs.Count : tabs.Count - (Math.Abs(unsafeIndex) % tabs.Count);
        }

        private double CalculateCameraDistance(int index, int tabIndex)
        {
            Tab tab = tabs[tabIndex];

            double y = 0.5 / Math.Tan(DegreesToRadians(MainCamera.FieldOfView / 2.0));

            double panelWidth = tab.Element != null ? tab.Element.Width : 1.0;
            double ratio = Grid3D.ActualWidth / panelWidth;

            return CalculateRadius() + Math.Max(ratio, 1.0) * y;
        }

        private void RecalculateTransforms()
        {
            if (tabs.Count == 0)
                return;

            double angle = 360.0 / tabs.Count;
            double radius = CalculateRadius();
            for (int i = 0; i < tabs.Count; ++i)
            {
                tabs[i].UpdateTransform(i, angle, radius);
            }

            MainCamera.Transform = new TranslateTransform3D(0, 0, CalculateCameraDistance(currentIndex, currentTabIndex));
        }

        private void Animate()
        {
            if (instructions.Count == 0 || isAnimating)
                return;

            SpinInstruction instruction = instructions.Peek();

            bool wrapIt = false;

            if (instruction.To < 0 || instruction.To >= elements.Count)
            {
                if (WrapAtEnd && (instruction.To == -1 || instruction.To == elements.Count))
                {
                    wrapIt = true;
                    instruction = new SpinInstruction(instruction.From, instruction.To < 0 ? elements.Count - 1 : 0);
                }
                else
                {
                    instructions.Dequeue();
                    isAnimating = false;
                    return;
                }
            }
            double angle = 360.0 / tabs.Count;

            int tabToIndex = AlwaysOnlyOneStep ? GetSafeIndex(currentTabIndex + Math.Sign(instruction.To - instruction.From)) : GetSafeIndex(instruction.To);
            if (wrapIt)
            {
                if (instruction.To == 0)
                    tabToIndex = 0;
                if (instruction.To == elements.Count - 1)
                    tabToIndex = tabs.Count - 1;
            }

            // Unhook if required
            foreach (Tab owner in (from tab in tabs where tab.Element == elements[instruction.To] || tab.Element == elements[instruction.From] select tab))
                owner.Element = null;


            tabs[currentTabIndex].Element = elements[instruction.From];
            tabs[currentTabIndex].UpdateTransform(currentTabIndex, angle, CalculateRadius());


            tabs[tabToIndex].Element = elements[instruction.To];
            tabs[tabToIndex].UpdateTransform(tabToIndex, angle, CalculateRadius());
            isAnimating = true;

            double fromAngle = currentTabIndex * angle;
            double toAngle = tabToIndex * angle;

            if (wrapIt)
            {
                if (instruction.To == 0)
                    toAngle += 360;
                if (instruction.To == elements.Count - 1)
                    toAngle -= 360;
            }

            if (instruction.To - instruction.From > 0 && tabToIndex < currentTabIndex)
                toAngle += 360;

            if (instruction.To - instruction.From < 0 && tabToIndex > currentTabIndex)
                toAngle -= 360;

            CreateSpinAnimation(instruction, tabToIndex, fromAngle, toAngle);
        }

        private void CreateSpinAnimation(SpinInstruction instruction, int tabToIndex, double fromAngle, double toAngle)
        {
            RotateTransform3D flipTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), 0));
            DoubleAnimation flipAnimation = new DoubleAnimation(0, 360, new Duration(new TimeSpan(0, 0, 0, 0, animationDuration)));

            RotateTransform3D spinTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0));
            DoubleAnimation spinAnimation = new DoubleAnimation(fromAngle, toAngle, new Duration(new TimeSpan(0, 0, 0, 0, animationDuration)));
            spinAnimation.Completed += (sender, e) =>
            {
                instructions.Dequeue();
                currentIndex = instruction.To;
                currentTabIndex = tabToIndex;

                isAnimating = false;
                Animate();
            };

            spinTransform.Rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, spinAnimation);

            if (EnableFlip)
                flipTransform.Rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, flipAnimation);

            Transform3DGroup carouselTransform = new Transform3DGroup();

            carouselTransform.Children.Add(spinTransform);
            if (EnableFlip)
                carouselTransform.Children.Add(flipTransform);

            CarouselContainer.Transform = carouselTransform;

            double currentDistance = CalculateCameraDistance(instruction.From, currentTabIndex);
            double nextDistance = CalculateCameraDistance(instruction.To, tabToIndex);
            System.Diagnostics.Debug.WriteLine(nextDistance);
            DoubleAnimation cameraAnimation = new DoubleAnimation(currentDistance, nextDistance, new Duration(new TimeSpan(0, 0, 0, 0, animationDuration)));
            Transform3D cameraTransform = new TranslateTransform3D(0, 0, currentDistance);
            MainCamera.Transform = cameraTransform;

            cameraTransform.BeginAnimation(TranslateTransform3D.OffsetZProperty, cameraAnimation);
        }


        #region Public properties

        public bool EnableFlip { get; set; }

        public Color Color { get; set; }

        public bool AlwaysOnlyOneStep
        {
            get { return alwaysOnlyOneStep; }
            set
            {
                alwaysOnlyOneStep = value;
                if (alwaysOnlyOneStep)
                    NumberOfTabs = Math.Min(NumberOfTabs, 4);

                Organize(NumberOfTabs);

                OnPropertyChanged("AlwaysOnlyOneStep");
            }

        }

        public double Depth
        {
            get { return depth; }
            set
            {
                depth = value;
                Organize(NumberOfTabs);
                OnPropertyChanged("Depth");
            }
        }

        public bool WrapAtEnd 
        {
            get { return wrapAtEnd; }
            set
            {
                wrapAtEnd = value;
                OnPropertyChanged("WrapAtEnd");
            }
        }

        public int NumberOfTabs
        {
            get { return tabs.Count; }
            set
            {
                if (value < 2)
                    throw new ArgumentOutOfRangeException("value");

                int newValue = value;
                if (AlwaysOnlyOneStep && value > 4)
                    newValue = 4;

                Organize(Math.Min(newValue, elements.Count));

                OnPropertyChanged("NumberOfTabs");
            }
        }

        public int AnimationDuration
        {
            get { return animationDuration; }
            set
            {
                animationDuration = value;
            }
        }

        #endregion


        public void AddTab(FrameworkElement element)
        {
            elements.Add(element);
            Organize(NumberOfTabs);
        }



        public void SpinToIndex(int index)
        {
            if (isAnimating)
                return;

            if (AlwaysOnlyOneStep)
                instructions.Enqueue(new SpinInstruction(currentIndex, index));
            else
            {
                for (int i = 0; i != index - currentIndex; i += Math.Sign(index - currentIndex))
                    instructions.Enqueue(new SpinInstruction(currentIndex + i, currentIndex + i + Math.Sign(index - currentIndex)));
            }

            Animate();
        }


        public void SpinToNext()
        {
            SpinToIndex(currentIndex + 1);
        }

        public void SpinToPrevious()
        {
            SpinToIndex(currentIndex - 1);
        }

        private void HandleSizeChanged(object sender, SizeChangedEventArgs e)
        {
            RecalculateTransforms();
        }

    }
}
