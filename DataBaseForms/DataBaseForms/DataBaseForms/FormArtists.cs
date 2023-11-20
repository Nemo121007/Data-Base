using Microsoft.Data.SqlClient;
using System.Data;

namespace DataBaseForms
{
    public partial class FormArtists : Form
    {
        public FormArtists()
        {
            InitializeComponent();
        }
        
        private void buttonAddArtist_Click(object sender, EventArgs e)
        {
            var formAddArtist = new FormAddArtist();
            Hide();
            formAddArtist.ShowDialog();
            Show();
        }

        private void tableArtists_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                var list = new List<string>();
                var formArtist = new FormArtist();

                for (int i = 0; i < 5; i++)
                    list.Add(tableArtists[i, e.RowIndex].Value.ToString());

                FormsHelper.SelectedArtistData = list.ToArray();
                Hide();
                formArtist.ShowDialog();
                Show();
            }
        }

        private void CreateTable()
        {
            tableArtists.Columns.Add("txtArtistSurnameAndName", "Фамилия и имя");
            tableArtists.Columns.Add("txtArtistStageName", "Псевдоним");
            tableArtists.Columns.Add("txtArtistGroupName", "Название коллектива");
            tableArtists.Columns.Add("txtArtistCity", "Город");
            tableArtists.Columns.Add("txtArtistStyle", "Стиль");

            foreach (DataGridViewColumn column in tableArtists.Columns)
                column.ReadOnly = true;

            tableArtists.Columns["txtArtistSurnameAndName"].Width = 200;
            tableArtists.Columns["txtArtistCity"].Width = 200;
            tableArtists.Columns["txtArtistStageName"].Width += 25;
            tableArtists.Columns["txtArtistGroupName"].Width += 25;
        }

        private void LoadRow(DataGridView table, IDataRecord dataRecord)
        {
            table.Rows.Add(dataRecord.GetString(0), dataRecord.GetString(1),
                dataRecord.GetString(2), dataRecord.GetString(3), dataRecord.GetString(4));
        }

        private void RefreshTable(DataGridView table)
        {
            table.Rows.Clear();

            var queryString = "select txtArtistSurname + ' ' + txtArtistName, txtArtistStageName, " +
                "txtGroupName, \r\ntxtGroupCity, txtGroupStyle from tblArtist, tblArtistGroup\r\n" +
                "where (tblArtist.intArtistGroupId = tblArtistGroup.intArtistGroupId);";
            var query = new SqlCommand(queryString, FormsHelper.DataBase.Connection);
            FormsHelper.DataBase.OpenConnection();

            var reader = query.ExecuteReader();

            while (reader.Read())
                LoadRow(table, reader);

            reader.Close();
        }

        private void FormArtists_Load(object sender, EventArgs e)
        {
            CreateTable();
            RefreshTable(tableArtists);
        }

        private void FormArtists_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormsHelper.DataBase.CloseConnection();
        }

        private void buttonRefreshTable_Click(object sender, EventArgs e)
        {
            RefreshTable(tableArtists);
        }
    }
}