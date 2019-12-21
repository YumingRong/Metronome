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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime lastT;
        private bool bFirstTap;
        private int nHit;

        public MainWindow()
        {
            InitializeComponent();
            bFirstTap = true;
            nHit = 0;
        }

        private void btnTap_Click(object sender, RoutedEventArgs e)
        {
            newTap();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            bFirstTap = true;
            nHit = 0;
            txtBeat.Text = "0";
            
        }

        private void newTap()
        {
            DateTime tap = new DateTime();
            tap = DateTime.Now;
            if (bFirstTap)
            {
                lastT = tap;
                bFirstTap = false;
            }
            else
            {
                TimeSpan elapse = new TimeSpan();
                elapse = tap - lastT;
                TimeSpan tpb = new TimeSpan(elapse.Ticks / nHit);
                int bpm = Convert.ToInt32( 60 * 1000 / tpb.TotalMilliseconds);
                txtBeat.Text = bpm.ToString();
            }
            nHit++;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                newTap();

        }
    }
}
