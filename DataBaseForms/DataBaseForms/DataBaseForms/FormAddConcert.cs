using Microsoft.Data.SqlClient;

namespace DataBaseForms
{
    public partial class FormAddConcert : Form
    {
        public FormAddConcert()
        {
            InitializeComponent();
        }

        private void buttonAddConcert_Click(object sender, EventArgs e)
        {
            if (comboBoxConcertName.Text.Length == 0
                    || textBoxSongName.Text.Length == 0
                    || textBoxMoney.Text.Length == 0)
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (IsNumberFree((int)numericUpDownSerialNumber.Value))
                {
                    if (numericUpDownSerialNumber.Value > 0)
                    {
                        if (IsConcertFree(comboBoxConcertName.Text)) 
                        {
                            AddRecord();
                            MessageBox.Show("Запись успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                            MessageBox.Show("Артист уже участвует в этом концерте!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Порядковый номер должен быть больше нуля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Порядковый номер занят, выберите другой!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsConcertFree(string concertName)
        {
            foreach (var concert in FormsHelper.SelectedArtistConcerts)
                if (concert.Name == concertName)
                    return false;
            return true;
        }

        private bool IsNumberFree(int number)
        {
            string queryString = $"SELECT intNumber FROM tblParticipate, tblConcert " +
                $"WHERE (tblConcert.txtTitle = '{comboBoxConcertName.Text}' " +
                $"and tblParticipate.intConcertId = tblConcert.intConcertId);";
            var query = new SqlCommand(queryString, FormsHelper.DataBase.Connection);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
                if (reader.GetInt32(0) == number)
                {
                    reader.Close();
                    return false;
                }
            reader.Close();
            return true;
        }

        private void AddRecord()
        {
            string queryString = $"SELECT intArtistId, intConcertId FROM tblArtist, tblConcert " +
                $"WHERE (tblArtist.txtArtistStageName = '{textBoxStageName.Text}' " +
                $"and tblConcert.txtTitle = '{comboBoxConcertName.Text}')";
            var query = new SqlCommand(queryString, FormsHelper.DataBase.Connection);
            var reader = query.ExecuteReader();
            reader.Read();
            int artistId = reader.GetInt32(0);
            int concertId = reader.GetInt32(1);
            reader.Close();
            queryString = $"INSERT tblParticipate VALUES " +
                $"({artistId}, {concertId}, {Convert.ToDecimal(textBoxMoney.Text)}, " +
                $"'{textBoxSongName.Text}', '{numericUpDownSerialNumber.Value}');";
            query = new SqlCommand(queryString, FormsHelper.DataBase.Connection);
            query.ExecuteNonQuery();
        }

        private void buttonCancelAddConcert_Click(object sender, EventArgs e)
        {
            Close();
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

        private void FormAddConcert_Load(object sender, EventArgs e)
        {
            ShowArtistInfo();
            string queryString = "SELECT txtTitle FROM tblConcert";
            var query = new SqlCommand(queryString, FormsHelper.DataBase.Connection);
            comboBoxConcertName.Items.Clear();
            var reader = query.ExecuteReader();

            while (reader.Read())
                comboBoxConcertName.Items.Add(reader.GetString(0));

            reader.Close();
        }
    }
}