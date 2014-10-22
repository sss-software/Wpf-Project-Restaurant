using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Carousel;
using BussinnesEntity;
using BL;

namespace Wpf.Kitchen
{
    /// <summary>
    /// Interaction logic for CustomiseWindow.xaml
    /// </summary>
    public partial class CustomiseWindow : Window
    {
        //Restaurant_DAL.RestaurantDbContextDataContext db;
        private CarouselControl carouselControl;
       
        private List<BussinnesEntity.Table> activeTables;
        private List<String> products;

        public BussinesLogic bl { get; set; }

        public CustomiseWindow()
        {
            InitializeComponent();
            bl = new BussinesLogic();

            activeTables = bl.GetAllTables();
            products = Enum.GetNames(typeof(RationType)).ToList<String>();
            cmbTable.ItemsSource = activeTables;
            cmbProduct.ItemsSource = products;
        }

        public CarouselControl CarouselControl
        {
            get { return carouselControl; }
            set
            {
                carouselControl = value;
                carouselControl.ItemsSource = GetOrderLineData();
                //KitchenWindow.CurrentDemoDataTemplateType = DemoDataTemplateType.OrderLine;
            }
        }

        private IEnumerable GetOrderLineData()
        {

            List<RationModel> old = new List<RationModel>();

            var orderLineData = bl.GetAllRations‬‎();
            foreach (Ration item in orderLineData)
            {
                old.Add(new RationModel(item));
            }
            
            return old;
           
        }

        private IEnumerable GetTableOrderLineData(int TableId)
        {
            List<RationModel> old = new List<RationModel>();

            var orderLineData = bl.GetAllRationsOfSpasificTable(TableId);
            foreach (Ration item in orderLineData)
            {
                old.Add(new RationModel(item));
            }

            return old;
        }

        private IEnumerable GetSpecificItemOrderLineData(string itemId)
        {
            List<Ration> orderLineData = new List<Ration>();
            orderLineData.Add(new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, RationId = 1 });
            orderLineData.Add(new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, RationId = 2 });
            orderLineData.Add(new Ration() { Type = RationType.Fish, Price = 25.8, Done = true, CreationDate = DateTime.Now, RationId = 3 });
            orderLineData.Add(new Ration() { Type = RationType.Fish, Price = 25.8, Done = true, CreationDate = DateTime.Now, RationId = 4 });
            orderLineData.Add(new Ration() { Type = RationType.Meat, Price = 42.5, Done = true, CreationDate = DateTime.Now, RationId = 5 });
            orderLineData.Add(new Ration() { Type = RationType.Salmon, Price = 34, Done = true, CreationDate = DateTime.Now, RationId = 6 });
            orderLineData.Add(new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, RationId = 7 });
            orderLineData.Add(new Ration() { Type = RationType.Schnitzel, Price = 12, Done = true, CreationDate = DateTime.Now, RationId = 8 });
            orderLineData.Add(new Ration() { Type = RationType.Salmon, Price = 34, Done = true, CreationDate = DateTime.Now, RationId = 9 });
            orderLineData.Add(new Ration() { Type = RationType.IceCream, Price = 5, Done = true, CreationDate = DateTime.Now, RationId = 10 });
            orderLineData.Add(new Ration() { Type = RationType.Meat, Price = 42.5, Done = true, CreationDate = DateTime.Now, RationId = 11 });
            orderLineData.Add(new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, RationId = 12 });
            orderLineData.Add(new Ration() { Type = RationType.Meat, Price = 42.5, Done = true, CreationDate = DateTime.Now, RationId = 13 });
            orderLineData.Add(new Ration() { Type = RationType.Fish, Price = 25.8, Done = true, CreationDate = DateTime.Now, RationId = 14 });
            orderLineData.Add(new Ration() { Type = RationType.Meat, Price = 42.5, Done = true, CreationDate = DateTime.Now, RationId = 15 });
            orderLineData.Add(new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, RationId = 16 });
            orderLineData.Add(new Ration() { Type = RationType.IceCream, Price = 5, Done = true, CreationDate = DateTime.Now, RationId = 17 });
            orderLineData.Add(new Ration() { Type = RationType.Fish, Price = 25.8, Done = true, CreationDate = DateTime.Now, RationId = 18 });
            orderLineData.Add(new Ration() { Type = RationType.IceCream, Price = 5, Done = true, CreationDate = DateTime.Now, RationId = 19 });
            orderLineData.Add(new Ration() { Type = RationType.Meat, Price = 42.5, Done = true, CreationDate = DateTime.Now, RationId = 20 });
            orderLineData.Add(new Ration() { Type = RationType.Meat, Price = 42.5, Done = true, CreationDate = DateTime.Now, RationId = 21 });
            orderLineData.Add(new Ration() { Type = RationType.Salmon, Price = 34, Done = true, CreationDate = DateTime.Now, RationId = 22 });
            orderLineData.Add(new Ration() { Type = RationType.Salmon, Price = 34, Done = true, CreationDate = DateTime.Now, RationId = 23 });
            orderLineData.Add(new Ration() { Type = RationType.Schnitzel, Price = 12, Done = true, CreationDate = DateTime.Now, RationId = 24 });
            orderLineData.Add(new Ration() { Type = RationType.Schnitzel, Price = 12, Done = true, CreationDate = DateTime.Now, RationId = 25 });
            orderLineData.Add(new Ration() { Type = RationType.IceCream, Price = 5, Done = true, CreationDate = DateTime.Now, RationId = 26 });
            orderLineData.Add(new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, RationId = 27 });
            orderLineData.Add(new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, RationId = 28 });
            orderLineData.Add(new Ration() { Type = RationType.Fish, Price = 25.8, Done = true, CreationDate = DateTime.Now, RationId = 29 });
            orderLineData.Add(new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, RationId = 30 });

            return orderLineData;
        }

        private void CmbTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedTable = ((BussinnesEntity.Table)(e.AddedItems[0])).TableId;
            carouselControl.ItemsSource = GetTableOrderLineData(selectedTable);
        }


        private void cmbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int selectedItem = ((Ration)(e.AddedItems[0])).ProductId;
            //carouselControl.ItemsSource = GetSpecificItemOrderLineData(selectedItem);
        }
    }
}
