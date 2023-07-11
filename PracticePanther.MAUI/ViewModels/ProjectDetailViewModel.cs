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

        public DateTime DueDate { get; set; }
        public List<Employee> Employees
        {
            get
            {
                if (ProjectId <= 0)
                {
                    return new List<Employee>();
                }
                else
                {
                    //returns all employees that have a project with the same id as the employee id
                    return EmployeeService.Current.GetAll.Where(p => p.Id == ProjectId).ToList();
                }   
            }
        }

        public List<Employee> AllEmpoyees
        {
            get
            {
                return EmployeeService.Current.GetAll.ToList();
            }
        }

        public void AddEmployee()
        {
            if (SelectedEmployee != null)
            {
               var project = ProjectService.Current.GetById(ProjectId) as Project;
               project.Employee = SelectedEmployee;
               RefreshView();
            }
        }
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
        public Employee SelectedEmployee { get; set; }
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
                    Id = ProjectService.Current.GetAll.Count() + 1,
                    bill = new Bill(SelectedEmployee.Id = 0, ProjectId, Hours = 0, SelectedEmployee.Rate = 0, DueDate)
                }) ;
               // ProjectService.Current.GetById(ProjectId).newBill(SelectedEmployee.Id = 0, ProjectId, Hours = 0, SelectedEmployee.Rate = 0);
            }         
            else
            {
                var refToUpdate = ProjectService.Current.GetById(ProjectId);
                refToUpdate.ShortName = Name;
                refToUpdate.OpenDate = OpenDate;

                refToUpdate.bill = new Bill(SelectedEmployee.Id, ProjectId, Hours, SelectedEmployee.Rate, DueDate);
               // refToUpdate.newBill(SelectedEmployee.Id = 0, ProjectId, Hours = 0, SelectedEmployee.Rate = 0);
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
        
        public void Total()
        {
           //calculates total bill for the project AND UPDATES  
          // ProjectService.Current.GetById(ProjectId).bill.total();

        }

        public decimal Hours { 
            get
            {
                return ProjectService.Current.GetById(ProjectId).bill.hours;
            } 
            set
            {
                ProjectService.Current.GetById(ProjectId).bill.hours = value;
            }
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(ProjectId));
            NotifyPropertyChanged("Projects");
            NotifyPropertyChanged(nameof(Hours));
        }
        
        //need to have a bill associated with the product 

    }
}
