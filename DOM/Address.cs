using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class Address
    {

        public Guid IdAddress { get; set; }

        private string _Street;
       

        public string Street 
        {

            get
            {
                return _Street;
            }

            set
            {
                _Street = value;
            }
        }

        private int Number { get; set; }


        private string City { get; set; }

        
        public Address()
        {

        }

        public Address(Guid IdAddress, string Street, int Number, string City)
        {
            this.IdAddress = IdAddress;
            this.Street = Street;
            this.Number = Number;
            this.City = City;
        }

    }
}
