using BL;
using BussinnesEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Wpf.Waiter
{
    public class TableViewModel : BaseINPC
    {
        public BussinesLogic bl { get; set; }

        public ICommand DeleteRationCmd{ get; private set; }
        public ICommand AddRationCmd { get; private set; }
        public ICommand AddTableCmd { get; private set; }

        public TableViewModel()
        {
            bl = new BussinesLogic();
            //List<Ration> rations = bl.GetAllRations();
            //List<Order> orders = bl.GetAllOrders();
            Tables = new ObservableCollection<Table>();
            _PopulateTables(bl.GetAllTables().AsQueryable());


            Delete = new DeleteCommand( 
                ()=>CanDelete,
                table =>
                    {
                        CurrentTable = null;
                        _PopulateTables(bl.GetAllTables().AsQueryable());
                    });

            DeleteRationCmd = new DelegateCommand(
                ration => CanDelete,
                ration =>
                {
                    CurrentTable.RationList.Remove(CurrentRation);
                    bl.Delete(CurrentRation);
                    bl.Update(CurrentTable);
                    CurrentRation = null;
                    _PopulateTables(bl.GetAllTables().AsQueryable());
                });

            AddTableCmd = new DelegateCommand(
                ration =>
                {
                    //CurrentOrder.RationList.Add(new Ration());
                    //bl.Delete(CurrentRation);
                    //bl.Update(CurrentOrder);
                    Table newTable = new Table();
                    bl.Insert(newTable);
                    CurrentTable = newTable;
                    _PopulateTables(bl.GetAllTables().AsQueryable());
                });

            AddRationCmd = new DelegateCommand(
                ration =>
                {
                    CurrentTable.RationList.Add(new Ration() { CreationDate = DateTime.Now });
                    //bl.Delete(CurrentRation);
                    bl.Update(CurrentTable);
                    _PopulateTables(bl.GetAllTables().AsQueryable());
                }); 
        }

        private void _PopulateTables(IEnumerable<Table> tables)
        {
            Tables.Clear();
            foreach (var table in tables)
            {
                Tables.Add(table);
            }
        }
        public bool CanDelete
        {
            get { return _currentTable != null; }
        }

        public bool CanDeleteRation
        {
            get { return _currentRation != null; }
        }

        public ObservableCollection<Table> Tables { get; set; }

        public DeleteCommand Delete { get; set; }
        public DeleteRationCommand DeleteRation { get; set; }

        private Ration _currentRation;

        public Ration CurrentRation
        {
            get { return _currentRation; }
            set
            {
                bl.Update(_currentRation);
                _currentRation = value;
                RaisePropertyChanged("CurrentRation");
                RaisePropertyChanged("CanDelete");
                RaisePropertyChanged("IsTableDone");
                //DeleteRation.RaiseCanExecuteChanged();
            }
        }

        private Table _currentTable;

        public Table CurrentTable
        {
            get { return _currentTable; }
            set
            {
                bl.Update(_currentTable);
                _currentTable = value;
                RaisePropertyChanged("CurrentTable");
                RaisePropertyChanged("CanDelete");
                RaisePropertyChanged("IsTableDone");
                Delete.RaiseCanExecuteChanged();
            }
        }

        public bool IsTableDone 
        {
            get {
                bool isDone = true;
                if (CurrentTable != null)
                {
                    foreach (Ration r in CurrentTable.RationList)
                    {
                        isDone = isDone && r.Done;
                    }
                }
                return isDone; 
            }
            set {
                foreach (Ration r in CurrentTable.RationList)
                {
                    r.Done = value;
                }
            }
        }
    }
}