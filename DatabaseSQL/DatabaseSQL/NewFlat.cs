using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseSQL
{
    public partial class NewFlat : Form
    {
        public NewFlat()
        {
            InitializeComponent();
        }

        private void buttonAddFlat_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string adress = textBoxAdress.Text;
            string owner = comboBoxOwner.Text;
            Color color = Color.FromArgb(242, 128, 142);
            Color colorTrue = Color.White;
            if (adress == null || adress == "")
            {
                flag = true;
                textBoxAdress.BackColor = color;
            }
            else
                textBoxAdress.BackColor = colorTrue;

            if (!owners.ContainsKey(owner))
            {
                flag = true;
                comboBoxOwner.BackColor = color;
            }
            else
                comboBoxOwner.BackColor = colorTrue;

            if (!int.TryParse(textBoxFloor.Text, out int floor))
            {
                flag = true;
                textBoxFloor.BackColor = color;
            }
            else
                textBoxFloor.BackColor = colorTrue;

            if (!double.TryParse(textBoxArea.Text, out double area))
            {
                flag = true;
                textBoxArea.BackColor = color;
            }
            else
                textBoxArea.BackColor = colorTrue;

            if (!int.TryParse(textBoxCount.Text, out int count))
            {
                flag = true;
                textBoxCount.BackColor = color;
            }
            else
                textBoxCount.BackColor = colorTrue;

            if (!flag)
            {
                DataBaseFlats.dataBaseFlats.OpenConnection();

                string query = "Insert tblFlat(txtFlatAddress, intOwnerId, fltArea, intCount, intStorey)\n" +
                        "Values('" + adress + "', " + owners[owner] + ", " + area.ToString() + ", " + count.ToString() + ", " + floor.ToString() + ")";

                var slqCommand = new SqlCommand(query, DataBaseFlats.dataBaseFlats.Connection);

                var writer = slqCommand.ExecuteNonQuery();

                DataBaseFlats.dataBaseFlats.CloseConnection();

                Close();
            }
        }

        public static Dictionary<string, int> owners 
            = DataBaseFlats.ListObject_Id(
            "Select intOwnerId, (txtOwnerSurname + ' ' + txtOwnerName + ' ' + txtOwnerSecondName) as txtOwner\n" +
            "From tblOwner",
            
            "txtOwner", "intOwnerId"
            );

        //public static Dictionary<string, int> owners = ListOwner();

        //private static Dictionary<string, int> ListOwner()
        //{
        //    var list = new Dictionary<string, int>();

        //    DataBaseFlats.dataBaseFlats.OpenConnection();

        //    string query = "Select intOwnerId, (txtOwnerSurname + ' ' + txtOwnerName + ' ' + txtOwnerSecondName) as txtOwner\n" +
        //                    "From tblOwner";

        //    var slqCommand = new SqlCommand(query, DataBaseFlats.dataBaseFlats.Connection);

        //    var reader = slqCommand.ExecuteReader();

        //    while (reader.Read())
        //        list.Add(reader["txtOwner"].ToString(), Convert.ToInt32(reader["intOwnerId"]));

        //    DataBaseFlats.dataBaseFlats.CloseConnection();

        //    return list;
        //}

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxOwner.BackColor = Color.White;
        }

        private void textBoxAdress_TextChanged(object sender, EventArgs e)
        {
            textBoxAdress.BackColor = Color.White;
        }

        private void textBoxFloor_TextChanged(object sender, EventArgs e)
        {
            textBoxFloor.BackColor = Color.White;
        }

        private void textBoxArea_TextChanged(object sender, EventArgs e)
        {
            textBoxArea.BackColor = Color.White;
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            textBoxCount.BackColor = Color.White;
        }
    }
}
