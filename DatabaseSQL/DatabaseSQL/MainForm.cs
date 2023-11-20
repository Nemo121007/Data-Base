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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonTable_Click(object sender, EventArgs e)
        {
            var FlatsForms = new Flats();
            Hide();
            FlatsForms.ShowDialog();
            Show();
        }

        private void buttonRerortWorkers_Click(object sender, EventArgs e)
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
                        string selectedPath = folderBrowserDialog.SelectedPath + "\\ReportWorkers.pdf";
                        // Делаем что-то с выбранной папкой
                        WriteReportWorker.Write(selectedPath);
                        MessageBox.Show("Отчёт успешно создан", selectedPath, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка записи отчёта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonRerortRepair_Click(object sender, EventArgs e)
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
                        string selectedPath = folderBrowserDialog.SelectedPath + "\\ReportRepairs.pdf";
                        // Делаем что-то с выбранной папкой
                        WriteReportRepair.Write(selectedPath);
                        MessageBox.Show("Отчёт успешно создан", selectedPath, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка записи отчёта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonRerortOperation_Click(object sender, EventArgs e)
        {
            var operationTypes = new ChouseTypeWork();
            operationTypes.ShowDialog();
        }
    }
}
