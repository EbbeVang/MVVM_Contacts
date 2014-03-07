using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication
{
    /// <summary>
    /// This is the model example in this small MVVM example
    /// </summary>
    class ModelContact
    {
        private string _firstname;
        private string _lastname;
        private string _email;

        public String Firstname 
        { 
            get { return _firstname; }
            set { _firstname = value; } 
        }

        public String LastName 
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public String email {
            get { return _email; }
            set
            {
                if (value.Contains("@")) _email = value;
            }
        }
    }
}
