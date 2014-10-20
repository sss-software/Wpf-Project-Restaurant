using BL;
using BussinnesEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Wpf.Waiter
{
    public class OrderViewModel : BaseINPC
    {
        public BussinesLogic bl { get; set; }

        public ICommand DeleteRationCmd{ get; private set; }
        public ICommand AddRationCmd { get; private set; }
        public ICommand AddOrderCmd { get; private set; }

        public OrderViewModel()
        {
            bl = new BussinesLogic();
            //List<Ration> rations = bl.GetAllRations();
            //List<Order> orders = bl.GetAllOrders();
            Orders = new ObservableCollection<Order>();
            _PopulateOrders(bl.GetAllOrders().AsQueryable());


            Delete = new DeleteCommand( 
                ()=>CanDelete,
                order =>
                    {
                        CurrentOrder = null;
                        _PopulateOrders(bl.GetAllOrders().AsQueryable());
                    });

            DeleteRationCmd = new DelegateCommand(
                ration => CanDelete,
                ration =>
                {
                    CurrentOrder.RationList.Remove(CurrentRation);
                    bl.Delete(CurrentRation);
                    bl.Update(CurrentOrder);
                    CurrentRation = null;
                    _PopulateOrders(bl.GetAllOrders().AsQueryable());
                });

            AddOrderCmd = new DelegateCommand(
                ration =>
                {
                    //CurrentOrder.RationList.Add(new Ration());
                    //bl.Delete(CurrentRation);
                    //bl.Update(CurrentOrder);
                    Order newOrder = new Order() { TableId=1};
                    bl.Insert(newOrder);
                    CurrentOrder = newOrder;
                    _PopulateOrders(bl.GetAllOrders().AsQueryable());
                });

            AddRationCmd = new DelegateCommand(
                ration =>
                {
                    CurrentOrder.RationList.Add(new Ration() { CreationDate = DateTime.Now });
                    //bl.Delete(CurrentRation);
                    bl.Update(CurrentOrder);
                    _PopulateOrders(bl.GetAllOrders().AsQueryable());
                }); 
        }

        private void _PopulateOrders(IEnumerable<Order> orders)
        {
            Orders.Clear();
            foreach (var order in orders)
            {
                Orders.Add(order);
            }
        }
        public bool CanDelete
        {
            get { return _currentOrder != null; }
        }

        public bool CanDeleteRation
        {
            get { return _currentRation != null; }
        }

        public ObservableCollection<Order> Orders { get; set; }

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
                RaisePropertyChanged("IsOrderDone");
                //DeleteRation.RaiseCanExecuteChanged();
            }
        }

        private Order _currentOrder;

        public Order CurrentOrder
        {
            get { return _currentOrder; }
            set
            {
                bl.Update(_currentOrder);
                _currentOrder = value;
                RaisePropertyChanged("CurrentOrder");
                RaisePropertyChanged("CanDelete");
                RaisePropertyChanged("IsOrderDone");
                Delete.RaiseCanExecuteChanged();
            }
        }

        public bool IsOrderDone 
        {
            get {
                bool isDone = true;
                if (CurrentOrder != null)
                {
                    foreach (Ration r in CurrentOrder.RationList)
                    {
                        isDone = isDone && r.Done;
                    }
                }
                return isDone; 
            }
            set {
                foreach (Ration r in  CurrentOrder.RationList)
                {
                    r.Done = value;
                }
            }
        }
    }
}