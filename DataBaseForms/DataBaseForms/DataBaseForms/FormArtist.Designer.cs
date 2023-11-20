namespace DataBaseForms
{
    partial class FormArtist
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
            this.tableSelectedArtistConcerts = new System.Windows.Forms.DataGridView();
            this.buttonAddConcert = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxStyle = new System.Windows.Forms.TextBox();
            this.textBoxStageName = new System.Windows.Forms.TextBox();
            this.textBoxGroupName = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelStageName = new System.Windows.Forms.Label();
            this.labelGroupName = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelStyle = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableSelectedArtistConcerts)).BeginInit();
            this.SuspendLayout();
            // 
            // tableSelectedArtistConcerts
            // 
            this.tableSelectedArtistConcerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableSelectedArtistConcerts.Location = new System.Drawing.Point(0, 93);
            this.tableSelectedArtistConcerts.Name = "tableSelectedArtistConcerts";
            this.tableSelectedArtistConcerts.RowHeadersWidth = 51;
            this.tableSelectedArtistConcerts.RowTemplate.Height = 29;
            this.tableSelectedArtistConcerts.Size = new System.Drawing.Size(880, 463);
            this.tableSelectedArtistConcerts.TabIndex = 2;
            // 
            // buttonAddConcert
            // 
            this.buttonAddConcert.Location = new System.Drawing.Point(723, 562);
            this.buttonAddConcert.Name = "buttonAddConcert";
            this.buttonAddConcert.Size = new System.Drawing.Size(145, 29);
            this.buttonAddConcert.TabIndex = 3;
            this.buttonAddConcert.Text = "Добавить концерт";
            this.buttonAddConcert.UseVisualStyleBackColor = true;
            this.buttonAddConcert.Click += new System.EventHandler(this.buttonAddConcert_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(421, 562);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(145, 29);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 35);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(203, 27);
            this.textBoxName.TabIndex = 5;
            // 
            // textBoxStyle
            // 
            this.textBoxStyle.Location = new System.Drawing.Point(741, 35);
            this.textBoxStyle.Name = "textBoxStyle";
            this.textBoxStyle.Size = new System.Drawing.Size(127, 27);
            this.textBoxStyle.TabIndex = 6;
            // 
            // textBoxStageName
            // 
            this.textBoxStageName.Location = new System.Drawing.Point(221, 35);
            this.textBoxStageName.Name = "textBoxStageName";
            this.textBoxStageName.Size = new System.Drawing.Size(157, 27);
            this.textBoxStageName.TabIndex = 7;
            // 
            // textBoxGroupName
            // 
            this.textBoxGroupName.Location = new System.Drawing.Point(384, 35);
            this.textBoxGroupName.Name = "textBoxGroupName";
            this.textBoxGroupName.Size = new System.Drawing.Size(182, 27);
            this.textBoxGroupName.TabIndex = 8;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(572, 35);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(163, 27);
            this.textBoxCity.TabIndex = 9;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(55, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(118, 20);
            this.labelName.TabIndex = 10;
            this.labelName.Text = "Фамилия и имя";
            // 
            // labelStageName
            // 
            this.labelStageName.AutoSize = true;
            this.labelStageName.Location = new System.Drawing.Point(258, 9);
            this.labelStageName.Name = "labelStageName";
            this.labelStageName.Size = new System.Drawing.Size(89, 20);
            this.labelStageName.TabIndex = 11;
            this.labelStageName.Text = "Псевдоним";
            // 
            // labelGroupName
            // 
            this.labelGroupName.AutoSize = true;
            this.labelGroupName.Location = new System.Drawing.Point(396, 9);
            this.labelGroupName.Name = "labelGroupName";
            this.labelGroupName.Size = new System.Drawing.Size(159, 20);
            this.labelGroupName.TabIndex = 12;
            this.labelGroupName.Text = "Название коллектива";
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(623, 9);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(51, 20);
            this.labelCity.TabIndex = 13;
            this.labelCity.Text = "Город";
            // 
            // labelStyle
            // 
            this.labelStyle.AutoSize = true;
            this.labelStyle.Location = new System.Drawing.Point(781, 9);
            this.labelStyle.Name = "labelStyle";
            this.labelStyle.Size = new System.Drawing.Size(49, 20);
            this.labelStyle.TabIndex = 14;
            this.labelStyle.Text = "Стиль";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(572, 562);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(145, 29);
            this.buttonRefresh.TabIndex = 15;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // FormArtist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 603);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.labelStyle);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.labelGroupName);
            this.Controls.Add(this.labelStageName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.textBoxGroupName);
            this.Controls.Add(this.textBoxStageName);
            this.Controls.Add(this.textBoxStyle);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonAddConcert);
            this.Controls.Add(this.tableSelectedArtistConcerts);
            this.Name = "FormArtist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Артист";
            this.Load += new System.EventHandler(this.FormArtist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableSelectedArtistConcerts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView tableSelectedArtistConcerts;
        private Button buttonAddConcert;
        private Button buttonBack;
        private TextBox textBoxName;
        private TextBox textBoxStyle;
        private TextBox textBoxStageName;
        private TextBox textBoxGroupName;
        private TextBox textBoxCity;
        private Label labelName;
        private Label labelStageName;
        private Label labelGroupName;
        private Label labelCity;
        private Label labelStyle;
        private Button buttonRefresh;
    }
}