using Microsoft.Data.SqlClient;

namespace DataBaseForms
{
    public partial class FormAddArtist : Form
    {
        public FormAddArtist()
        {
            InitializeComponent();
        }

        private void buttonCancelAddArtist_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAddArtist_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == String.Empty
                    || textBoxStageName.Text == String.Empty
                    || comboBoxGroupName.Text == String.Empty
                    || textBoxCity.Text == String.Empty
                    || textBoxStyle.Text == String.Empty)
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                AddRecord(new string[]
                {
                    textBoxName.Text,
                    textBoxStageName.Text,
                    comboBoxGroupName.Text,
                    textBoxCity.Text,
                    textBoxStyle.Text
                });
                MessageBox.Show("Запись успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void AddRecord(string[] cellsContent)
        {
            string[] fullName = cellsContent[0].Split(' ');
            int groupId = GetGroupId(cellsContent[2]);
            string queryString = $"INSERT tblArtist VALUES " +
                $"('{fullName[0]}', '{fullName[1]}', '{cellsContent[1]}', {groupId}, {150000});";
            var query = new SqlCommand(queryString, FormsHelper.DataBase.Connection);
            query.ExecuteNonQuery();
        }

        private int GetGroupId(string groupName)
        {
            string queryString = $"SELECT intArtistGroupId from tblArtistGroup " +
                $"WHERE (txtGroupName = '{groupName}');";
            var query = new SqlCommand(queryString, FormsHelper.DataBase.Connection);
            var reader = query.ExecuteReader();
            reader.Read();
            var groupId = reader.GetInt32(0);
            reader.Close();
            return groupId;
        }

        private void FormAddArtist_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT txtGroupName from tblArtistGroup";
            var query = new SqlCommand(queryString, FormsHelper.DataBase.Connection);
            var reader = query.ExecuteReader();

            comboBoxGroupName.Items.Clear();
            
            while (reader.Read())
                comboBoxGroupName.Items.Add(reader.GetString(0));

            reader.Close();
        }

        private void comboBoxGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string queryString = $"SELECT txtGroupCity from tblArtistGroup " +
                $"WHERE txtGroupName = '{comboBoxGroupName.Text}'";
            var query = new SqlCommand(queryString, FormsHelper.DataBase.Connection);
            var reader = query.ExecuteReader();

            while (reader.Read())
                textBoxCity.Text = reader.GetString(0);

            textBoxCity.ReadOnly = true;
            reader.Close();
        }
    }
}
