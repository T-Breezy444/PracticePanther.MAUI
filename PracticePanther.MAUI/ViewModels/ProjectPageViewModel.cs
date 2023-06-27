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
        public Project SelectedProject { get; set; }
        public void Delete()
        {
            if (SelectedProject == null)
            {
                return;
            }
            ProjectService.Current.Delete(SelectedProject.Id);
            NotifyPropertyChanged("Projects");
        }
        public void Edit_Click(Shell s)
        {
            if (SelectedProject == null)
            {
                return;
            }
            s.GoToAsync($"//ProjectDetailPage?projectId={SelectedProject.Id}");
        }
        public void RefreshView()
        {
            NotifyPropertyChanged($"{nameof(SelectedProject)}");
            NotifyPropertyChanged($"{nameof(Client)}");
            NotifyPropertyChanged("Projects");
        }


    }
}

    
