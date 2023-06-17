using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class ProjectPage : ContentPage
{
	public ProjectPage()
	{
		InitializeComponent();
		BindingContext = new ProjectPageViewModel();
	}

    private void Add_Clicked(object sender, EventArgs e)
    {

    }

    private void Edit_Clicked(object sender, EventArgs e)
    {

    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectPageViewModel).Delete();
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void Search_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectPageViewModel).Search();
    }
    public void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ProjectPageViewModel).RefreshView();
    }
}