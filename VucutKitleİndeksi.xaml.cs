namespace Odev1;

public partial class VucutKitleİndeksi : ContentPage
{
    public VucutKitleİndeksi()
    {
        InitializeComponent();
    }
    private void Hesapla_Clicked(object sender, EventArgs e)
    {
        double boy;
        if (double.TryParse(boyEntry.Text, out double parsedBoy))
        {
            boy = parsedBoy / 100.0; 
        }
        else
        {
            boy = boySlider.Value / 100.0;
            boyEntry.Text = $"{boy * 100:F0}"; 
        }

        double kilo = double.Parse(kiloEntry.Text);

        double vki = kilo / (boy * boy);

        sonucLabel.Text = $"Vücut Kitle İndeksi: {vki:F2}";

   
        if (vki < 18.5)
        {
            sonucLabel.Text += "\nİdeal kilonun altında";
        }
        else if (vki >= 18.5 && vki <= 24.9)
        {
            sonucLabel.Text += "\nİdeal kiloda";
        }
        else if (vki >= 25 && vki <= 29.9)
        {
            sonucLabel.Text += "\nİdeal kilonun üstünde";
        }
        else if (vki >= 30 && vki <= 39.9)
        {
            sonucLabel.Text += "\nİdeal kilonun çok üstünde (obez)";
        }
        else
        {
            sonucLabel.Text += "\nİdeal kilonun çok üstünde (morbid obez)";
        }
    }

    private void BoySlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        boyEntry.Text = $"{e.NewValue:F0}"; 
    }

    private void KiloSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        kiloEntry.Text = e.NewValue.ToString();
    }

}