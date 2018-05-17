using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismTest1.Business
{
    public class Person : INotifyPropertyChanged, IDataErrorInfo
    {

        #region Properties
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private DateTime? _lastUpdated;
        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
            set
            {
                _lastUpdated = value;
                OnPropertyChanged(nameof(LastUpdated));
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region IDataErrorInfo

        private string _Error;
        public string Error {
            get { return _Error; }
            private set
            {
                _Error = value;
                OnPropertyChanged("Error");
            }
        }

        public string this[string columnName] {
            get {
                string error = null;

                switch (columnName)
                {
                    case nameof(FirstName):
                        if (string.IsNullOrEmpty(FirstName)) error = "First Name required";
                        break;
                    case nameof(LastName):
                        if (string.IsNullOrEmpty(LastName)) error = "Last Name required";
                        break;
                    case nameof(Age):
                        if (Age < 18 || Age > 85) error = "Age out of range";
                        break;
                }

                Error = error;
                return (Error);
            }
        }


        #endregion

    }
}
