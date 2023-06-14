using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PracticePanther.MAUI.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
       //implement NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Client> Clients { get; set; }

        public void fill()
        {
            //adds to Clients through singleton
            Clients.Add(Client.Instance);

        }
      

    }
}
