using PracticePanther.MAUI.ViewModels;
namespace PracticePanther.MAUI.Views;

public partial class EditClientPage : ContentPage
{
    
    public EditClientPage()
	{
		InitializeComponent();
		BindingContext = new EditClientViewModel();
	}



    private void Add_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientDetailPage");
    }

    private void Edit_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EditClientViewModel).Edit_Click(Shell.Current);
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EditClientViewModel).Delete();
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void Search_Clicked(object sender, EventArgs e)
    {
          (BindingContext as EditClientViewModel).Search();
    }

    public void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as EditClientViewModel).RefreshView();
    }
}