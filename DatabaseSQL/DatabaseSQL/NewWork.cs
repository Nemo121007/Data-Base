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
    public partial class NewWork : Form
    {
        public NewWork(string adress, string owner, string area)
        {
            InitializeComponent();
            textBoxAdress.Text = adress;
            textBoxOwner.Text = owner;
            textBoxArea.Text = area;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAddNewWork_Click(object sender, EventArgs e)
        {
            bool flag = false;
            var datefull = dateTimePicker.Value.Date;
            string date = "'" + datefull.Year.ToString() + "-" + datefull.Month.ToString() + "-" + datefull.Day.ToString() + "'";
            string typeWork = comboBoxTypeWork.Text;
            string worker = comboBoxWorker.Text;
            string description = textBoxDescription.Text;
            Color colotTrue = Color.White;
            Color colorFalse = Color.FromArgb(242, 128, 142);
            int idTypeWork = 0;
            int idWorker = 0;

            if (!TypeWorks.ContainsKey(typeWork))
            {
                flag = true;
                comboBoxTypeWork.BackColor = colorFalse;
            }
            else
            {
                idTypeWork = TypeWorks[typeWork];
                comboBoxTypeWork.BackColor = colotTrue;
            }

            if (!Worker.ContainsKey(worker))
            {
                flag = true;
                comboBoxWorker.BackColor = colorFalse;
            }
            else
            {
                idWorker = Worker[worker];
                comboBoxWorker.BackColor = colotTrue;
            }
            if (description == null || description == "")
                description = "";

            if (!flag)
            {
                DataBaseFlats.dataBaseFlats.OpenConnection();

                var query = "Insert tblOperation(intFlatId, intOperationTypeId, datOperationDate, intWorkerId, txtOperationDescription)\r\n" +
                    "Values (\n" +
                        "(Select intFlatId\n" +
                        "From tblFlat\n" +
                        "Where txtFlatAddress = '" + textBoxAdress.Text + "'),\n" +
                    idTypeWork.ToString() + ", \n" +
                    date + ", \n" +
                    idWorker.ToString() +  ", \n" +
                    "'" + description + "')";

                var slqCommand = new SqlCommand(query, DataBaseFlats.dataBaseFlats.Connection);

                var writer = slqCommand.ExecuteNonQuery();

                DataBaseFlats.dataBaseFlats.CloseConnection();

                Close();
            }
        }

        private Dictionary<string, int> TypeWorks = DataBaseFlats.ListObject_Id("Select intOperationTypeId, txtOperationTypeName\r\n" +
            "From tblOperationType",

            "txtOperationTypeName", "intOperationTypeId");
        private Dictionary<string, int> Worker = DataBaseFlats.ListObject_Id("Select intWorkerId,\n" +
            "(txtWorkerName + ' ' + txtWorkerSecondName + ' ' + txtWorkerSurname) as txtWorkerName\r\n" +
            "From tblWorker",

            "txtWorkerName", "intWorkerId");

        private void comboBoxTypeWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTypeWork.BackColor = Color.White;
        }

        private void comboBoxWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxWorker.BackColor = Color.White;
        }
    }
}
