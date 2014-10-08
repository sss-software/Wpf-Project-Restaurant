using System.Windows.Controls;

namespace Wpf.Login
{
    public partial class ErrorPanel : UserControl
    {
        public ErrorPanel()
        {
            InitializeComponent();

            DataContextChanged += new System.Windows.DependencyPropertyChangedEventHandler(ErrorPanel_DataContextChanged);
        }

        void ErrorPanel_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
