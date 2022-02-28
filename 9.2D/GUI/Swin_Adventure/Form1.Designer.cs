namespace Swin_Adventure2
{
    partial class SwinAdventureForm
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
            this.commandTxt = new System.Windows.Forms.TextBox();
            this.executeBtn = new System.Windows.Forms.Button();
            this.outputTxt = new System.Windows.Forms.TextBox();
            this.userTxt = new System.Windows.Forms.TextBox();
            this.descTxt = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.userLbl = new System.Windows.Forms.Label();
            this.descLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // commandTxt
            // 
            this.commandTxt.Location = new System.Drawing.Point(12, 504);
            this.commandTxt.Name = "commandTxt";
            this.commandTxt.Size = new System.Drawing.Size(661, 26);
            this.commandTxt.TabIndex = 0;
            // 
            // executeBtn
            // 
            this.executeBtn.Location = new System.Drawing.Point(679, 504);
            this.executeBtn.Name = "executeBtn";
            this.executeBtn.Size = new System.Drawing.Size(109, 33);
            this.executeBtn.TabIndex = 1;
            this.executeBtn.Text = "Execute";
            this.executeBtn.UseVisualStyleBackColor = true;
            this.executeBtn.Click += new System.EventHandler(this.ExecuteBtn_Click);
            // 
            // outputTxt
            // 
            this.outputTxt.Location = new System.Drawing.Point(12, 12);
            this.outputTxt.Multiline = true;
            this.outputTxt.Name = "outputTxt";
            this.outputTxt.ReadOnly = true;
            this.outputTxt.Size = new System.Drawing.Size(776, 486);
            this.outputTxt.TabIndex = 2;
            // 
            // userTxt
            // 
            this.userTxt.Location = new System.Drawing.Point(281, 211);
            this.userTxt.Name = "userTxt";
            this.userTxt.Size = new System.Drawing.Size(212, 26);
            this.userTxt.TabIndex = 3;
            // 
            // descTxt
            // 
            this.descTxt.Location = new System.Drawing.Point(281, 254);
            this.descTxt.Name = "descTxt";
            this.descTxt.Size = new System.Drawing.Size(212, 26);
            this.descTxt.TabIndex = 4;
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(517, 214);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(96, 66);
            this.submitBtn.TabIndex = 5;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // userLbl
            // 
            this.userLbl.AutoSize = true;
            this.userLbl.Location = new System.Drawing.Point(188, 214);
            this.userLbl.Name = "userLbl";
            this.userLbl.Size = new System.Drawing.Size(87, 20);
            this.userLbl.TabIndex = 6;
            this.userLbl.Text = "Username:";
            // 
            // descLbl
            // 
            this.descLbl.AutoSize = true;
            this.descLbl.Location = new System.Drawing.Point(186, 257);
            this.descLbl.Name = "descLbl";
            this.descLbl.Size = new System.Drawing.Size(89, 20);
            this.descLbl.TabIndex = 7;
            this.descLbl.Text = "Description";
            // 
            // SwinAdventureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.descLbl);
            this.Controls.Add(this.userLbl);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.descTxt);
            this.Controls.Add(this.userTxt);
            this.Controls.Add(this.outputTxt);
            this.Controls.Add(this.executeBtn);
            this.Controls.Add(this.commandTxt);
            this.Name = "SwinAdventureForm";
            this.Text = "Swin Adventure";
            this.Load += new System.EventHandler(this.SwinAdventureForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox commandTxt;
        private System.Windows.Forms.Button executeBtn;
        private System.Windows.Forms.TextBox outputTxt;
        private System.Windows.Forms.TextBox userTxt;
        private System.Windows.Forms.TextBox descTxt;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label userLbl;
        private System.Windows.Forms.Label descLbl;
    }
}

