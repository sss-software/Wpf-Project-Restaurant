//using BL;
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

namespace Wpf.Manager
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        //public BussinesLogic bl { get; set; }
        public ManagerWindow()
        {
            InitializeComponent();
            //bl = new BussinesLogic();
            //List<BussinnesEntity.Table> tabels = bl.GetAllTables();
        }

        //public List<BussinnesEntity.Order> AllOrdersByIdTable(int idTable)
        //{
        //    return bl.GetAllOrdersOfSpasificTable(idTable);
        //}
    }
}
