namespace MauiNavigation;

public partial class Principal3 : ContentPage
{
	public Principal3()
	{
		InitializeComponent();
	}


	private async void btnpagdemo_clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new PaginaDemo());
	}
}