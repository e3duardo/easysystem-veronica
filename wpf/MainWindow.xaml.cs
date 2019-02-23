using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            menu1.Items.Add(new wpf.MenuCadastros());
            menu1.Items.Add(new wpf.MenuFinanceiro());

            menu1.Items.Add(new wpf.MenuVenda());
            menu1.Items.Add(new wpf.MenuRelatorios());
            menu1.Items.Add(new wpf.MenuAjuda());
        }
    }
}
