using System.Net;
using System.Collections.Specialized;
using System.Text;
using System.Text.Json;

namespace klakulatorWalut
{
    class Waluta
    {
        public string kodWaluty { get; private set; } = "eur";
        public string waluta2 { get; private set; }
        public string date { get; private set; } = "2023-10-11";
        public double skup { get; private set; }
        public double sprzedaz { get; private set; }
        public Waluta(string code = "eur")
        {
            if (code.Length > 0)
            {
                kodWaluty = code;
            }
            pobierzDane();
        }
        private void pobierzDane()
        {
            string wynik;
            using (var webClient = new WebClient())
            {
                wynik = webClient.DownloadString("https://api.nbp.pl/api/exchangerates/rates/c/" + kodWaluty + "/" + date + "/?format=json");
            }
            using JsonDocument j1 = JsonDocument.Parse(wynik);
            JsonElement json = j1.RootElement;
            waluta2 = json.GetProperty("currency").ToString();
            var rates = json.GetProperty("rates");
            var rate = rates[0];
            string bid = rate.GetProperty("bid").ToString();
            bid = bid.Replace('.', ',');
            string ask = rate.GetProperty("ask").ToString();
            ask = ask.Replace(".", ",");
            skup = double.Parse(bid);
            sprzedaz = double.Parse(ask);
            
        }
    }
    public partial class MainPage : ContentPage
    {
        Waluta euro;
        
        

        public MainPage()
        {
            InitializeComponent();
            euro = new Waluta("eur");
            lblKurs.Text = euro.waluta2 + '\n';
            lblKurs.Text += "Skup: " + euro.skup + '\n';
            lblKurs.Text += "Sprzedaż: " + euro.sprzedaz;
        }
        
        private void przeliczBtnClicked(object sender, EventArgs e)
        {
           
            int kwota = int.Parse(kwotaEnt.Text);
            double wynik = 0;
            string waluta = "";
            bool czyEu = rbtnEu.IsChecked;
            if (czyEu)
            {
                wynik = kwota * euro.skup;
                waluta = "PLN";
            }
            else
            {

                wynik = kwota / euro.skup;
                waluta = "EUR";
            }
            wynikLbl.Text=wynik.ToString("0.00")+waluta;
            lblTest.Text = euro.waluta2;
        }
    }
}