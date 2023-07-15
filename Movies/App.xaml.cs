namespace Movies;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

	}

    public void OnBurgerMenuClicked(object sender, EventArgs e)
    {
        // The logic to show your menu should go here.
        // As an example, let's just show a simple alert.
        MainPage.DisplayAlert("Menu", "You clicked the menu button!", "OK");
    }
}
