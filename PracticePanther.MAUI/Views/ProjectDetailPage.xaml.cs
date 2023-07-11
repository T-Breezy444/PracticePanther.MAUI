using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(ProjectId), "projectId")]
public partial class ProjectDetailPage : ContentPage
{
    public int ProjectId { set; get; }
    public ProjectDetailPage()
    {
        InitializeComponent();
    }
    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectDetailViewModel(ProjectId);
    }

    private void Ok_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectDetailViewModel).AddProject();
    }
    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ProjectPage");
    }
    private void AddClientClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectDetailViewModel).AddClient();
    }
    private void AddEmployeeClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectDetailViewModel).AddEmployee();
    }

}
