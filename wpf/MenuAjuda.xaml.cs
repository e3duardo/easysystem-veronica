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
    /// Interação lógica para MenuCadastros.xam
    /// </summary>
    public partial class MenuAjuda : MenuItem
    {
        public MenuAjuda()
        {
            InitializeComponent();
        }

        private void Sobre_Click(object sender, RoutedEventArgs e)
        {
            new wpf.Ajuda.Sobre().Show();
        }
    }
}
