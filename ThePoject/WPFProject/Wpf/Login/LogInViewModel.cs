using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading;
using System.Windows;
//using BL;
//using BussinnesEntity;

namespace Wpf.Login
{
    public class LogInViewModel : INotifyPropertyChanged
    {

        private ILoadable loadable;
        private string userName = string.Empty;
        private string password = string.Empty;
        private bool isLogInActive = true;
        //private Person p = null;
        private double progress = 0;

        public ICommand LoginCommand { get; private set; }// For the login btn
        public ICommand CancelCommand { get; private set; }// For the login btn
        public ICommand ErrorOkCommand { get; private set; }// For the Ok btn that in the error panel
        public LogInViewModel(ILoadable loadable)
        {
            this.loadable = loadable;

            LoginCommand = new DelegateCommand(x => UserName.Length > 0, x =>
            {
                //BussinesLogic bl = new BussinesLogic();
                //p = bl.GetPersonByEmail(UserName);
                IsLogInActive = false;
                Notify("MutexIndex", "ErrorTitle");

                //if (p != null && Password.Equals(p.Password))
                //{
                //    BackgroundWorker worker = new BackgroundWorker();
                //    worker.DoWork += (s, e) =>
                //        {
                //            while (progress < 1)
                //            {
                //                Thread.Sleep(50);
                //                progress += 0.01;
                //                Notify("Progress");
                //            }
                //        };
                //    worker.RunWorkerCompleted += (s, e) => loadable.Loaded(p.PersonType);
                //    worker.RunWorkerAsync();
                //}
            });
            ErrorOkCommand = new DelegateCommand(x => IsLogInActive = true);

            CancelCommand = new DelegateCommand(x =>
            {
                loadable.Cancel();
            });
        }


        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                Notify("UserName");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                Notify("Password");
            }
        }

        public bool IsLogInActive
        {
            get { return isLogInActive; }
            set
            {
                isLogInActive = value;
                Notify("IsLogInActive");
            }
        }

        public int MutexIndex
        {
            get { return 0; }
            //get { return p != null ? 0 : 1; }
        }

        public string ErrorTitle
        {
            get { return "User not found!"; }
        }

        public double Progress
        {
            get { return progress; }
        }

        public string ErrorMessage
        {
            get { return "The user not exist in system"; }
        }

        private void Notify(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
