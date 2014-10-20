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
using System.Windows.Shapes;
using Carousel;
using System.Collections;
using System.Windows.Media.Animation;
using CarouselWPFTestApp.Model;

namespace CarouselWPFTestApp
{
    public partial class CustomiseWindow : Window
    {

        private CarouselControl carouselControl;
        private DataTemplate orderLineDataTemplate =
           (Application.Current as App).Resources["orderLineDataTemplate"] as DataTemplate;

        private Dictionary<int, string> tables;

        public CustomiseWindow()
        {
            InitializeComponent();
            tables = new Dictionary<int, string>
            {
                {1,"Table #1"}, {2,"Table #2"}, {3,"Table #3"}, {4,"Table #4"}, {5,"Table #5"}, {6,"Table #6"}
            };
            cmbTable.ItemsSource = tables;
            //powerEaseIn = new PowerEase() { Power = 6, EasingMode = EasingMode.EaseIn };
            //powerEaseOut = new PowerEase() { Power = 6, EasingMode = EasingMode.EaseOut };
            //bounceEaseIn = new BounceEase() { Bounces = 1, Bounciness = 4, EasingMode = EasingMode.EaseIn };
            //bounceEaseOut = new BounceEase() { Bounces = 1, Bounciness = 4, EasingMode = EasingMode.EaseOut };
            //sineEaseIn = new SineEase() { EasingMode = EasingMode.EaseIn };
            //sineEaseOut = new SineEase() { EasingMode = EasingMode.EaseOut };
        }

        public CarouselControl CarouselControl
        {
            get { return carouselControl; }
            set
            {
                carouselControl = value;
                carouselControl.ItemsSource = GetOrderLineData();
                carouselControl.DataTemplateToUse = orderLineDataTemplate;
                MainWindow.CurrentDemoDataTemplateType = DemoDataTemplateType.OrderLine;
                //slider.Minimum = carouselControl.MinNumberOfItemsOnPath;
                //slider.Maximum = carouselControl.MaxNumberOfItemsOnPath;
                //slider.Value = carouselControl.NumberOfItemsOnPath;
            }
        }

        private IEnumerable GetOrderLineData()
        {
            List<OrderLineData> orderLineData = new List<OrderLineData>();
            orderLineData.Add(new OrderLineData("Steve", "../Images/robot1.png", 1, "Sobrero"));
            orderLineData.Add(new OrderLineData("Ari", "../Images/robot1.png", 1, "Arc"));
            orderLineData.Add(new OrderLineData("Breve", "../Images/robot1.png", 1, "Bahchh"));
            orderLineData.Add(new OrderLineData("Csdfsf", "../Images/robot1.png", 1, "Csdfsf"));
            orderLineData.Add(new OrderLineData("Dsdfdsfsf", "../Images/robot1.png", 1, "Dsdfdsfsf"));
            orderLineData.Add(new OrderLineData("Esdfsdfsdf", "../Images/robot1.png", 1, "Esdfsdfsdf"));
            orderLineData.Add(new OrderLineData("Fthnnthn", "../Images/robot1.png", 1, "Fthnnthn"));
            orderLineData.Add(new OrderLineData("Ghrth", "../Images/robot1.png", 1, "Ghrth"));
            orderLineData.Add(new OrderLineData("Hdfvdvdf", "../Images/robot1.png", 1, "Hdfvdvdf"));

            return orderLineData;
        }

        private IEnumerable GetTableOrderLineData(int tableId)
        {
            List<OrderLineData> orderLineData = new List<OrderLineData>();
            orderLineData.Add(new OrderLineData("Steve", "../Images/robot1.png", tableId, "Sobrero"));
            orderLineData.Add(new OrderLineData("Ari", "../Images/robot1.png", tableId, "Arc"));
            orderLineData.Add(new OrderLineData("Breve", "../Images/robot1.png", tableId, "Bahchh"));
            orderLineData.Add(new OrderLineData("Csdfsf", "../Images/robot1.png", tableId, "Csdfsf"));
            orderLineData.Add(new OrderLineData("Dsdfdsfsf", "../Images/robot1.png", tableId, "Dsdfdsfsf"));
            orderLineData.Add(new OrderLineData("Esdfsdfsdf", "../Images/robot1.png", tableId, "Esdfsdfsdf"));
            orderLineData.Add(new OrderLineData("Fthnnthn", "../Images/robot1.png", tableId, "Fthnnthn"));
            orderLineData.Add(new OrderLineData("Ghrth", "../Images/robot1.png", tableId, "Ghrth"));
            orderLineData.Add(new OrderLineData("Hdfvdvdf", "../Images/robot1.png", tableId, "Hdfvdvdf"));

            return orderLineData;
        }

