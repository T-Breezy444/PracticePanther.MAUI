using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticePanther.MAUI.ViewModels
{
    public class ClientDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public int ClientId { get; set; }
        public List<Project> Projects
        {
            get
            {
                if (ClientId <= 0)
                {
                    return new List<Project>();
                }
                else
                {
                   //goes into projectlist and then goes the list clientid to search clientid for any matching projectid
                    return ProjectService.Current.GetAll.Where(p => p.ClientId.Contains(ClientId)).ToList();
                }
            }
        }
        public DateTime OpenDate { get; set; }
        public bool IsActive { get; set; }
        public ClientDetailViewModel(int id=0)
        {
            if (id > 0)
            {
                LoadById(id);
            }
        }
        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var person = ClientService.Current.GetById(id) as Client;
            if (person != null)
            {
                Name = person.Name;
                Notes = person.Notes;
                ClientId = person.Id;
                OpenDate = person.OpenDate;
                IsActive = person.IsActive;
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Notes));
        }
        public void AddClient(int id = 0)
        {
            if (ClientId <= 0)
            {
               ClientService.Current.Add(new Client { Name = Name, OpenDate = DateTime.Today, IsActive = true ,Id = ClientService.Current.GetAll.Count + 1 });
            }
            else
            {
                var refToUpdate = ClientService.Current.GetById(ClientId);
                refToUpdate.Name = Name;
                refToUpdate.Notes = Notes;
                refToUpdate.OpenDate = OpenDate;
                //checks if the client is on any projects which is found in projectlist clientid
                if (ProjectService.Current.GetAll.Where(p => p.ClientId.Contains(ClientId)).ToList().Count > 0)
                {
                    refToUpdate.IsActive = true;
                }
                else
                {
                    refToUpdate.IsActive = IsActive;
                }

            }
            RefreshView();
            Shell.Current.GoToAsync("//EditClientPage");
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(ClientId));
            NotifyPropertyChanged("Clients");
        }
    }
}
