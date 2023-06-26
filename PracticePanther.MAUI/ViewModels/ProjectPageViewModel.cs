using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.MAUI.ViewModels
{
    class ProjectPageViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Search()
        {
            NotifyPropertyChanged("Projects");
        }
        public string Query { get; set; }
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

        public Client SelectedProject { get; set; }
        public void Delete()
        {
            if (SelectedProject == null)
            {
                return;
            }
            ClientService.Current.Delete(SelectedProject);
            NotifyPropertyChanged("Clients");
        }

        public void Edit_Click(Shell s)
        {
            var idParam = SelectedProject?.Id ?? 0;
            s.GoToAsync($"//ClientDetailPage?personId={idParam}");
        }

        public void RefreshView()
        {
            NotifyPropertyChanged($"{nameof(SelectedProject)}");
            NotifyPropertyChanged($"{nameof(Client)}");
            NotifyPropertyChanged("Clients");
        }


    }
}

    
