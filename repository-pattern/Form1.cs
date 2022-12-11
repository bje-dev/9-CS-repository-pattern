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

            Guid id = Guid.Parse("d93bb4e5-a783-43d2-8f9c-acc439f10e8a");

            Address address = genericRespository.GetOne(id);

            textBox1.Text = address.Street;


        }
    }
}
