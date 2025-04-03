namespace MauiNavigation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // pagina principal com o modelo de navegação
            MainPage = new NavigationPage(new Principal3());

        }
    }
}
