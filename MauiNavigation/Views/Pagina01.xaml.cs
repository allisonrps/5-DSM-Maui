namespace MauiNavigation.Views;

public partial class Pagina01 : ContentPage
{
	public Pagina01()
	{
		InitializeComponent();
	}

    private void btnPagina02_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Pagina02());
    }

    private void btnVoltarPrincipal_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}