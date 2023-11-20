namespace DataBaseForms
{
    partial class FormAddArtist
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxStyle = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.textBoxStageName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelStageName = new System.Windows.Forms.Label();
            this.labelGroupName = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelStyle = new System.Windows.Forms.Label();
            this.buttonAddArtist = new System.Windows.Forms.Button();
            this.buttonCancelAddArtist = new System.Windows.Forms.Button();
            this.comboBoxGroupName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(177, 13);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(298, 27);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxStyle
            // 
            this.textBoxStyle.Location = new System.Drawing.Point(177, 145);
            this.textBoxStyle.Name = "textBoxStyle";
            this.textBoxStyle.Size = new System.Drawing.Size(298, 27);
            this.textBoxStyle.TabIndex = 1;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(177, 112);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(298, 27);
            this.textBoxCity.TabIndex = 2;
            // 
            // textBoxStageName
            // 
            this.textBoxStageName.Location = new System.Drawing.Point(177, 46);
            this.textBoxStageName.Name = "textBoxStageName";
            this.textBoxStageName.Size = new System.Drawing.Size(298, 27);
            this.textBoxStageName.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(33, 16);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(118, 20);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Фамилия и имя";
            // 
            // labelStageName
            // 
            this.labelStageName.AutoSize = true;
            this.labelStageName.Location = new System.Drawing.Point(46, 49);
            this.labelStageName.Name = "labelStageName";
            this.labelStageName.Size = new System.Drawing.Size(89, 20);
            this.labelStageName.TabIndex = 6;
            this.labelStageName.Text = "Псевдоним";
            // 
            // labelGroupName
            // 
            this.labelGroupName.AutoSize = true;
            this.labelGroupName.Location = new System.Drawing.Point(12, 82);
            this.labelGroupName.Name = "labelGroupName";
            this.labelGroupName.Size = new System.Drawing.Size(159, 20);
            this.labelGroupName.TabIndex = 7;
            this.labelGroupName.Text = "Название коллектива";
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(66, 115);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(51, 20);
            this.labelCity.TabIndex = 8;
            this.labelCity.Text = "Город";
            // 
            // labelStyle
            // 
            this.labelStyle.AutoSize = true;
            this.labelStyle.Location = new System.Drawing.Point(68, 148);
            this.labelStyle.Name = "labelStyle";
            this.labelStyle.Size = new System.Drawing.Size(49, 20);
            this.labelStyle.TabIndex = 9;
            this.labelStyle.Text = "Стиль";
            // 
            // buttonAddArtist
            // 
            this.buttonAddArtist.Location = new System.Drawing.Point(381, 178);
            this.buttonAddArtist.Name = "buttonAddArtist";
            this.buttonAddArtist.Size = new System.Drawing.Size(94, 29);
            this.buttonAddArtist.TabIndex = 10;
            this.buttonAddArtist.Text = "Добавить";
            this.buttonAddArtist.UseVisualStyleBackColor = true;
            this.buttonAddArtist.Click += new System.EventHandler(this.buttonAddArtist_Click);
            // 
            // buttonCancelAddArtist
            // 
            this.buttonCancelAddArtist.Location = new System.Drawing.Point(281, 178);
            this.buttonCancelAddArtist.Name = "buttonCancelAddArtist";
            this.buttonCancelAddArtist.Size = new System.Drawing.Size(94, 29);
            this.buttonCancelAddArtist.TabIndex = 11;
            this.buttonCancelAddArtist.Text = "Отмена";
            this.buttonCancelAddArtist.UseVisualStyleBackColor = true;
            this.buttonCancelAddArtist.Click += new System.EventHandler(this.buttonCancelAddArtist_Click);
            // 
            // comboBoxGroupName
            // 
            this.comboBoxGroupName.FormattingEnabled = true;
            this.comboBoxGroupName.Location = new System.Drawing.Point(177, 78);
            this.comboBoxGroupName.Name = "comboBoxGroupName";
            this.comboBoxGroupName.Size = new System.Drawing.Size(298, 28);
            this.comboBoxGroupName.TabIndex = 12;
            this.comboBoxGroupName.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroupName_SelectedIndexChanged);
            // 
            // FormAddArtist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 218);
            this.Controls.Add(this.comboBoxGroupName);
            this.Controls.Add(this.buttonCancelAddArtist);
            this.Controls.Add(this.buttonAddArtist);
            this.Controls.Add(this.labelStyle);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.labelGroupName);
            this.Controls.Add(this.labelStageName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxStageName);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.textBoxStyle);
            this.Controls.Add(this.textBoxName);
            this.Name = "FormAddArtist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новый артист";
            this.Load += new System.EventHandler(this.FormAddArtist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxStyle;
        private TextBox textBoxCity;
        private TextBox textBoxStageName;
        private Label labelName;
        private Label labelStageName;
        private Label labelGroupName;
        private Label labelCity;
        private Label labelStyle;
        private Button buttonAddArtist;
        private Button buttonCancelAddArtist;
        private ComboBox comboBoxGroupName;
    }
}