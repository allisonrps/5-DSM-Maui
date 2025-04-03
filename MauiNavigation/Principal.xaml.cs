using MauiNavigation.Views;

namespace MauiNavigation;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}

    private void btnPagina01_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Pagina01());
    }
}