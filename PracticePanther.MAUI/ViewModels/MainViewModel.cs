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
        public ObservableCollection<Project> Projects
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                    return new ObservableCollection<Project>(ProjectService.Current.GetAll);
                else
                    return new ObservableCollection<Project>(ProjectService.Current.Search(Query));
            }
        }
        public void RefreshView()
        {
            NotifyPropertyChanged($"{nameof(Clients)}");
            NotifyPropertyChanged($"{nameof(Projects)}");
        }


        
       
      

    }
}
