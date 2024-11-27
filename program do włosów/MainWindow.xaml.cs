using System;
using System.Windows;

namespace WlosyApp
{
    public partial class MainWindow : Window
    {
        // Klasa Glowa zdefiniowana wewnątrz MainWindow.xaml.cs
        public class Glowa
        {
            // Stałe wartości domyślne
            private const double DomyslnaGestoscWlosow = 200; // w włosach/cm2
            private const double DomyslnyObwodGlowy = 56; // w cm
            private const double DomyslnaWysokoscCzola = 10; // w cm
            private const double DomyslnaPowierzchniaGlowy = 500; // w cm2

            // Pola prywatne
            private double gestoscWlosow;
            private double obwodGlowy;
            private double wysokoscCzola;
            private double powierzchniaGlowy;

            // Konstruktor
            public Glowa()
            {
                // Przypisanie wartości domyślnych
                gestoscWlosow = DomyslnaGestoscWlosow;
                obwodGlowy = DomyslnyObwodGlowy;
                wysokoscCzola = DomyslnaWysokoscCzola;
                powierzchniaGlowy = DomyslnaPowierzchniaGlowy;
            }

            // Metody dostępu i modyfikacji wartości
            public double PobierzGestoscWlosow() => gestoscWlosow;
            public void UstawGestoscWlosow(double gestosc) => gestoscWlosow = gestosc;

            public double PobierzObwodGlowy() => obwodGlowy;
            public void UstawObwodGlowy(double obwod) => obwodGlowy = obwod;

            public double PobierzWysokoscCzola() => wysokoscCzola;
            public void UstawWysokoscCzola(double wysokosc) => wysokoscCzola = wysokosc;

            public double PobierzPowierzchnieGlowy() => powierzchniaGlowy;
            public void UstawPowierzchnieGlowy(double powierzchnia) => powierzchniaGlowy = powierzchnia;

            // Metody do obliczania liczby włosów w programie
            public double ObliczLiczbeWlosow()
            {
                return gestoscWlosow * powierzchniaGlowy;
            }

            public double ObliczLiczbeWlosow(double obwod, double wysokosc)
            {
                double powierzchnia = obwod * wysokosc / 2; // Przybliżona powierzchnia
                return gestoscWlosow * powierzchnia;
            }
        }

        private Glowa glowa;

        public MainWindow()
        {
            InitializeComponent();
            glowa = new Glowa();
        }

        private void Oblicz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Pobieranie wartości z interfejsu
                double gestosc = double.Parse(GestoscTextBox.Text);
                double obwod = double.Parse(ObwodTextBox.Text);
                double wysokosc = double.Parse(WysokoscTextBox.Text);

                // Ustawianie wartości w obiekcie
                glowa.UstawGestoscWlosow(gestosc);
                glowa.UstawObwodGlowy(obwod);
                glowa.UstawWysokoscCzola(wysokosc);

                // Obliczanie liczby włosów
                double liczbaWlosow = glowa.ObliczLiczbeWlosow(obwod, wysokosc);
                WynikTextBlock.Text = liczbaWlosow.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
        }

        private void Resetuj_Click(object sender, RoutedEventArgs e)
        {
            // Resetowanie pól do wartości domyślnych
            GestoscTextBox.Text = "200";
            ObwodTextBox.Text = "56";
            WysokoscTextBox.Text = "10";
            WynikTextBlock.Text = "";
        }
    }
}
