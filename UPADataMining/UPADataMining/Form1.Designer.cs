namespace UPADataMining
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.BtnShowAll = new System.Windows.Forms.Button();
            this.lstFollowNames = new System.Windows.Forms.ListBox();
            this.lstTweetList = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Location = new System.Drawing.Point(139, 14);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(719, 20);
            this.txtSearchTerm.TabIndex = 0;
            // 
            // BtnShowAll
            // 
            this.BtnShowAll.Location = new System.Drawing.Point(12, 12);
            this.BtnShowAll.Name = "BtnShowAll";
            this.BtnShowAll.Size = new System.Drawing.Size(75, 23);
            this.BtnShowAll.TabIndex = 1;
            this.BtnShowAll.Text = "Show All";
            this.BtnShowAll.UseVisualStyleBackColor = true;
            this.BtnShowAll.Click += new System.EventHandler(this.BtnShowAll_Click);
            // 
            // lstFollowNames
            // 
            this.lstFollowNames.FormattingEnabled = true;
            this.lstFollowNames.Location = new System.Drawing.Point(12, 49);
            this.lstFollowNames.Name = "lstFollowNames";
            this.lstFollowNames.Size = new System.Drawing.Size(120, 277);
            this.lstFollowNames.TabIndex = 2;
            this.lstFollowNames.SelectedIndexChanged += new System.EventHandler(this.lstFollowNames_SelectedIndexChanged);
            // 
            // lstTweetList
            // 
            this.lstTweetList.FormattingEnabled = true;
            this.lstTweetList.Location = new System.Drawing.Point(139, 49);
            this.lstTweetList.Name = "lstTweetList";
            this.lstTweetList.Size = new System.Drawing.Size(752, 277);
            this.lstTweetList.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(864, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(27, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "button1";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 338);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lstTweetList);
            this.Controls.Add(this.lstFollowNames);
            this.Controls.Add(this.BtnShowAll);
            this.Controls.Add(this.txtSearchTerm);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.Button BtnShowAll;
        private System.Windows.Forms.ListBox lstFollowNames;
        private System.Windows.Forms.ListBox lstTweetList;
        private System.Windows.Forms.Button btnSearch;
    }
}

