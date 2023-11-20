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
using Database;

namespace DatabaseSQL
{
    public partial class Flats : Form
    {
        public Flats()
        {
            InitializeComponent();
        }

        #region Content
        private void CreateTable()
        {
            dataTable.Columns.Add("txtFlatAddress", "Адрес");
            dataTable.Columns.Add("txtName", "Имя");
            dataTable.Columns.Add("intStorey", "Этаж");
            dataTable.Columns.Add("fltArea", "Площадь");
            dataTable.Columns.Add("intCount", "Жильцы");

            foreach (DataGridViewColumn column in dataTable.Columns)
                column.ReadOnly = true;

            dataTable.Columns["txtFlatAddress"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataTable.Columns["txtFlatAddress"].MinimumWidth = 50;
            dataTable.Columns["txtName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataTable.Columns["txtName"].MinimumWidth = 50;
            dataTable.Columns["intStorey"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataTable.Columns["fltArea"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataTable.Columns["intCount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void WriteTable()
        {
            dataTable.Rows.Clear();

            DataBaseFlats.dataBaseFlats.OpenConnection();

            string query = "Select tblFlat.intFlatId, tblFlat.txtFlatAddress, tblOwner.txtOwnerName, tblOwner.txtOwnerSecondName, tblOwner.txtOwnerSurname,\n" +
                "tblFlat.intStorey, tblFlat.fltArea, tblFlat.intCount\n" +
                "From tblFlat inner join tblOwner on tblFlat.intOwnerId = tblOwner.intOwnerId";


            var slqCommand = new SqlCommand(query, DataBaseFlats.dataBaseFlats.Connection);

            var reader = slqCommand.ExecuteReader();

            while (reader.Read())
                LoadData(reader);

            DataBaseFlats.dataBaseFlats.CloseConnection();
        }

        private void LoadData(IDataRecord record)
        {
            dataTable.Rows.Add(
                record["txtFlatAddress"].ToString(),
                record["txtOwnerName"].ToString() + " " + record["txtOwnerSecondName"].ToString() + " " + record["txtOwnerSurname"].ToString(),
                record["intStorey"],
                record["fltArea"],
                record["intCount"]
                );
        }
        #endregion Content

        private void newFlatButton_Click(object sender, EventArgs e)
        {
            var newFlat = new NewFlat();
            Hide();
            newFlat.ShowDialog();
            Show();
            WriteTable();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var Flat = new Flat(dataTable["txtFlatAddress", e.RowIndex].Value.ToString(),
                                dataTable["txtName", e.RowIndex].Value.ToString(),
                                dataTable["intStorey", e.RowIndex].Value.ToString(),
                                dataTable["fltArea", e.RowIndex].Value.ToString(),
                                dataTable["intCount", e.RowIndex].Value.ToString()
                                );
            Hide();
            Flat.ShowDialog();
            Show();
        }

        private void Flats_Load(object sender, EventArgs e)
        {
            CreateTable();
            WriteTable();
        }
    }
}