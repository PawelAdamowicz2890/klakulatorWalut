namespace klakulatorWalut;

public partial class zmianyKursu : ContentPage
{
	Waluta waluty=new Waluta();
	
	public zmianyKursu()
	{
		InitializeComponent();
        System.DateTime date1 = new System.DateTime(1996, 5, 3, 22,15,0);
        System.DateTime date2 = new System.DateTime(1996, 5, 4, 22, 15, 0);
        System.TimeSpan diff = date2.Subtract(date1);
        System.DateTime date3 = DateTime.Now.Subtract(diff);
        Waluta earlVal = new Waluta(date3.ToString("yyyy-MM-dd"));
        for (int i = 0; i < waluty.kodWalut.Length; i++)
		{
			if(i==0)
			{
				waluty = new Waluta(i);
                earlVal = new Waluta(date3.ToString("yyyy-MM-dd"), i);
				eurkLbl.Text = waluty.kodWalut[i];
                sk1Lbl.Text = waluty.skup.ToString();
                sp1Lbl.Text = waluty.sprzedaz.ToString();
                if (earlVal.skup < waluty.skup)
                    a1Pic.Source = "garrow.png";
                else
                    a1Pic.Source = "rarrow.png";
                if (earlVal.sprzedaz < waluty.sprzedaz)
                    a2Pic.Source = "garrow.png";
                else
                    a2Pic.Source = "rarrow.png";

            }
			else if(i==1)
			{ 
                waluty = new Waluta(i);
                earlVal = new Waluta(date3.ToString("yyyy-MM-dd"), i);
                gbpLbl.Text = waluty.kodWalut[i];
                sk2Lbl.Text = waluty.skup.ToString();
                sp2Lbl.Text = waluty.sprzedaz.ToString();
                if (earlVal.skup < waluty.skup)
                    a3Pic.Source = "garrow.png";
                else
                    a3Pic.Source = "rarrow.png";
                if (earlVal.sprzedaz < waluty.sprzedaz)
                    a4Pic.Source = "garrow.png";
                else
                    a4Pic.Source = "rarrow.png";
            }
            else if (i == 2)
            {
                waluty = new Waluta(i);
                earlVal = new Waluta(date3.ToString("yyyy-MM-dd"), i);
                usdLbl.Text = waluty.kodWalut[i];
                sk3Lbl.Text = waluty.skup.ToString();
                sp3Lbl.Text = waluty.sprzedaz.ToString();
                if (earlVal.skup < waluty.skup)
                    a5Pic.Source = "garrow.png";
                else
                    a5Pic.Source = "rarrow.png";
                if (earlVal.sprzedaz < waluty.sprzedaz)
                    a6Pic.Source = "garrow.png";
                else
                    a6Pic.Source = "rarrow.png";
            }
            else if (i == 3)
            {
                waluty = new Waluta(i);
                earlVal = new Waluta(date3.ToString("yyyy-MM-dd"), i);
                chfLbl.Text = waluty.kodWalut[i];
                sk4Lbl.Text = waluty.skup.ToString();
                sp4Lbl.Text = waluty.sprzedaz.ToString();
                if (earlVal.skup < waluty.skup)
                    a7Pic.Source = "garrow.png";
                else
                    a7Pic.Source = "rarrow.png";
                if (earlVal.sprzedaz < waluty.sprzedaz)
                    a8Pic.Source = "garrow.png";
                else
                    a8Pic.Source = "rarrow.png";
            }
            else if (i == 4)
            {
                waluty = new Waluta(i);
                earlVal = new Waluta(date3.ToString("yyyy-MM-dd"), i);
                czkLbl.Text = waluty.kodWalut[i];
                sk5Lbl.Text = waluty.skup.ToString();
                sp5Lbl.Text = waluty.sprzedaz.ToString();
                if (earlVal.skup < waluty.skup)
                    a9Pic.Source = "garrow.png";
                else
                    a9Pic.Source = "rarrow.png";
                if (earlVal.sprzedaz < waluty.sprzedaz)
                    a10Pic.Source = "garrow.png";
                else
                    a10Pic.Source = "rarrow.png";
            }
        }
	}
}