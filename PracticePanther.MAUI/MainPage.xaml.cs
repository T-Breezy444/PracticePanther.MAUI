using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}

    private void Delete_Clicked(object sender, EventArgs e)
    {
		(BindingContext as MainViewModel).Delete();
    }

	private void Edit_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//EditClientPage");
    }

	private void Add_Clicked(object sender, EventArgs e)
	{

    }

	private void Search_Clicked(object sender, EventArgs e)
	{
		(BindingContext as MainViewModel).Search();
    }
	private void Project_Clicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//ProjectPage");
    }
}

