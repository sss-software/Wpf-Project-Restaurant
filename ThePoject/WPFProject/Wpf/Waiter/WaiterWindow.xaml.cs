using BL;
using BussinnesEntity;
using System;
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

namespace Wpf.Waiter
{
    /// <summary>
    /// Interaction logic for WaiterWindow.xaml
    /// </summary>
    public partial class WaiterWindow : Window
    {
        public WaiterWindow()
        {
            InitializeComponent();
            DataContext = new OrderViewModel();
        }

        public BussinesLogic bl { get; set; }
        /*public WaiterWindow()
        {
            InitializeComponent();
            bl = new BussinesLogic();
            List<Ration> rations = bl.GetAllRations();
            List<Order> orders = bl.GetAllOrders();
        }*/

        public void UpdateRation(Ration ration)
        {
            bl.Update(ration);
        }

        public void UpdateOrder(Order order)
        {
            bl.Update(order);
        }
    }
}
