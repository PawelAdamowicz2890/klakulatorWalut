namespace klakulatorWalut
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private void przeliczBtnClicked(object sender, EventArgs e)
        {
            int kwota = int.Parse(kwotaEnt.Text);
            double wynik = 0;
            string waluta = "";
            bool czyEu = rbtnEu.IsChecked;
            if (czyEu)
            {
                wynik = kwota * 4.55;
                waluta = "PLN";
            }
            else
            {
                wynik = kwota / 4.55;
                waluta = "EUR";
            }
            wynikLbl.Text=wynik.ToString("0.00")+waluta;
        }
    }
}