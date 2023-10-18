using System.Net;
using System.Collections.Specialized;
using System.Text;
using System.Text.Json;

namespace klakulatorWalut
{
    class Waluta
    {
        public string[] kodWalut { get; } = { "eur", "gbp", "usd", "chf", "czk" };
        public string kodWaluty { get; private set; } = "eur";
        public string waluta2 { get; private set; }
        public string date { get; private set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public double skup { get; private set; }
        public double sprzedaz { get; private set; }
        public Waluta(int i=0)
        {
            string code = kodWalut[i];
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
        Waluta waluta;
        
        

        public MainPage()
        {
            InitializeComponent();
            walutaPck.SelectedIndex = 0;
            
        }
        private void pckIndexChanged(object sender, EventArgs e)
        {
            waluta = new Waluta(walutaPck.SelectedIndex);
            lblKurs.Text = waluta.waluta2 + '\n';
            lblKurs.Text += "Skup: " + waluta.skup + '\n';
            lblKurs.Text += "Sprzedaż: " + waluta.sprzedaz;
        }
        private void sprzedajBtnClicked(object sender, EventArgs e)
        {
            string kw = kwotaEnt.Text;
            kw=kw.Replace(".", ",");
            double kwota = (double.TryParse(kw, out double number) ? double.Parse(kw) : kwota = 0);
            double wynik = 0;
            string kwotaz = "";
            if (kwota < 0)
                wynikLbl.Text = "Nie możesz sprzedać ujemnej ilości euro";
            else
            {
                wynik = kwota * waluta.skup;
                kwotaz = "PLN";
                wynikLbl.Text = "otrzymasz: " + wynik.ToString("0.00") + " " + kwotaz;
            }
        }
        private void kupBtnClicked(object sender, EventArgs e)
        {
            string kw = kwotaEnt.Text;
            kw = kw.Replace(".", ",");
            double kwota = (double.TryParse(kw, out double number) ? double.Parse(kw) : kwota = 0);
            double wynik = 0;
            string kwotaz = "";
            if (kwota < 0)
                wynikLbl.Text = "Nie możesz kupić ujemnej ilości euro";
            else
            {
                wynik = kwota * waluta.sprzedaz;
                kwotaz = "PLN";
                wynikLbl.Text = "zapłacisz: " + wynik.ToString("0.00") + " " + kwotaz;
            } 
        }
    }
}