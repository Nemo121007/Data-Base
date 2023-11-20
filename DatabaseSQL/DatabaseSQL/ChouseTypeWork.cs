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
    public partial class ChouseTypeWork : Form
    {
        public ChouseTypeWork()
        {
            InitializeComponent();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.Text != "")
            {
                try
                {
                    using (var folderBrowserDialog = new FolderBrowserDialog())
                    {
                        // Задаем заголовок диалогового окна
                        folderBrowserDialog.Description = "Выберите папку для сохранения данных";

                        // Отображаем диалоговое окно и проверяем, что пользователь выбрал папку
                        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Выбранная папка доступна через свойство SelectedPath
                            string selectedPath = folderBrowserDialog.SelectedPath + "\\ReportOperation.pdf";
                            // Делаем что-то с выбранной папкой
                            WriteReportOperation.Write(selectedPath, listOperationTypes[comboBox.Text]);
                            MessageBox.Show("Отчёт успешно создан", selectedPath, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка записи отчёта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Close();
            }
        }

        public static Dictionary<string, int> listOperationTypes
            = DataBaseFlats.ListObject_Id(
                    "Select txtOperationTypeName, intOperationTypeId\n" +
                    "From tblOperationType",
                    "txtOperationTypeName", "intOperationTypeId"
        );
    }
}
