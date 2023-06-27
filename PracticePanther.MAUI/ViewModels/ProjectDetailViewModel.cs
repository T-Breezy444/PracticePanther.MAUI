using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticePanther.MAUI.ViewModels
{
    public class ProjectDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string? Name { get; set; }
        public int ProjectId { get; set; }
        public List<Client> Clients
        {
            get
            {
                if (ProjectId <= 0)
                {
                    return new List<Client>();
                }
                else
                {
                   //returns all clients that have a project with the same id as the project id
                    return ClientService.Current.GetAll.Where(p => p.Id == ProjectId).ToList();
                }
            }
        }
        public DateTime OpenDate { get; set; }
        public bool IsActive { get; set; }

        public List<Client> AllClients
        {
            get
            {
                return ClientService.Current.GetAll.ToList();
            }
        }

        public Client SelectedClient { get; set; }
        public void AddClient()
        {
            if (SelectedClient != null)
            {
   
                
                var project = ProjectService.Current.GetById(ProjectId) as Project;
                project.ClientId.Add(SelectedClient.Id);
                NotifyPropertyChanged(nameof(Clients));
            }
        }
        public ProjectDetailViewModel(int id = 0)
        {
            if (id > 0)
            {
                LoadById(id);
            }
        }
        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var project = ProjectService.Current.GetById(id) as Project;
            if (project != null)
            {
                Name = project.ShortName;
                ProjectId = project.Id;
                OpenDate = project.OpenDate;
                IsActive = project.IsActive;
            }
            NotifyPropertyChanged(nameof(Name));
        }
        public void AddProject(int id = 0)
        {
            if (ProjectId <= 0)
            {
                ProjectService.Current.Add(new Project
                {
                    ShortName = Name,
                    OpenDate = OpenDate,
                    IsActive = IsActive,
                    
                    Id = ProjectService.Current.GetAll.Count() + 1

                }) ;
            }         
            else
            {
                var refToUpdate = ProjectService.Current.GetById(ProjectId);
                refToUpdate.ShortName = Name;
                refToUpdate.OpenDate = OpenDate;
                if (refToUpdate.ClientId.Count() == 0)
                {
                    refToUpdate.IsActive = true;
                }
                else
                {
                    refToUpdate.IsActive = IsActive;
                }
            }
            RefreshView();
            Shell.Current.GoToAsync("//ProjectPage");
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(ProjectId));
            NotifyPropertyChanged("Projects");
        }
    }
}
