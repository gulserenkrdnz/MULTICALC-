namespace Odev1
{
    public partial class RenkSecici : ContentPage
    {
        public RenkSecici()
        {
            InitializeComponent();

        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int kirmizi = (int)kirmiziSlider.Value;
            int yesil = (int)yesilSlider.Value;
            int mavi = (int)maviSlider.Value;

            Color renk = Color.FromRgb(kirmizi, yesil, mavi);
            renkKutusu.Color = renk;

           
            string renkKodu = $"#{kirmizi:X2}{yesil:X2}{mavi:X2}";
            renkEtiketi.Text = renkKodu;


            Clipboard.SetTextAsync(renkKodu);
        }
        private async void OnLabelTapped(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var renkKodu = label.Text;
            await Clipboard.SetTextAsync(renkKodu);
            await DisplayAlert("Kopyalandý", "Renk kodu panoya kopyalandý.", "Tamam");
        }


        private void RastgeleRenkAta()
        {
            Random random = new Random();

            int kirmizi = random.Next(0, 255);
            int yesil = random.Next(0, 255);
            int mavi = random.Next(0, 255);

            Color renk = Color.FromRgb(kirmizi, yesil, mavi);
            renkKutusu.Color = renk;

            string renkKodu = $"#{kirmizi:X2}{yesil:X2}{mavi:X2}";
            renkEtiketi.Text = renkKodu;
        }

        private void OnRandomButtonClicked(object sender, EventArgs e)
        {
            RastgeleRenkAta();
        }
    }
}
