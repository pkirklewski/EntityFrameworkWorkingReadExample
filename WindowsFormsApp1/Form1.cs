﻿using System;
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
            if (checkBox1.Checked == true) {
            checkBox1.Checked = false;
                button2.Enabled = false;
                checkBox1.Refresh();
                button2.Refresh();

            }



            dataGridView1.Refresh();
            dataGridView2.Refresh();


            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox6.DataBindings.Clear();
            textBox7.DataBindings.Clear();
            textBox8.DataBindings.Clear();

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";



            button2.Refresh();

            button2.Enabled = false;
           MobileFormsEntities db = new MobileFormsEntities();
           UKPostCodesEntities ukp = new UKPostCodesEntities();



            try
            {
            // Getting building INFO from MobileForms Schedule6 table
            var myQuery = from b in db.Schedule6BuildingData where b.BuildingId.ToString() == textBox1.Text select b;
            List < Schedule6BuildingData > myBuildings = myQuery.ToList();
            dataGridView1.DataSource = myBuildings;
                // END OF:  // Getting building INFO from MobileForms Schedule6 table

                textBox2.DataBindings.Add("Text", myBuildings, "BuildingName");
                textBox3.DataBindings.Add("Text", myBuildings, "BuildingAddress1");
                textBox4.DataBindings.Add("Text", myBuildings, "City");
                textBox5.DataBindings.Add("Text", myBuildings, "BuildingAddress2");
                textBox6.DataBindings.Add("Text", myBuildings, "Postcode");

            }
            catch (Exception)
            {

                throw;
            }


            
            // Getting latitude and longitude from UKPostCodes

            // END OF: Getting latitude and longitude from UKPostCodes


            // Clear databindings




            //textBox2.Text = myBuildings.First();

            textBox3.Text = textBox3.Text + " " + textBox5.Text;


            var postCodeQuery = from p in ukp.PostCodes where p.postcode1 == textBox6.Text select p;
            List < PostCode > postcode = postCodeQuery.ToList();
            dataGridView2.DataSource = postcode;

            textBox7.DataBindings.Add("Text", postcode, "latitude");
            textBox8.DataBindings.Add("Text", postcode, "longitude");

      


            if  (textBox7.Text != "" && textBox7.Text != "")
            {
                checkBox1.Visible = true;
                button2.Visible = true;
            }

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

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button2.Visible = false;
            checkBox1.Visible = false;
            textBox5.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PropertyPortalEntities ppe = new PropertyPortalEntities();
            var newBuilding = new Building();
            newBuilding.Reference = Convert.ToInt32(textBox1.Text);
            newBuilding.Name = textBox2.Text;
            newBuilding.Address = textBox3.Text  + " " + textBox5.Text;
            newBuilding.Town = textBox4.Text;
            newBuilding.PostCode = textBox6.Text;
            newBuilding.Latitude = Convert.ToDouble(textBox7.Text);
            newBuilding.Longitude =  Convert.ToDouble(textBox8.Text);
            newBuilding.Contract = "DWP";

            string displayText = "Building " + textBox1.Text + " saved.";

            using (var ppb = new PropertyPortalEntities())
            {
                try
                {
                    ppb.Buildings.Add(newBuilding);
                   // ppb.SaveChanges();

                    if (ppb.SaveChanges() > 0) {
                        MessageBox.Show(displayText, "BUILDING SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex) {
                    MessageBox.Show(ex.InnerException.ToString(), "ERROR !",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                    
                


            }


        }
    }
}
