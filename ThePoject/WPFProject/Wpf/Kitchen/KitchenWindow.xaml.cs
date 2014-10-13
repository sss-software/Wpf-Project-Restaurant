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
using Wpf.Login;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class KitchenWindow : Window
    {
        public KitchenWindow()
        {
            InitializeComponent();
            DataContext = TabControl;

            //Need to Put here the list of the ration that didn't done yet.
            //List<Ration> NotDoneRationList = new List<Ration>();
            //NotDoneRationList.Add(new Ration { RationId = 0, Price = 10 , Description="One", Done=false});
            //NotDoneRationList.Add(new Ration { RationId = 1, Price = 20, Description = "Two", Done = false });
            //NotDoneRationList.Add(new Ration { RationId = 2, Price = 30, Description = "Three", Done = false });
            //NotDoneRationList.Add(new Ration { RationId = 3, Price = 40, Description = "Four", Done = false });


            BussinesLogic bl = new BussinesLogic();

            List<Ration> NotDoneRationList = bl.GetAllRations().Where(x => x.Done == false).ToList();
            foreach (Ration item in NotDoneRationList)
            {
                TabControl.AddTab(CreateFixedSizeLabel(item.Description, new Size(320, 240)));
                //TODO: TabControl.AddTab(new RationKitchenUserControl());
            }
            
            //TabControl.NumberOfTabs = NotDoneRationList.Count;

            TabControl.AnimationDuration = 2000;
        }

        private static FrameworkElement CreateFixedSizeLabel(string text, Size size)
        {
            Button label = new Button { Content = text };
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

        private void DoSometing(object sender, RoutedEventArgs e)
        {
            //Just btn for some debug check if you need
        }
    }
}
