using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.MAUI
{
    public class Client
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        
        public Client(int id = 0, DateTime openDate = new DateTime(), DateTime closeDate = new DateTime(), bool isActive = false, string name = "", string notes = "")
        {
            Id = id;
            OpenDate = openDate;
            CloseDate = closeDate;
            IsActive = isActive;
            Name = name;
            Notes = notes;
        }

        public override string ToString()
        {
            //returns a string representation of the object
            return $"[{Id}] {Name}";
        }


    }

    public class Project
    {
        
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public bool IsActive { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public int ClientId { get; set; }

        
        
        public Project(int id = 0, DateTime openDate = new DateTime(), DateTime closeDate = new DateTime(), bool isActive = false, string shortName = "", string longName = "", int clientId = 0)
        {
            Id = id;
            OpenDate = openDate;
            CloseDate = closeDate;
            IsActive = isActive;
            ShortName = shortName;
            LongName = longName;
            ClientId = clientId;
        }
        public override string ToString()
        {
            //returns a string representation of the object
            return $"[{Id}] /n{ShortName},{LongName} /n{OpenDate} {IsActive} /nClient ID: {ClientId}";
        }


    }

    public class ClientService
    {
        private static ClientService? _instance;
        private static object _lock = new object();

        public static ClientService Current
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ClientService();
                    }
                    return _instance;
                }
            }
        }

        private List<Client> patrons;

        private ClientService()
        {
            patrons = new List<Client>
            { 
                new Client(1, new DateTime(2021, 1, 1), new DateTime(2021, 1, 1), true, "John Doe", "This is a test client"),
                new Client(2),
                new Client(3),
                new Client(4),
                new Client(5),
                new Client(6)
            };


        }

        public List<Client> GetAll
        {
            get { return patrons; }
        }

        public Client? Get(int id)
        {
            return patrons.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Client? patronToAdd)
        {
             if(patronToAdd != null)
            {
                patrons.Add(patronToAdd);
            }
        }
        public void Delete(int id)
        {
            var patronToRemove = Get(id);
            if (patronToRemove != null)
            {
                patrons.Remove(patronToRemove);
            }
        }

        public void Delete(Client ClientToDelete)
        {
            Delete(ClientToDelete.Id);
        }
        public void Read()
        {
            patrons.ForEach(Console.WriteLine);
        }

        public List<Client> Search(string Query)
        {
            return patrons.Where(p => p.Name.ToUpper().Contains(Query.ToUpper())).ToList();
        }

        public Client? GetById(int id)
        {
            return patrons.FirstOrDefault(p => p.Id == id);
        }



    }

    public class ProjectService
    {
        //identical to ClientService but projects
        private static ProjectService? _instance;
        private static object _lock = new object();
        public static ProjectService Current
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ProjectService();
                    }
                    return _instance;
                }
            }
        }
        public ProjectService()
        {
            projects = new List<Project>
            {
                new Project(1, new DateTime(2021, 1, 1), new DateTime(2021, 1, 1), true, "Test", "This is a test project", 1),
                new Project(2),
                new Project(3),
                new Project(4),
                new Project(5),
                new Project(6)
            };

        }
        private List<Project> projects;

        public List<Project> GetAll
        {
            get { return projects; }
        }

        public Project Get(int id)
        {
            return projects.FirstOrDefault(p => p.Id == id);
        }

        //add a new project, check to make sure it has a ClientId that is valid
        public void Add(Project projectToAdd)
        {
            if (projectToAdd != null)
            {
                if (ClientService.Current.Get(projectToAdd.ClientId) != null)
                {
                    projects.Add(projectToAdd);
                }
            }
        }
        public void Update(Project projectToUpdate)
        {

        }
        public void Delete(int id)
        {
            var projectToRemove = Get(id);
            if (projectToRemove != null)
            {
                projects.Remove(projectToRemove);
            }
        }
        //Search function that searches by short name
        public List<Project> Search(string Query)
        {
            return projects.Where(p => p.ShortName.ToUpper().Contains(Query.ToUpper())).ToList();
        }
       



        

    }
    public class Employee
    {
        //singleton design pattern
        private static Employee _instance;
        public int Id { get; set; }
        public decimal Rate { get; set; }
        public string Name { get; set; }
        public static Employee Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Employee();
                }
                return _instance;
            }
        } 
        private Employee(int id = 0, decimal rate = 0, string name = "")
        {
            Id = id;
            Rate = rate;
            Name = name;
        }

    }

    //class to represent ime used to work on a project
    public class Time
    {
        //singleton desgin pattern
        private static Time _instance;
        public DateTime Date { get; set; }
        public string Narrative { get; set; }
        public decimal Hours { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public static Time Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Time();
                }
                return _instance;
            }
        }
        private Time(DateTime date = new DateTime(), string narrative = "", decimal hours = 0, int projectId = 0, int employeeId = 0)
        {
            Date = date;
            Narrative = narrative;
            Hours = hours;
            ProjectId = projectId;
            EmployeeId = employeeId;
        }
    }
    


}
