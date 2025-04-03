namespace MauiNavigation;

public partial class PaginaDemo : ContentPage
{
    public PaginaDemo()
    {
        InitializeComponent();
    }

    private async void btnpagfinal_clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaFinal());
    }

    private async void btnPaginaFinal_clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaFinal());
    }
}