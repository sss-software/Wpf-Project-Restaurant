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
using Bornander.UI.TabCarousel.Test.ExamplePanels;

namespace Bornander.UI.TabCarousel.Test
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = TabControl;
            

            // Default Test
            TabControl.AddTab(new LoginPanel());
            TabControl.AddTab(CreateFixedSizeLabel("Alpha", new Size(320, 240)));
            TabControl.AddTab(CreateFixedSizeLabel("Bravo", new Size(320, 240)));
            TabControl.AddTab(CreateFixedSizeLabel("Charlie", new Size(320, 240)));
            TabControl.AddTab(CreateFixedSizeLabel("Delta", new Size(320, 240)));
            TabControl.AddTab(CreateFixedSizeLabel("Echo", new Size(320, 240)));
            TabControl.AddTab(CreateFixedSizeLabel("Foxtrot", new Size(320, 240)));
            TabControl.AddTab(CreateFixedSizeLabel("Hotel", new Size(320, 240)));
            TabControl.AddTab(CreateFixedSizeLabel("Gemini", new Size(320, 240)));

            //// Aspect ratio test
            //TabControl.AddTab(CreateFixedSizeLabel("A", new Size(80, 60)));
            //TabControl.AddTab(CreateFixedSizeLabel("B", new Size(160, 120)));
            //TabControl.AddTab(CreateFixedSizeLabel("C", new Size(320, 240)));
            //TabControl.AddTab(CreateFixedSizeLabel("D", new Size(640, 480)));
            //TabControl.AddTab(CreateFixedSizeLabel("E", new Size(100, 200)));
            //TabControl.AddTab(CreateFixedSizeLabel("F", new Size(120, 300)));
            //TabControl.AddTab(CreateFixedSizeLabel("H", new Size(100, 100)));
            //TabControl.AddTab(CreateFixedSizeLabel("G", new Size(1024, 768)));
            //TabControl.NumberOfTabs = 8;

            TabControl.NumberOfTabs = 4;
            TabControl.AnimationDuration = 2000;
        
        }

        private static FrameworkElement CreateFixedSizeLabel(string text, Size size)
        {
            Button label = new Button { Content = text};
            label.FontSize = 64;

            label.MinWidth = label.MaxWidth = label.Width = size.Width;
            label.MinHeight = label.MaxHeight = label.Height = size.Height;

            return label;
        }

        private void HandlePrevious(object sender, RoutedEventArgs e)
        {
            TabControl.SpinToPrevious();
        }

        private void HandleNext(object sender, RoutedEventArgs e)
        {
            TabControl.SpinToNext();
        }

        private void GotoIndex(object sender, RoutedEventArgs e)
        {
           TabControl.SpinToIndex((int)TargetIndex.Value);
        }
    }
}
