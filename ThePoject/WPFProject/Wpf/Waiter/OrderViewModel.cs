using BL;
using BussinnesEntity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Wpf.Waiter
{
    public class OrderViewModel : BaseINPC
    {
        public BussinesLogic bl { get; set; }
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

            DeleteRation = new DeleteRationCommand(
                () => CanDelete,
                (order,ration) =>
                {
                    CurrentOrder = null;
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
                _currentRation = value;
                RaisePropertyChanged("CurrentRation");
                RaisePropertyChanged("CanDelete");
                DeleteRation.RaiseCanExecuteChanged();
            }
        }

        private Order _currentOrder;

        public Order CurrentOrder
        {
            get { return _currentOrder; }
            set
            {
                _currentOrder = value;
                RaisePropertyChanged("CurrentOrder");
                RaisePropertyChanged("CanDelete");
                Delete.RaiseCanExecuteChanged();
            }
        }
    }
}