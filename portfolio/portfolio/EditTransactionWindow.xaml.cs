using portfolio.Command;
using portfolio.Domain.Entities;
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

namespace portfolio
{

    public partial class EditTransactionWindow : Window
    {
        #region Properties
        public string Side
        {
            get { return (string)GetValue(SideProperty); }
            set { SetValue(SideProperty, value); }
        }

        public static readonly DependencyProperty SideProperty = DependencyProperty
            .Register("Side", typeof(string),
            typeof(EditCoinWindow),
            new PropertyMetadata(default(string)));


        #endregion

        public EditTransactionWindow()
        {
            InitializeComponent();

            cBoxSide.ItemsSource = Transaction.sideType;
           


        }


        private ICommand _okCommand;
        public ICommand OkCommand =>
        _okCommand
        ?? new RelayCommand(OnOkExecuted);
        public void OnOkExecuted(object param)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}