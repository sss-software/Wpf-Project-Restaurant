using BL;
using BussinnesEntity;
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
using Wpf.Kitchen;
using Wpf.Login;

namespace Wpf
{
    //public enum DemoDataTemplateType { /*Robot, Person,*/ OrderLine };
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class KitchenWindow : Window
    {
        List<Ration> NotDoneRationList=null;

        //public static DemoDataTemplateType CurrentDemoDataTemplateType { get; set; }
        KitchenViewModel kvm;
        public KitchenWindow()
        {
            InitializeComponent();
            kvm = new KitchenViewModel();
            DataContext = kvm;
            //CurrentDemoDataTemplateType = DemoDataTemplateType.OrderLine;
            //this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
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
            if (args.AddedItems.Count == 0)
                return;
            kvm.CurrentRation = ((RationModel)args.AddedItems[0]);
            //switch (CurrentDemoDataTemplateType)
            //{
            //    case DemoDataTemplateType.OrderLine:
            //        //lblSelectedItem.Content = ((OrderLineData)args.AddedItems[0]).Product;
            //        break;
            //}
        }

        private void DoneCurrent(object sender, RoutedEventArgs e)
        {
            //Ration current = NotDoneRationList.ElementAt(TabControl.GetCurrentIndex());
            //current.Done = true;
            
        }
    }
}
