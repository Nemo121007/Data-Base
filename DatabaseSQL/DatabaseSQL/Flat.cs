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
    public partial class Flat : Form
    {
        public Flat(string txtAdress, string owner, string storey, string area, string count)
        {
            InitializeComponent();
            textBoxAdress.Text = txtAdress;
            textBoxOwner.Text = owner;
            textBoxStorey.Text = storey;
            textBoxArea.Text = area;
            textBoxCount.Text = count;
            CreateTable();
            WriteTable();
        }

        private void CreateTable()
        {
            dataGridViewWorksTable.Columns.Add("datOperationDate", "Дата");
            dataGridViewWorksTable.Columns.Add("txtOperationTypeName", "Тип работы");
            dataGridViewWorksTable.Columns.Add("txtWorkerName", "Рабочий");
            dataGridViewWorksTable.Columns.Add("txtOperationDescription", "Описание");

            foreach (DataGridViewColumn column in dataGridViewWorksTable.Columns)
                column.ReadOnly = true;

            dataGridViewWorksTable.Columns["datOperationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewWorksTable.Columns["datOperationDate"].MinimumWidth = 50;
            dataGridViewWorksTable.Columns["txtOperationTypeName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewWorksTable.Columns["txtOperationTypeName"].MinimumWidth = 50;
            dataGridViewWorksTable.Columns["txtWorkerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewWorksTable.Columns["txtOperationDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void WriteTable()
        {
            dataGridViewWorksTable.Rows.Clear();

            DataBaseFlats.dataBaseFlats.OpenConnection();

            string query = "Select tblOperation.datOperationDate, tblOperationType.txtOperationTypeName, tblWorker.txtWorkerName, tblWorker.txtWorkerSecondName, tblWorker.txtWorkerSurname,\n" +
                "tblOperation.txtOperationDescription\n" +
                "From ((tblOperation inner join tblFlat on tblOperation.intFlatId = tblFlat.intFlatId)\n" +
                "inner join tblOperationType on tblOperation.intOperationTypeId = tblOperationType.intOperationTypeId)\n" +
                "inner join tblWorker on tblOperation.intWorkerId = tblWorker.intWorkerId\n" +
                "Where (txtFlatAddress = '" + textBoxAdress.Text + "')\n";


            var slqCommand = new SqlCommand(query, DataBaseFlats.dataBaseFlats.Connection);

            var reader = slqCommand.ExecuteReader();

            while (reader.Read())
                LoadData(reader);

            DataBaseFlats.dataBaseFlats.CloseConnection();
        }

        private void LoadData(IDataRecord record)
        {
            dataGridViewWorksTable.Rows.Add(
                record["datOperationDate"].ToString(),
                record["txtOperationTypeName"],
                record["txtWorkerName"].ToString() + " " + record["txtWorkerSecondName"].ToString() + " " + record["txtWorkerSurname"].ToString(),
                record["txtOperationDescription"]
                );
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonNewWork_Click(object sender, EventArgs e)
        {
            var newWork = new NewWork(textBoxAdress.Text, textBoxOwner.Text, textBoxArea.Text);
            Hide();
            newWork.ShowDialog();
            Show();
            WriteTable();
        }
    }
}
