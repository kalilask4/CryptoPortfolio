using portfolio.Business.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;




namespace portfolio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //ObservableCollection<GroupViewModel> groups;

        /* ObservableCollection<GroupViewModel> groups;
         IGroupService groupService;

         public MainWindow()
         {

             InitializeComponent();
             groupService = new GroupService("db10");
             groups = groupService.GetAll();
             cBoxGroup.DataContext = groups;

         }
        */


        public MainWindow()
        {
            InitializeComponent();

            /*db = new EntityContext();



            db = new EntityContext();
            db.Coins.Load();
            db.Transactions.Load();
            grCoinsData.ItemsSource = db.Coins.Local.ToBindingList();
            grTransactionsData.ItemsSource = db.Transactions.Local.ToBindingList();

            coins = new ObservableCollection<Coin>();
            coins = db.Coins.Local;
            allRelationsCoinsTransactions();*/


        }

       
    }
}
