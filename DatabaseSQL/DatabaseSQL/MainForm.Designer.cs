namespace DatabaseSQL
{
    partial class MainForm
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
            this.tableLayoutPanelMainForms = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRerortWorkers = new System.Windows.Forms.Button();
            this.buttonRerortRepair = new System.Windows.Forms.Button();
            this.buttonRerortOperation = new System.Windows.Forms.Button();
            this.buttonTable = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tableLayoutPanelMainForms.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMainForms
            // 
            this.tableLayoutPanelMainForms.BackColor = System.Drawing.Color.Aqua;
            this.tableLayoutPanelMainForms.ColumnCount = 2;
            this.tableLayoutPanelMainForms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMainForms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMainForms.Controls.Add(this.buttonRerortWorkers, 0, 0);
            this.tableLayoutPanelMainForms.Controls.Add(this.buttonRerortRepair, 0, 1);
            this.tableLayoutPanelMainForms.Controls.Add(this.buttonRerortOperation, 0, 2);
            this.tableLayoutPanelMainForms.Controls.Add(this.buttonTable, 1, 0);
            this.tableLayoutPanelMainForms.Controls.Add(this.buttonClose, 1, 2);
            this.tableLayoutPanelMainForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMainForms.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tableLayoutPanelMainForms.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMainForms.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMainForms.Name = "tableLayoutPanelMainForms";
            this.tableLayoutPanelMainForms.RowCount = 3;
            this.tableLayoutPanelMainForms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelMainForms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanelMainForms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelMainForms.Size = new System.Drawing.Size(623, 201);
            this.tableLayoutPanelMainForms.TabIndex = 0;
            // 
            // buttonRerortWorkers
            // 
            this.buttonRerortWorkers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRerortWorkers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(137)))));
            this.buttonRerortWorkers.Location = new System.Drawing.Point(55, 13);
            this.buttonRerortWorkers.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRerortWorkers.Name = "buttonRerortWorkers";
            this.buttonRerortWorkers.Size = new System.Drawing.Size(200, 40);
            this.buttonRerortWorkers.TabIndex = 0;
            this.buttonRerortWorkers.Text = "Отчёт \"Рабочие\"";
            this.buttonRerortWorkers.UseVisualStyleBackColor = false;
            this.buttonRerortWorkers.Click += new System.EventHandler(this.buttonRerortWorkers_Click);
            // 
            // buttonRerortRepair
            // 
            this.buttonRerortRepair.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRerortRepair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(137)))));
            this.buttonRerortRepair.Location = new System.Drawing.Point(55, 80);
            this.buttonRerortRepair.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRerortRepair.Name = "buttonRerortRepair";
            this.buttonRerortRepair.Size = new System.Drawing.Size(200, 40);
            this.buttonRerortRepair.TabIndex = 1;
            this.buttonRerortRepair.Text = "Отчёт \"Ремонт\"";
            this.buttonRerortRepair.UseVisualStyleBackColor = false;
            this.buttonRerortRepair.Click += new System.EventHandler(this.buttonRerortRepair_Click);
            // 
            // buttonRerortOperation
            // 
            this.buttonRerortOperation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRerortOperation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(137)))));
            this.buttonRerortOperation.Location = new System.Drawing.Point(5, 147);
            this.buttonRerortOperation.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRerortOperation.Name = "buttonRerortOperation";
            this.buttonRerortOperation.Size = new System.Drawing.Size(300, 40);
            this.buttonRerortOperation.TabIndex = 2;
            this.buttonRerortOperation.Text = "Отчёт по типу работ";
            this.buttonRerortOperation.UseVisualStyleBackColor = false;
            this.buttonRerortOperation.Click += new System.EventHandler(this.buttonRerortOperation_Click);
            // 
            // buttonTable
            // 
            this.buttonTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(137)))));
            this.buttonTable.Location = new System.Drawing.Point(367, 13);
            this.buttonTable.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTable.Name = "buttonTable";
            this.buttonTable.Size = new System.Drawing.Size(200, 40);
            this.buttonTable.TabIndex = 3;
            this.buttonTable.Text = "Таблица";
            this.buttonTable.UseVisualStyleBackColor = false;
            this.buttonTable.Click += new System.EventHandler(this.buttonTable_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(137)))));
            this.buttonClose.Location = new System.Drawing.Point(417, 147);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 40);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Выход";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 201);
            this.Controls.Add(this.tableLayoutPanelMainForms);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tableLayoutPanelMainForms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMainForms;
        private Button buttonRerortWorkers;
        private Button buttonRerortRepair;
        private Button buttonRerortOperation;
        private Button buttonTable;
        private Button buttonClose;
    }
}