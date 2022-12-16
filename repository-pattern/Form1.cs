using DAL.Contracts;
using DAL.Repositories.SqlServer;
using DOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace repository_pattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IGenericRepository<Address> genericRespository = new AddressRespository();

            Guid id = Guid.Parse(textBox9.Text);

            Address address = genericRespository.GetOne(id);

            textBox1.Text = address.Street;
            textBox11.Text = address.Number.ToString();
            textBox12.Text = address.City;



        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            IGenericRepository<Address> genericRespository = new AddressRespository();
            
            Address address = new Address();
            address.Street = Convert.ToString(textBox2.Text);
            address.Number = Int32.Parse(textBox3.Text);
            address.City = Convert.ToString(textBox4.Text);

            genericRespository.Insert(address);
                        


        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            IGenericRepository<Address> genericRepository = new AddressRespository();

            Address address = new Address();
            address.IdAddress = Guid.Parse(textBox5.Text);
            address.Street = Convert.ToString(textBox6.Text);
            address.Number = Int32.Parse(textBox7.Text);
            address.City = Convert.ToString(textBox8.Text);

            genericRepository.Update(address);
        }
    }
}
