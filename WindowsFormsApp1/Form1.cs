using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           MobileFormsEntities db = new MobileFormsEntities();
           UKPostCodesEntities ukp = new UKPostCodesEntities();

            var myQuery = from b in db.Schedule6BuildingData where b.BuildingId.ToString() == textBox1.Text select b;

            List < Schedule6BuildingData > myBuildings = myQuery.ToList();
         
            dataGridView1.DataSource = myBuildings;

            // Clear databindings

            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox6.DataBindings.Clear();

            textBox2.DataBindings.Add("Text", myBuildings, "BuildingName");
            textBox3.DataBindings.Add("Text", myBuildings, "BuildingAddress1");
            textBox4.DataBindings.Add("Text", myBuildings, "City");
            textBox5.DataBindings.Add("Text", myBuildings, "BuildingAddress2");
            textBox6.DataBindings.Add("Text", myBuildings, "Postcode");
            //textBox2.Text = myBuildings.First();
            var postCodeQuery = from p in ukp.PostCodes where p.postcode1 == textBox6.Text select p;
            List < PostCode > postcode = postCodeQuery.ToList();

            string xyz = "";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
