namespace DataBaseForms
{
    partial class FormArtists
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAddArtist = new System.Windows.Forms.Button();
            this.tableArtists = new System.Windows.Forms.DataGridView();
            this.buttonRefreshTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableArtists)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddArtist
            // 
            this.buttonAddArtist.Location = new System.Drawing.Point(722, 553);
            this.buttonAddArtist.Name = "buttonAddArtist";
            this.buttonAddArtist.Size = new System.Drawing.Size(146, 29);
            this.buttonAddArtist.TabIndex = 1;
            this.buttonAddArtist.Text = "Добавить артиста";
            this.buttonAddArtist.UseVisualStyleBackColor = true;
            this.buttonAddArtist.Click += new System.EventHandler(this.buttonAddArtist_Click);
            // 
            // tableArtists
            // 
            this.tableArtists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableArtists.Location = new System.Drawing.Point(0, 2);
            this.tableArtists.Name = "tableArtists";
            this.tableArtists.RowHeadersWidth = 51;
            this.tableArtists.RowTemplate.Height = 29;
            this.tableArtists.Size = new System.Drawing.Size(880, 545);
            this.tableArtists.TabIndex = 0;
            this.tableArtists.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableArtists_CellDoubleClick);
            // 
            // buttonRefreshTable
            // 
            this.buttonRefreshTable.Location = new System.Drawing.Point(570, 553);
            this.buttonRefreshTable.Name = "buttonRefreshTable";
            this.buttonRefreshTable.Size = new System.Drawing.Size(146, 29);
            this.buttonRefreshTable.TabIndex = 2;
            this.buttonRefreshTable.Text = "Обновить";
            this.buttonRefreshTable.UseVisualStyleBackColor = true;
            this.buttonRefreshTable.Click += new System.EventHandler(this.buttonRefreshTable_Click);
            // 
            // FormArtists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 603);
            this.Controls.Add(this.buttonRefreshTable);
            this.Controls.Add(this.buttonAddArtist);
            this.Controls.Add(this.tableArtists);
            this.Name = "FormArtists";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Артисты";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormArtists_FormClosed);
            this.Load += new System.EventHandler(this.FormArtists_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableArtists)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button buttonAddArtist;
        private DataGridView tableArtists;
        private Button buttonRefreshTable;
    }
}