using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class Address
    {

        public Guid _IdAddress { get; set; }


        public Guid IdAddress
        {

            get
            {
                return _IdAddress;
            }

            set
            {
                _IdAddress = value;
            }
        }

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

        private int _Number { get; set; }


        public int Number
        {

            get
            {
                return _Number;
            }

            set
            {
                _Number = value;
            }
        }


        private string _City { get; set; }


        public string City
        {

            get
            {
                return _City;
            }

            set
            {
                _City = value;
            }
        }

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
