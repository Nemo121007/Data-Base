using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace DatabaseSQL
{
    partial class NewFlat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTable = new System.Windows.Forms.TableLayoutPanel();
            this.upPanel = new System.Windows.Forms.Label();
            this.downPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddFlat = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelAdress = new System.Windows.Forms.Label();
            this.labelFloor = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelOwner = new System.Windows.Forms.Label();
            this.labelArea = new System.Windows.Forms.Label();
            this.comboBoxOwner = new System.Windows.Forms.ComboBox();
            this.textBoxFloor = new System.Windows.Forms.TextBox();
            this.textBoxArea = new System.Windows.Forms.TextBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxAdress = new System.Windows.Forms.TextBox();
            this.mainTable.SuspendLayout();
            this.downPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTable
            // 
            this.mainTable.ColumnCount = 1;
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTable.Controls.Add(this.upPanel, 0, 0);
            this.mainTable.Controls.Add(this.downPanel, 0, 2);
            this.mainTable.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.mainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTable.Location = new System.Drawing.Point(0, 0);
            this.mainTable.Margin = new System.Windows.Forms.Padding(0);
            this.mainTable.Name = "mainTable";
            this.mainTable.RowCount = 3;
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainTable.Size = new System.Drawing.Size(782, 453);
            this.mainTable.TabIndex = 0;
            // 
            // upPanel
            // 
            this.upPanel.AutoSize = true;
            this.upPanel.BackColor = System.Drawing.Color.Aqua;
            this.upPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upPanel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.upPanel.Location = new System.Drawing.Point(0, 0);
            this.upPanel.Margin = new System.Windows.Forms.Padding(0);
            this.upPanel.Name = "upPanel";
            this.upPanel.Size = new System.Drawing.Size(782, 50);
            this.upPanel.TabIndex = 0;
            this.upPanel.Text = "Новая квартира";
            this.upPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // downPanel
            // 
            this.downPanel.ColumnCount = 2;
            this.downPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.downPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.downPanel.Controls.Add(this.buttonAddFlat, 0, 0);
            this.downPanel.Controls.Add(this.buttonCancel, 1, 0);
            this.downPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downPanel.Location = new System.Drawing.Point(0, 403);
            this.downPanel.Margin = new System.Windows.Forms.Padding(0);
            this.downPanel.Name = "downPanel";
            this.downPanel.RowCount = 1;
            this.downPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.downPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.downPanel.Size = new System.Drawing.Size(782, 50);
            this.downPanel.TabIndex = 1;
            // 
            // buttonAddFlat
            // 
            this.buttonAddFlat.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonAddFlat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddFlat.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddFlat.Location = new System.Drawing.Point(0, 0);
            this.buttonAddFlat.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddFlat.Name = "buttonAddFlat";
            this.buttonAddFlat.Size = new System.Drawing.Size(391, 50);
            this.buttonAddFlat.TabIndex = 0;
            this.buttonAddFlat.Text = "Добавить квартиру";
            this.buttonAddFlat.UseVisualStyleBackColor = false;
            this.buttonAddFlat.Click += new System.EventHandler(this.buttonAddFlat_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.MediumBlue;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(391, 0);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(391, 50);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.labelAdress, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelFloor, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelCount, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelOwner, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelArea, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxOwner, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFloor, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxArea, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCount, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAdress, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 353);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // labelAdress
            // 
            this.labelAdress.AutoSize = true;
            this.labelAdress.BackColor = System.Drawing.Color.Aquamarine;
            this.labelAdress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAdress.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAdress.Location = new System.Drawing.Point(0, 0);
            this.labelAdress.Margin = new System.Windows.Forms.Padding(0);
            this.labelAdress.Name = "labelAdress";
            this.labelAdress.Size = new System.Drawing.Size(234, 70);
            this.labelAdress.TabIndex = 0;
            this.labelAdress.Text = "Адрес";
            this.labelAdress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFloor
            // 
            this.labelFloor.AutoSize = true;
            this.labelFloor.BackColor = System.Drawing.Color.Aquamarine;
            this.labelFloor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFloor.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFloor.Location = new System.Drawing.Point(0, 140);
            this.labelFloor.Margin = new System.Windows.Forms.Padding(0);
            this.labelFloor.Name = "labelFloor";
            this.labelFloor.Size = new System.Drawing.Size(234, 70);
            this.labelFloor.TabIndex = 1;
            this.labelFloor.Text = "Этаж";
            this.labelFloor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.BackColor = System.Drawing.Color.Aquamarine;
            this.labelCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCount.Location = new System.Drawing.Point(0, 280);
            this.labelCount.Margin = new System.Windows.Forms.Padding(0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(234, 73);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Жильцы";
            this.labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOwner
            // 
            this.labelOwner.AutoSize = true;
            this.labelOwner.BackColor = System.Drawing.Color.Turquoise;
            this.labelOwner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOwner.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelOwner.Location = new System.Drawing.Point(0, 70);
            this.labelOwner.Margin = new System.Windows.Forms.Padding(0);
            this.labelOwner.Name = "labelOwner";
            this.labelOwner.Size = new System.Drawing.Size(234, 70);
            this.labelOwner.TabIndex = 3;
            this.labelOwner.Text = " Владелец";
            this.labelOwner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.BackColor = System.Drawing.Color.Turquoise;
            this.labelArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelArea.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelArea.Location = new System.Drawing.Point(0, 210);
            this.labelArea.Margin = new System.Windows.Forms.Padding(0);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(234, 70);
            this.labelArea.TabIndex = 4;
            this.labelArea.Text = "Площадь";
            this.labelArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxOwner
            // 
            this.comboBoxOwner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxOwner.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxOwner.FormattingEnabled = true;
            this.comboBoxOwner.Location = new System.Drawing.Point(333, 83);
            this.comboBoxOwner.Name = "comboBoxOwner";
            this.comboBoxOwner.Size = new System.Drawing.Size(350, 43);
            this.comboBoxOwner.TabIndex = 6;
            this.comboBoxOwner.SelectedIndexChanged += new System.EventHandler(this.comboBoxOwner_SelectedIndexChanged);
            this.comboBoxOwner.Items.AddRange(owners
                                    .Select(line => line.Key)
                                    .ToArray());
            // 
            // textBoxFloor
            // 
            this.textBoxFloor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxFloor.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxFloor.Location = new System.Drawing.Point(445, 154);
            this.textBoxFloor.Name = "textBoxFloor";
            this.textBoxFloor.Size = new System.Drawing.Size(125, 41);
            this.textBoxFloor.TabIndex = 7;
            this.textBoxFloor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxFloor.TextChanged += new System.EventHandler(this.textBoxFloor_TextChanged);
            // 
            // textBoxArea
            // 
            this.textBoxArea.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxArea.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxArea.Location = new System.Drawing.Point(445, 224);
            this.textBoxArea.Name = "textBoxArea";
            this.textBoxArea.Size = new System.Drawing.Size(125, 41);
            this.textBoxArea.TabIndex = 8;
            this.textBoxArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxArea.TextChanged += new System.EventHandler(this.textBoxArea_TextChanged);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCount.Location = new System.Drawing.Point(445, 296);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(125, 41);
            this.textBoxCount.TabIndex = 9;
            this.textBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAdress.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxAdress.Location = new System.Drawing.Point(237, 3);
            this.textBoxAdress.Multiline = true;
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.Size = new System.Drawing.Size(542, 64);
            this.textBoxAdress.TabIndex = 10;
            this.textBoxAdress.TextChanged += new System.EventHandler(this.textBoxAdress_TextChanged);
            // 
            // NewFlat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.mainTable);
            this.Name = "NewFlat";
            this.Text = "Добавить квартиру";
            this.mainTable.ResumeLayout(false);
            this.mainTable.PerformLayout();
            this.downPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel mainTable;
        private Label upPanel;
        private TableLayoutPanel downPanel;
        private Button buttonAddFlat;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelAdress;
        private Label labelFloor;
        private Label labelCount;
        private Label labelOwner;
        private Label labelArea;
        private ComboBox comboBoxOwner;
        private TextBox textBoxFloor;
        private TextBox textBoxArea;
        private TextBox textBoxCount;
        private TextBox textBoxAdress;
    }
}