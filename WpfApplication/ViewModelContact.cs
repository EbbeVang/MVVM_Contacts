using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication.Annotations;

namespace WpfApplication
{
    // extending INotifyPropertyChanged - means that i can notify when things change...
    class ViewModelContact : INotifyPropertyChanged
    {
        // my bindings
        private readonly String _currentContactName = "CurrentContact";
        private readonly String _listOfContacts = "Contacts";

        // my variables
        private ModelContact _currentContact;
        private List<ModelContact> _contacts;
        private ICommand _removeContactCommand;

        // expose a contact to the UI
        public ModelContact CurrentContact
        {
            get
            {
                return _currentContact;
            }
            set
            {
                //  only if user choose a new contact
                if (value != _currentContact)
                {
                    _currentContact = value;
                    OnPropertyChanged(_currentContactName);
                }
            }

        }

        //expose list of contacts to UI
        public ObservableCollection<ModelContact> Contacts
        {
            get
            {
                ObservableCollection<ModelContact> contacts = new ObservableCollection<ModelContact>();
                foreach (var modelContact in _contacts)
                {
                    contacts.Add(modelContact);
                }
                return contacts;
            }
            
        }

        //expose remove contact command
        public ICommand RemoveContact {
            get
            {
                return _removeContactCommand;
            }
        }

        #region automatically added when implementing INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        // ok we cheat - time is runnning and we dont want to write a real data access layer
        // we will generate contacts instead of using a DB
        public ViewModelContact()
        {
            _contacts = new List<ModelContact>()
            {
                new ModelContact(){Firstname = "Ebbe", LastName = "Vang", email = "ebva@easj.dk"},
                new ModelContact(){Firstname = "Mette", LastName = "Vang", email = "mette@vang.dk"},
                new ModelContact(){Firstname = "Thomas", LastName = "Thomasson", email = "Thomas@Thomasson"},
                new ModelContact(){Firstname = "Chris", LastName = "Christopherson", email = "Rubberduck@bandit.dk"}
            };

            Contacts[0].PhoneNumbers = new List<ModelPhoneNumber>()
            {
                new ModelPhoneNumber(){Description = "Home", Number = "12345678"},
                new ModelPhoneNumber(){Description = "Work", Number = "23232323"}

            };

            Contacts[1].PhoneNumbers = new List<ModelPhoneNumber>()
            {
                new ModelPhoneNumber(){Description = "Work", Number = "58491221"},
                new ModelPhoneNumber(){Description = "mobile", Number = "99999999"}
            };


            _currentContact = _contacts[0];

            _removeContactCommand = new RelayCommand(RemoveContactCommand){IsEnabled = true};
        }

        private void RemoveContactCommand()
        {
            _contacts.Remove(_currentContact);
            OnPropertyChanged(_listOfContacts);
        }

    }
}
