namespace MauiNavigation;

public partial class PaginaFinal : ContentPage
{
	public PaginaFinal()
	{
		InitializeComponent();
	}

    private async void btnPaginaDemo_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}