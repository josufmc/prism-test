using Prism.Commands;
using PrismTest1.Business;
using PrismTest1.Infrastructure;
using PrismTest1.People.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismTest1.People.ViewModels
{
    public class PersonViewModel : ViewModelBase, IPersonViewModel
    {

        private Person _person;
        public Person Person { 
            get { return _person; } 
            set {
                _person = value;
                _person.PropertyChanged += _person_PropertyChanged;
                OnPropertyChanged(nameof(Person));
            }
        }

        private void _person_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }


        public DelegateCommand<object> SaveCommand { get; set; }

        public PersonViewModel(IPersonView view) : base(view)
        {
            CreatePerson();
            SaveCommand = new DelegateCommand<object>(Save, CanSave);
        }

        private bool CanSave(object value)
        {
            return Person.Error == null;
        }

        private void Save(object value)
        {
            Person.LastUpdated = DateTime.Now.AddYears(Convert.ToInt32(value));
        }

        private void CreatePerson()
        {
            Person = new Person()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Age = 46
            };
        }


    }
}
