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
	private void Client_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//EditClientPage");
    }
	private void Project_Clicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//ProjectPage");
    }
	private void OnArriving(object sender, NavigatedToEventArgs e)
	{
        (BindingContext as MainViewModel).RefreshView();
    }
   
}