        private IEnumerable GetSpecificItemOrderLineData(string itemId)
        {
            List<OrderLineData> orderLineData = new List<OrderLineData>();
            orderLineData.Add(new OrderLineData(itemId, "../Images/robot1.png", 3, "Sobrero"));
            orderLineData.Add(new OrderLineData(itemId, "../Images/robot1.png", 3, "Arc"));
            orderLineData.Add(new OrderLineData(itemId, "../Images/robot1.png", 3, "Bahchh"));
            orderLineData.Add(new OrderLineData(itemId, "../Images/robot1.png", 3, "Csdfsf"));
            orderLineData.Add(new OrderLineData(itemId, "../Images/robot1.png", 3, "Dsdfdsfsf"));
            orderLineData.Add(new OrderLineData(itemId, "../Images/robot1.png", 3, "Esdfsdfsdf"));
            orderLineData.Add(new OrderLineData(itemId, "../Images/robot1.png", 3, "Fthnnthn"));
            orderLineData.Add(new OrderLineData(itemId, "../Images/robot1.png", 3, "Ghrth"));
            orderLineData.Add(new OrderLineData(itemId, "../Images/robot1.png", 3, "Hdfvdvdf"));

            return orderLineData;
        }

        private void CmbTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedTable = ((System.Collections.Generic.KeyValuePair<int, string>)(cmbTable.SelectedItem)).Key;
            carouselControl.ItemsSource = GetTableOrderLineData(selectedTable);
        }


        private void CmbNavigationButtonLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbNavigationButtonLocation.SelectedItem != null && CarouselControl != null)
            {
                CarouselControl.NavigationButtonPosition = (ButtonPosition)Enum.Parse(typeof(ButtonPosition),
                    ((ComboBoxItem)cmbNavigationButtonLocation.SelectedItem).Tag.ToString());
            }
        }


        

        private void CmbEasing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (cmbEasing.SelectedItem != null && CarouselControl != null)
            //{
            //    String animationSelected = ((ComboBoxItem)cmbEasing.SelectedItem).Tag.ToString();

            //    switch (animationSelected)
            //    {
            //        case "PowerEase":
            //            CarouselControl.AnimationEaseIn = powerEaseIn;
            //            CarouselControl.AnimationEaseOut = powerEaseOut;
            //            break;
            //        case "BounceEase":
            //            CarouselControl.AnimationEaseIn = bounceEaseIn;
            //            CarouselControl.AnimationEaseOut = bounceEaseOut;
            //            break;
            //        case "SineEase":
            //            CarouselControl.AnimationEaseIn = sineEaseIn;
            //            CarouselControl.AnimationEaseOut = sineEaseOut;
            //            break;
            //    }
            //}
        }

        private void ChangeButtonStyle_Click(object sender, RoutedEventArgs e)
        {
            //CarouselControl.PreviousButtonStyle = blackPreviousButtonStyle;
            //CarouselControl.NextButtonStyle = blackNextButtonStyle;
        }

        private void CmbDataTemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (cmbDataTemplate.SelectedItem != null && CarouselControl != null)
            //{
            //    String templateSelected = ((ComboBoxItem)cmbDataTemplate.SelectedItem).Tag.ToString();

            //    switch (templateSelected)
            //    {
            //        //case "Robot":
            //        //    carouselControl.ItemsSource = GetRobotData();
            //        //    carouselControl.DataTemplateToUse = robotDataTemplate;
            //        //    MainWindow.CurrentDemoDataTemplateType = DemoDataTemplateType.Robot;
            //        //    break;
            //        //case "Person":
            //        //    carouselControl.ItemsSource = GetPersonData();
            //        //    carouselControl.DataTemplateToUse = personDataTemplate;
            //        //    MainWindow.CurrentDemoDataTemplateType = DemoDataTemplateType.Person;
            //        //    break;
            //        case "Order Line":
            //            carouselControl.ItemsSource = GetOrderLineData();
            //            carouselControl.DataTemplateToUse = orderLineDataTemplate;
            //            MainWindow.CurrentDemoDataTemplateType = DemoDataTemplateType.OrderLine;
            //            break;
            //    }
            //}
            
            

        }

        //private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    //if(CarouselControl != null)
        //    //    CarouselControl.NumberOfItemsOnPath = (int)slider.Value;
        //}

        
        

    }
}
