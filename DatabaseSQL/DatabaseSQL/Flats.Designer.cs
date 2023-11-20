using Microsoft.Data.SqlClient;
using System.Data;

namespace DatabaseSQL
{
    partial class Flats
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
            this.upPanel = new System.Windows.Forms.Label();
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.newFlatButton = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.downPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainTable = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.downPanel.SuspendLayout();
            this.mainTable.SuspendLayout();
            this.SuspendLayout();
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
            this.upPanel.Size = new System.Drawing.Size(1200, 50);
            this.upPanel.TabIndex = 0;
            this.upPanel.Text = "Квартиры";
            this.upPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataTable
            // 
            this.dataTable.AllowUserToAddRows = false;
            this.dataTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.dataTable.ColumnHeadersHeight = 29;
            this.dataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTable.Location = new System.Drawing.Point(3, 53);
            this.dataTable.Name = "dataTable";
            this.dataTable.RowHeadersWidth = 50;
            this.dataTable.RowTemplate.Height = 30;
            this.dataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataTable.Size = new System.Drawing.Size(1194, 394);
            this.dataTable.TabIndex = 1;
            this.dataTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTable_CellContentDoubleClick);
            // 
            // newFlatButton
            // 
            this.newFlatButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.newFlatButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newFlatButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newFlatButton.Location = new System.Drawing.Point(0, 0);
            this.newFlatButton.Margin = new System.Windows.Forms.Padding(0);
            this.newFlatButton.Name = "newFlatButton";
            this.newFlatButton.Size = new System.Drawing.Size(600, 50);
            this.newFlatButton.TabIndex = 0;
            this.newFlatButton.Text = "Новая квартира";
            this.newFlatButton.UseVisualStyleBackColor = false;
            this.newFlatButton.Click += new System.EventHandler(this.newFlatButton_Click);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.MediumBlue;
            this.cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancel.Location = new System.Drawing.Point(600, 0);
            this.cancel.Margin = new System.Windows.Forms.Padding(0);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(600, 50);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // downPanel
            // 
            this.downPanel.ColumnCount = 2;
            this.downPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.downPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.downPanel.Controls.Add(this.newFlatButton, 0, 0);
            this.downPanel.Controls.Add(this.cancel, 1, 0);
            this.downPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downPanel.Location = new System.Drawing.Point(0, 450);
            this.downPanel.Margin = new System.Windows.Forms.Padding(0);
            this.downPanel.Name = "downPanel";
            this.downPanel.RowCount = 1;
            this.downPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.downPanel.Size = new System.Drawing.Size(1200, 50);
            this.downPanel.TabIndex = 2;
            // 
            // mainTable
            // 
            this.mainTable.ColumnCount = 1;
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTable.Controls.Add(this.upPanel, 0, 0);
            this.mainTable.Controls.Add(this.dataTable, 0, 1);
            this.mainTable.Controls.Add(this.downPanel, 0, 2);
            this.mainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTable.Location = new System.Drawing.Point(0, 0);
            this.mainTable.Margin = new System.Windows.Forms.Padding(0);
            this.mainTable.Name = "mainTable";
            this.mainTable.RowCount = 3;
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainTable.Size = new System.Drawing.Size(1200, 500);
            this.mainTable.TabIndex = 0;
            // 
            // Flats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1200, 500);
            this.Controls.Add(this.mainTable);
            this.Name = "Flats";
            this.Text = "Квартиры";
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.downPanel.ResumeLayout(false);
            this.mainTable.ResumeLayout(false);
            this.mainTable.PerformLayout();
            this.Load += Flats_Load;
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.ResumeLayout(false);


        }

        private DataGridView dataTable;

        #endregion

        private Label upPanel;
        private Button newFlatButton;
        private Button cancel;
        private TableLayoutPanel downPanel;
        private TableLayoutPanel mainTable;
    }
}