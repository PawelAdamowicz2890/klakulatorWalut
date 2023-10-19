namespace klakulatorWalut;

public partial class zmianyKursu : ContentPage
{
	Waluta waluty=new Waluta();
	
	public zmianyKursu()
	{
		InitializeComponent();
        System.DateTime date1 = new System.DateTime(1996, 5, 3, 22,15,0);
        System.DateTime date2 = new System.DateTime(1996, 6, 3, 22, 15, 0);
        System.TimeSpan diff = date2.Subtract(date1);
        System.DateTime date3 = DateTime.Now.Subtract(diff);
        Waluta laterVal = new Waluta(date3.ToString("yyyy-MM-dd"));
        for (int i = 0; i < waluty.kodWalut.Length; i++)
		{
			if(i==0)
			{
				waluty = new Waluta(i);
                laterVal = new Waluta(date3.ToString("yyyy-MM-dd"), i);
				eurkLbl.Text = waluty.kodWalut[i];
                if(laterVal.skup>waluty.skup)
                {
                    a1Pic.Source = "garrow.png";
                    sk1Lbl.Text = waluty.skup.ToString();
                }
			}
			else if(i==1)
			{
                waluty = new Waluta(i);
                gbpLbl.Text = waluty.kodWalut[i];
            }
            else if (i == 2)
            {
                waluty = new Waluta(i);
                usdLbl.Text = waluty.kodWalut[i];
            }
            else if (i == 3)
            {
                waluty = new Waluta(i);
                chfLbl.Text = waluty.kodWalut[i];
            }
            else if (i == 4)
            {
                waluty = new Waluta(i);
                czkLbl.Text = waluty.kodWalut[i];
            }
        }
	}
}