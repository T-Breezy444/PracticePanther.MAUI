using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ClientDetailPage : ContentPage
{  
    public int ClientId { set; get; }
    public ClientDetailPage()
	{
		InitializeComponent();
	}

  /*  public ClientDetailPage(int id)
    {
        InitializeComponent();
        BindingContext = new ClientDetailViewModel(id);
        Name = (BindingContext as ClientDetailViewModel).Name;
        Notes = (BindingContext as ClientDetailViewModel).Notes;

    }
    */
    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientDetailViewModel(ClientId);
    }

    private void Ok_Clicked(object sender, EventArgs e)
    {
        //this is giving me a null reference exception
        (BindingContext as ClientDetailViewModel).AddClient();
    }
    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EditClientPage");
    }
}
