using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Bornander.UI.Test.Controls
{
    public class SimpleGraph : FrameworkElement
    {
        public static readonly DependencyProperty MaxProperty = DependencyProperty.RegisterAttached("Max", typeof(double), typeof(SimpleGraph), new PropertyMetadata(0.0, OnChanged));
        public static readonly DependencyProperty MinProperty = DependencyProperty.RegisterAttached("Min", typeof(double), typeof(SimpleGraph), new PropertyMetadata(0.0, OnChanged));
        public static readonly DependencyProperty MaxValuesProperty = DependencyProperty.RegisterAttached("MaxValues", typeof(int), typeof(SimpleGraph), new PropertyMetadata(32, OnChanged));
        public static readonly DependencyProperty ValuesProperty = DependencyProperty.RegisterAttached("Values", typeof(IList<double>), typeof(SimpleGraph), new PropertyMetadata(null, OnChanged));

        public static readonly DependencyProperty LinePenProperty = DependencyProperty.RegisterAttached("LinePen", typeof(Pen), typeof(SimpleGraph), new PropertyMetadata(new Pen(Brushes.Black, 2.0), OnChanged));
        public static readonly DependencyProperty ZeroLinePenProperty = DependencyProperty.RegisterAttached("ZeroLinePen", typeof(Pen), typeof(SimpleGraph), new PropertyMetadata(null, OnChanged));
        public static readonly DependencyProperty AverageLinePenProperty = DependencyProperty.RegisterAttached("AverageLinePen", typeof(Pen), typeof(SimpleGraph), new PropertyMetadata(null, OnChanged));

        #region Dependency properties support

        public static double GetMax(UIElement element)
        {
            return (double)element.GetValue(SimpleGraph.MaxProperty);
        }

        public static void SetMax(UIElement element, double value)
        {
            element.SetValue(SimpleGraph.MaxProperty, value);
        }

        public static double GetMin(UIElement element)
        {
            return (double)element.GetValue(SimpleGraph.MinProperty);
        }

        public static void SetMin(UIElement element, double value)
        {
            element.SetValue(SimpleGraph.MinProperty, value);
        }

        public static int GetMaxValues(UIElement element)
        {
            return (int)element.GetValue(SimpleGraph.MaxValuesProperty);
        }

        public static void SetMaxValues(UIElement element, int value)
        {
            element.SetValue(SimpleGraph.MaxValuesProperty, value);
        }

        public static IList<double> GetValues(UIElement element)
        {
            return (IList<double>)element.GetValue(SimpleGraph.ValuesProperty);
        }

        public static void SetValues(UIElement element, IList<double> value)
        {
            element.SetValue(SimpleGraph.ValuesProperty, value);
        }

        public static Pen GetLinePen(UIElement element)
        {
            return (Pen)element.GetValue(SimpleGraph.LinePenProperty);
        }

        public static void SetLinePen(UIElement element, Pen value)
        {
            element.SetValue(SimpleGraph.LinePenProperty, value);
        }

        public static Pen GetZeroLinePen(UIElement element)
        {
            return (Pen)element.GetValue(SimpleGraph.ZeroLinePenProperty);
        }

        public static void SetZeroLinePen(UIElement element, Pen value)
        {
            element.SetValue(SimpleGraph.ZeroLinePenProperty, value);
        }

        public static Pen GetAverageLinePen(UIElement element)
        {
            return (Pen)element.GetValue(SimpleGraph.AverageLinePenProperty);
        }

        public static void SetAverageLinePen(UIElement element, Pen value)
        {
            element.SetValue(SimpleGraph.AverageLinePenProperty, value);
        }

        private static void OnChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((SimpleGraph)sender).InvalidateVisual();
        }

        public double Max
        {
            get { return GetMax(this); }
            set { SetMax(this, value); }
        }

        public double Min
        {
            get { return GetMin(this); }
            set { SetMin(this, value); }
        }

        public int MaxValues
        {
            get { return GetMaxValues(this); }
            set { SetMaxValues(this, value); }
        }

        public IList<double> Values
        {
            get { return GetValues(this); }
            set { SetValues(this, value); }
        }

        public Pen LinePen
        {
            get { return GetLinePen(this); }
            set { SetLinePen(this, value); }
        }

        public Pen ZeroLinePen
        {
            get { return GetZeroLinePen(this); }
            set { SetZeroLinePen(this, value); }
        }

        public Pen AverageLinePen
        {
            get { return GetAverageLinePen(this); }
            set { SetAverageLinePen(this, value); }
        }

        #endregion

        private double TranslateValue(double value)
        {
            double range = Math.Abs(Max - Min);
            return ((value - Min) / range) * ActualHeight; 
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (Values != null && Values.Count > 1)
            {
                while (Values.Count > MaxValues)
                    Values.RemoveAt(0);

                double horizontalSpacing = ActualWidth / (Values.Count - 1);
                
                if (ZeroLinePen != null)
                    drawingContext.DrawLine(ZeroLinePen, new Point(0, TranslateValue(0)), new Point(ActualWidth, TranslateValue(0)));

                if (AverageLinePen != null)
                    drawingContext.DrawLine(AverageLinePen, new Point(0, TranslateValue(Values.Average())), new Point(ActualWidth, TranslateValue(Values.Average())));
                
                for(int i = 1; i < Values.Count; ++i)
                {
                    drawingContext.DrawLine(LinePen,
                        new Point((i - 1) * horizontalSpacing, TranslateValue(Values[i - 1])),
                        new Point((i - 0) * horizontalSpacing, TranslateValue(Values[i - 0])));  
                }
            }
        }
    }
}
