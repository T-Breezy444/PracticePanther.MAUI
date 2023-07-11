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
        public List<Project> Projects { get; set; }
        
        public Client(int id = 0, DateTime openDate = new DateTime(), DateTime closeDate = new DateTime(), bool isActive = false, string name = "", string notes = "")
        {
            Id = id;
            OpenDate = openDate;
            CloseDate = closeDate;
            IsActive = isActive;
            Name = name;
            Notes = notes;
            Projects = new List<Project>();
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
        public List<int> ClientId { get; set; }
        public Time TimeEntry { get; set; }
        public Employee Employee { get; set; }
        public Bill bill { get; set; }

        public void total()
        {
            bill.total = bill.rate * bill.hours;
        }
        public Project(int id = 0, DateTime openDate = new DateTime(), DateTime closeDate = new DateTime(), bool isActive = false, string shortName = "", string longName = "", int clientId = 0)
        {
            Id = id;
            OpenDate = openDate;
            CloseDate = closeDate;
            IsActive = isActive;
            ShortName = shortName;
            LongName = longName;
            ClientId = new List<int>();
            ClientId.Add(clientId);
            Employee = new Employee();
            TimeEntry = new Time();
            bill = new Bill();
            bill.employeeId = Employee.Id;
        }
        public override string ToString()
        {
            return $"Id:[{Id}]   {ShortName},   {LongName} \r\n{OpenDate} {IsActive} \r\n{Employee}\r\n{bill}\r\n";
        }

        public void newBill(int empId, int projId, int rate, int hours)
        {
            bill = new Bill(empId, projId, rate, hours);
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
                new Client(2, new DateTime(2022,1,2), new DateTime(2023,4,4), true, "Tyler with projects", "This is a test client with projects"),
                new Client(3),
                new Client(4),
                new Client(5),
                new Client(6)
            };

            patrons[1].Projects.Add(new Project(1, new DateTime(2021, 1, 1), new DateTime(2021, 1, 1), true, "Project 1", "This is a test project", 1));


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

        public void expand(Client temp)
        {
            //returns an expanded string reprisentation of the Client object
            Console.WriteLine($"[{temp.Id}] {temp.Name} \r\n{temp.OpenDate} {temp.IsActive} \r\n{temp.Notes}");
            
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
               
                if (projectToAdd.ClientId.Count != 0)
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
        
        public Project GetById(int id)
        {
            return projects.FirstOrDefault(p => p.Id == id);
        }   
    }

    public class EmployeeService
    {
        //identical to ClientService but employees
        private static EmployeeService? _instance;
        private static object _lock = new object();
        public static EmployeeService Current
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new EmployeeService();
                    }
                    return _instance;
                }
            }
        }
        public EmployeeService()
        {
            employees = new List<Employee>
            {
                new Employee(1, 20, "John Doe"),
                new Employee(2),
                new Employee(3),
                new Employee(4),
                new Employee(5),
                new Employee(6)
            };

        }
        private List<Employee> employees;

        public List<Employee> GetAll
        {
            get { return employees; }
        }

        public Employee Get(int id)
        {
            return employees.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Employee employeeToAdd)
        {
            if (employeeToAdd != null)
            {
                employees.Add(employeeToAdd);
            }
        }
        public void Update(Employee employeeToUpdate)
        {

        }
        public void Delete(int id)
        {
            var employeeToRemove = Get(id);
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
            }
        }
        //Search function that searches by name
        public List<Employee> Search(string Query)
        {
            return employees.Where(p => p.Name.ToUpper().Contains(Query.ToUpper())).ToList();
        }

        public Employee GetById(int id)
        {
            return employees.FirstOrDefault(p => p.Id == id);
        }
    }   
    public class Employee
    {
        public int Id { get; set; }
        public decimal Rate { get; set; }
        public string Name { get; set; }
        public Employee(int id = 0, decimal rate = 0, string name = "")
        {
            Id = id;
            Rate = rate;
            Name = name;
        }

        //to string override
        public override string ToString()
        {
            return $"Employee Id:[{Id}]   {Name},   {Rate}";
        }

    }

    //class to represent ime used to work on a project
    public class Time
    {
        public DateTime Date { get; set; }
        public string Narrative { get; set; }
        public decimal Hours { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public int Rate { get; set; }
        public Time(DateTime date = new DateTime(), string narrative = "", decimal hours = 0, int projectId = 0, int employeeId = 0)
        {
            Date = date;
            Narrative = narrative;
            Hours = hours;
            ProjectId = projectId;
            EmployeeId = employeeId;
            Rate = 0;
        }
    }

    public class Bill
    {
        public int employeeId { get; set; }
        public int projectId { get; set; }
        public decimal hours { get; set; }
        public decimal rate { get; set; }
        public decimal total { get; set; }

        public DateTime dueDate { get; set; }
        public Bill(int employeeId = 0, int projectId = 0, decimal hours = 0, decimal rate = 0, DateTime dueDate = default)
        {
            this.employeeId = employeeId;
            this.projectId = projectId;
            this.hours = hours;
            this.rate = rate;
            this.total = hours * rate;
            this.dueDate = dueDate;
        }
        public decimal calculateTotal()
        {
            return hours * rate;
        }

        //tostring
        public override string ToString()
        {
            return $"Hours:[{hours}]   Rate:[{rate}]   Total:[{total}]  Due Date:{dueDate}";
        }
    }
    


}
