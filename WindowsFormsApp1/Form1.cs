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

            var myQuery = from b in db.Schedule6BuildingData where b.BuildingId.ToString() == textBox1.Text select b;


            //var datasource = from x in db.Schedule6BuildingData select new { x.BuildingName, x.BuildingAddress1, x.City}  ;
            List < Schedule6BuildingData > myBuildings = myQuery.ToList();
         
            dataGridView1.DataSource = myBuildings;

            // Clear databindings

            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();

            // Emd of Clear databindings


            textBox2.DataBindings.Add("Text", myBuildings, "BuildingName");
            textBox3.DataBindings.Add("Text", myBuildings, "BuildingAddress1");
            textBox4.DataBindings.Add("Text", myBuildings, "City");
            textBox5.DataBindings.Add("Text", myBuildings, "BuildingAddress2");
            //textBox2.Text = myBuildings.First();


            var name = "a";    // var bID = buildings.BuildingName;
            //var building = from b in buildings where buildings.BuildingId.ToString() == textBox1.Text select b;

            //var x = 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
