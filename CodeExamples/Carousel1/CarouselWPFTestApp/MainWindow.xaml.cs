using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections;
using System.Linq;
using CarouselWPFTestApp.Model;

namespace CarouselWPFTestApp
{
    public enum DemoDataTemplateType { /*Robot, Person,*/ OrderLine };

	public partial class MainWindow : Window
	{
        public static DemoDataTemplateType CurrentDemoDataTemplateType { get; set; }

		public MainWindow()
		{
            this.InitializeComponent();
            CurrentDemoDataTemplateType = DemoDataTemplateType.OrderLine;
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CustomiseWindow window = new CustomiseWindow();
            window.CarouselControl = this.CarouselControl;
            window.ShowInTaskbar = false;
            window.Owner = this;
            window.Left = 800;
            window.Top = 200;
            window.Show();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            if (args.AddedItems.Count ==0)
                return;

            switch (CurrentDemoDataTemplateType)
            {
                //case DemoDataTemplateType.Robot:
                //    lblSelectedItem.Content = ((RobotData)args.AddedItems[0]).RobotName;
                //    break;
                //case DemoDataTemplateType.Person:
                //    lblSelectedItem.Content = ((PersonData)args.AddedItems[0]).FullName;
                //    break;
                case DemoDataTemplateType.OrderLine:
                    lblSelectedItem.Content = ((OrderLineData)args.AddedItems[0]).Product;
                    break;
            }
        }

	}
}