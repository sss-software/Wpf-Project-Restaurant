using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace Wpf.Login
{
    public class LogInViewModel : INotifyPropertyChanged
    {

        private ILoadable loadable;

        private string userName = String.Empty;
        private bool isLogInActive = true;

        private double progress = 0;

        public ICommand LoginCommand { get; private set; }// For the login btn
        public ICommand ErrorOkCommand { get; private set; }// For the Ok btn that in the error panel
        public LogInViewModel(ILoadable loadable)
        {
            this.loadable = loadable;

            LoginCommand = new DelegateCommand(x => UserName.Length > 0, x => 
            { 
                IsLogInActive = false; 
                Notify("MutexIndex", "ErrorTitle");
                if (UserName == "Yadid" || UserName == "Moshe")
                {
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += (s, e) =>
                        {
                            while (progress < 1)
                            {
                                Thread.Sleep(50);
                                progress += 0.01;
                                Notify("Progress");
                            }
                        };
                    worker.RunWorkerCompleted += (s, e) => loadable.Loaded(UserName);
                    worker.RunWorkerAsync();
                }
            });
            ErrorOkCommand = new DelegateCommand(x => IsLogInActive = true);
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
            get { return (UserName == "Yadid" || UserName == "Moshe") ? 0 : 1; }
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
            get { return "The user Name Need to be Yadid Or Moshe"; }
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
