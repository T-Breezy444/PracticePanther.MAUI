using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.MAUI.ViewModels
{
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

            public int clientid { get; set; }
            public int personId { get; set; }

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
                {
                    Name = project.ShortName;
                    clientid = project.ClientId;
                    personId = project.Id;
                }

                NotifyPropertyChanged(nameof(Name));
                NotifyPropertyChanged(nameof(clientid));

            }

            public void AddClient(int id = 0)
            {

                if (personId <= 0)
                {
                    ProjectService.Current.Add(new Project { ShortName = Name, OpenDate = DateTime.Today, IsActive = true, Id = ProjectService.Current.GetAll.Count + 1 });
                }
                else
                {
                    var refToUpdate = ProjectService.Current.GetById(id);
                    refToUpdate.ShortName = Name;
                    refToUpdate.Id = id;
                    refToUpdate.ClientId = clientid;

                }
                RefreshView();
                Shell.Current.GoToAsync("//EditClientPage");
            }

            public void RefreshView()
            {
                NotifyPropertyChanged(nameof(Name));
                NotifyPropertyChanged(nameof(clientid));
                NotifyPropertyChanged("Projects");
            }
        }

    }

}
