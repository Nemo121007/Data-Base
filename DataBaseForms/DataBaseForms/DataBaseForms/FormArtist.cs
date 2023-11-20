using Microsoft.Data.SqlClient;

namespace DataBaseForms
{
    public partial class FormArtist : Form
    {
        public FormArtist()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAddConcert_Click(object sender, EventArgs e)
        {
            var formAddConcert = new FormAddConcert();
            Hide();
            formAddConcert.ShowDialog();
            Show();
        }

        private void FormArtist_Load(object sender, EventArgs e)
        {
            ShowArtistInfo();
            GetConcerts(textBoxStageName.Text);
            CreateTable();
            RefreshTable();
        }

        private void ShowArtistInfo()
        {
            textBoxName.Text = FormsHelper.SelectedArtistData[0];
            textBoxStageName.Text = FormsHelper.SelectedArtistData[1];
            textBoxGroupName.Text = FormsHelper.SelectedArtistData[2];
            textBoxCity.Text = FormsHelper.SelectedArtistData[3];
            textBoxStyle.Text = FormsHelper.SelectedArtistData[4];

            textBoxName.ReadOnly = true;
            textBoxStageName.ReadOnly = true;
            textBoxGroupName.ReadOnly = true;
            textBoxCity.ReadOnly = true;
            textBoxStyle.ReadOnly = true;
        }

        private void GetConcerts(string stageName) 
        {
            FormsHelper.SelectedArtistConcerts.Clear();
            var queryString = 
                $"select txtTitle, datConcertDate, txtHallName, txtHallAddress, fltParticipateSum " +
                $"from tblConcert, tblHall, tblParticipate, tblArtist " +
                $"where (tblArtist.txtArtistStageName = '{stageName}' " +
                $"and tblParticipate.intArtistId = tblArtist.intArtistId " +
                $"and tblConcert.intConcertId = tblParticipate.intConcertId " +
                $"and tblHall.intHallId = tblConcert.intHallId);";
            var query = new SqlCommand(queryString, FormsHelper.DataBase.Connection);
            var reader = query.ExecuteReader();

            while (reader.Read())
                FormsHelper.SelectedArtistConcerts.Add(new Concert(
                    reader.GetString(0),
                    reader.GetDateTime(1).ToString("yyyy-MM-dd"),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetDecimal(4)));
            
            reader.Close();
        }

        private void CreateTable()
        {
            tableSelectedArtistConcerts.Columns.Add("txtTitle", "Название концерта");
            tableSelectedArtistConcerts.Columns.Add("datConcertDate", "Дата проведения");
            tableSelectedArtistConcerts.Columns.Add("txtHallName", "Название зала");
            tableSelectedArtistConcerts.Columns.Add("txtHallAddress", "Адрес зала");
            tableSelectedArtistConcerts.Columns.Add("fltParticipateSum", "Гонорар артиста");

            tableSelectedArtistConcerts.Columns["txtTitle"].Width = 190;
            tableSelectedArtistConcerts.Columns["datConcertDate"].Width = 100;
            tableSelectedArtistConcerts.Columns["txtHallName"].Width = 150;
            tableSelectedArtistConcerts.Columns["txtHallAddress"].Width = 300;
            tableSelectedArtistConcerts.Columns["fltParticipateSum"].Width = 80;
        }

        private void RefreshTable()
        {
            tableSelectedArtistConcerts.Rows.Clear();

            foreach (var concert in FormsHelper.SelectedArtistConcerts)
                tableSelectedArtistConcerts.Rows.Add(concert.Name, concert.Date, concert.HallName,
                    concert.HallAddress, concert.ArtistMoney);

            foreach (DataGridViewColumn column in tableSelectedArtistConcerts.Columns)
                column.ReadOnly = true;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            GetConcerts(textBoxStageName.Text);
            RefreshTable();
        }
    }
}
