namespace MauiNavigation.Views;

public partial class Pagina02 : ContentPage
{
	public Pagina02()
	{
		InitializeComponent();
	}

    private void btnVoltarAnterior_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void btnVoltarPrimeira_Clicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }
}