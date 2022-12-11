using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class Customer
    {
        public Guid IdCustomer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Doc { get; set; }
        public Address Address { get; set; }

        public Customer()
        {

        }

        public Customer( string FirstName, string LastName, DateTime DateBirth, string Doc, Address Address, Guid? IdCustomer)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateBirth = DateBirth;
            this.Doc = Doc;
            this.Address = Address;

        }
    }
}
