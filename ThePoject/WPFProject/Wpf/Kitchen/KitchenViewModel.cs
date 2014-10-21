using BL;
using BussinnesEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Wpf.Kitchen
{
    public class KitchenViewModel:BaseINPC
    {
        public BussinesLogic bl { get; set; }
        public ObservableCollection<OrderLineData> Rations { get; set; }

        public List<Table> ActiveTables{ get; set; }
        public List<String> RationTaypes { get; set; }

        public ICommand DoneRationCmd { get; private set; }

        public KitchenViewModel()
        {
            bl = new BussinesLogic();
            Rations = new ObservableCollection<OrderLineData>();
            ActiveTables = bl.GetAllTables();
            RationTaypes = Enum.GetNames(typeof(RationType)).ToList<String>();

            _PopulateRations(bl.GetAllRations‬‎().AsQueryable());

            DoneRationCmd = new DelegateCommand(
                ration => CanDeleteRation,
                ration =>
                {
                    CurrentRation.the_r.Done = true; ;
                    bl.Update(CurrentRation.the_r);
                    CurrentRation = null;
                    _PopulateRations(bl.GetAllRations‬‎().AsQueryable());
                });

            

        }
        
        public void _PopulateRations(IEnumerable<Ration> rations)
        {
            Rations.Clear();
            foreach (var ration in rations)
            {
                Rations.Add(new OrderLineData(ration));

            }

        }


        private OrderLineData _currentRation;

        public OrderLineData CurrentRation
        {
            get { return _currentRation; }
            set
            {
                _currentRation = value;
                RaisePropertyChanged("CurrentRation");
                RaisePropertyChanged("CanDeleteRation");
                //DeleteRation.RaiseCanExecuteChanged();
            }
        }

        public bool CanDeleteRation
        {
            get { return _currentRation != null; }
        }

        private void CmbTable_SelectionChanged(int table_id)
        {
            //int selectedTable = ((BussinnesEntity.Table)(e.AddedItems[0])).TableId;
            _PopulateRations(bl.GetAllRationsOfSpasificTable(table_id).AsQueryable());
        }

        private Table onCurentTable;

        public Table OnCurentTable
        {
            get { return onCurentTable; }
            set
            {
                onCurentTable = value;
                CmbTable_SelectionChanged(onCurentTable.TableId);
                RaisePropertyChanged("OnCurentTable");
                //DeleteRation.RaiseCanExecuteChanged();
            }
        }
        


        private void cmbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //int selectedItem = ((Ration)(e.AddedItems[0])).ProductId;
            //carouselControl.ItemsSource = GetSpecificItemOrderLineData(selectedItem);
        }
    }
}
