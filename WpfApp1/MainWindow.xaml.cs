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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void laskeKaikki(double sade)
        {
            teksti1.Text = ($"Ympyrän kehän pituus: {Math.PI * 2 * sade}.\n" +
                $"Ympyrän pinta-ala: {Math.PI * Math.Pow(sade, 2)}.\n" +
                $"Pallon tilavuus: {4 * Math.PI * Math.Pow(sade, 3) / 3}.");
        }
        private void laskePituus(double sade)
        {
            teksti1.Text = ($"Ympyrän kehän pituus: {Math.PI * 2 * sade}.");
        }
        private void laskeAla(double sade)
        {
            teksti1.Text = ($"Ympyrän pinta-ala: {Math.PI * Math.Pow(sade, 2)}.");

        }
        private void laskeTilavuus(double sade)
        {
            teksti1.Text = ($"Pallon tilavuus: {4 * Math.PI * Math.Pow(sade, 3) / 3}.");
        }
        private void virhe()
        {
            teksti1.Text = "Virhe! Syötä positiivinen kokonais- tai desimaaliluku!\nPilkku desimaalierottimena.";
        }
        private void radioBoxVirhe()
        {
            teksti1.Text = "Radioboxeissa on jokin virhe, palataan myöhemmin asiaan.";
        }
        private void haeTieto()
        {
            try
            {
                if (double.Parse(sade.Text) < 0)
                {
                    virhe();
                }
                else if (double.Parse(sade.Text) == 0)
                {
                    teksti1.Text = "Syötä positiivinen kokonais- tai desimaaliluku!\nNolla ei tässä ohjelmassa tee mitään.";
                }
                else
                {
                    if (radio1.IsChecked == true)
                    {
                        laskeKaikki(double.Parse(sade.Text));
                    }
                    else if (radio2.IsChecked == true)
                    {
                        laskePituus(double.Parse(sade.Text));
                    }
                    else if (radio3.IsChecked == true)
                    {
                        laskeAla(double.Parse(sade.Text));
                    }
                    else if (radio4.IsChecked == true)
                    {
                        laskeTilavuus(double.Parse(sade.Text));
                    }
                    else
                    {
                        radioBoxVirhe();
                    }
                }
            }
            catch
            {
                virhe();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                haeTieto();
                sade.Clear();
            }
        }

        private async void laskeSade_Click(object sender, RoutedEventArgs e)
        {
            // Ei toimi ilman threadin takia(?), aliohjemassa async samasta syystä
            await Task.Run(() =>
            {

            }).ConfigureAwait(true);
            /* -------------------------------- */
            haeTieto();
            sade.Clear();
        }
    }
}
