using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PracticePanther.MAUI.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public string Query { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Client> Clients 
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                    return new ObservableCollection<Client>(ClientService.Current.GetAll);
                else
                    return new ObservableCollection<Client>(ClientService.Current.Search(Query));   
            }

        }
        
        public Client SelectedClient { get; set; }

        public void Search()
        {
            NotifyPropertyChanged("Clients");
        }

        public void Delete()
        {
            if (SelectedClient == null)
            {
                return;
            }
            ClientService.Current.Delete(SelectedClient);
            NotifyPropertyChanged("Clients");
        }

        public void expand()
        {
            //changes selected clint to display its Id, OpenDate, IsActive, and Notes
            if (SelectedClient == null)
            {
                return;
            }
            ClientService.Current.expand(SelectedClient);
            NotifyPropertyChanged("Clients");


        }


        
       
      

    }
}
