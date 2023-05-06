
namespace Odev1
{
    public partial class KrediHesaplama : ContentPage
    {
        public KrediHesaplama ()
        {
            InitializeComponent();
            pickerKredi.SelectedIndexChanged += pickerKredi_SelectedIndexChanged;
        }
        
        private void SliderVade_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int vade = (int)e.NewValue;
            selectedVade.Text = vade.ToString();
            labelVade.Text = "Seçilen Vade: " + vade.ToString();
            sliderVade.Value = vade;
            BtnHesapla_Clicked(sender, e);
        }



        private void pickerKredi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerKredi.SelectedItem?.ToString() != null)
            {
                
            }
        }


        private void BtnHesapla_Clicked(object sender, EventArgs e)
        {

            double creditAmount = double.Parse(txtKrediMiktari.Text);
            double interestRate = double.Parse(txtFaizOrani.Text) / 100.0;
            int term = (int)sliderVade.Value;

            double kkdf = 0.0;
            double bsmv = 0.0;
            string credit_type = pickerKredi.SelectedItem.ToString();

            try
            {

                if (credit_type == "Konut Kredisi")
                {
                    kkdf = 0.0;
                    bsmv = 0.0;
                }
                else if (credit_type == "Ýhtiyaç Kredisi")
                {
                    kkdf = 0.15;
                    bsmv = 0.1;
                }
                else if (credit_type == "Taþýt Kredisi")
                {
                    kkdf = 0.15;
                    bsmv = 0.05;
                }
                else if (credit_type == "Ticari Kredi")
                {
                    kkdf = 0.0;
                    bsmv = 0.05;
                }
                else
                {
                    throw new Exception("Hatalý kredi türü seçimi");
                }

                double brutFaiz = ((interestRate + (interestRate * kkdf) + (interestRate * bsmv)) / 12.0);
                double taksit = (creditAmount * brutFaiz * Math.Pow(1 + brutFaiz, term)) / (Math.Pow(1 + brutFaiz, term) - 1);
                double toplam = taksit * term;

                aylikOdemeLabel.Text = taksit.ToString("C2");
                toplamOdemeLabel.Text = toplam.ToString("C2");
                toplamFaizLabel.Text = (toplam - creditAmount).ToString("C2");
            }
            catch (Exception ex)
            {
                aylikOdemeLabel.Text = "";
                toplamOdemeLabel.Text = "";
                toplamFaizLabel.Text = "";
                DisplayAlert("Hata", ex.Message, "Tamam");
            }

           
        }
    }
}




