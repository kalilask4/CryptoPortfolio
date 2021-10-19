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
    /// <summary>
    /// Логика взаимодействия для EditCoinWindow.xaml
    /// </summary>
    public partial class EditCoinWindow : Window
    {
        #region Properties
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for
        //Name.This enables animation, styling, binding, etc.
        public static readonly DependencyProperty NameProperty = DependencyProperty
            .Register("Name", typeof(string),
            typeof(EditCoinWindow),
            new PropertyMetadata(default(string)));

        #endregion


        public EditCoinWindow()
        {
            InitializeComponent();
        }
    }
}

