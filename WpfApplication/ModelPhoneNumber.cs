using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication
{
    class ModelPhoneNumber
    {
        private string _description;
        private string _number;

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public String Number
        {
            get { return _number; }
            set { _number = value; }
        }
    }
}
