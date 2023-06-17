using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.MAUI.ViewModels
{
    internal class EditClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Search()
        {
            NotifyPropertyChanged("Clients");
        }
        public string Query { get; set; }
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
        public void Delete()
        {
            if (SelectedClient == null)
            {
                return;
            }
            ClientService.Current.Delete(SelectedClient);
            NotifyPropertyChanged("Clients");
        }

        public void Edit_Click(Shell s)
        {
            var idParam = SelectedClient?.Id ?? 0;
            s.GoToAsync($"//ClientDetailPage?personId={idParam}");
        }

        public void RefreshView()
        {
            NotifyPropertyChanged($"{nameof(SelectedClient)}");
            NotifyPropertyChanged($"{nameof(Client)}");
            NotifyPropertyChanged("Clients");
        }


    }
}
