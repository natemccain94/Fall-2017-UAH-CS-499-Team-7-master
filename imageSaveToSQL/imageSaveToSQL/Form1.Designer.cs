namespace imageSaveToSQL
{
    partial class Form1
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
            this.textBoxlPrice = new System.Windows.Forms.TextBox();
            this.textBoxagency_id = new System.Windows.Forms.TextBox();
            this.textBoxagent_id = new System.Windows.Forms.TextBox();
            this.pictureEMP = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEMP)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxlPrice
            // 
            this.textBoxlPrice.Location = new System.Drawing.Point(138, 33);
            this.textBoxlPrice.Name = "textBoxlPrice";
            this.textBoxlPrice.Size = new System.Drawing.Size(100, 22);
            this.textBoxlPrice.TabIndex = 0;
            // 
            // textBoxagency_id
            // 
            this.textBoxagency_id.Location = new System.Drawing.Point(138, 106);
            this.textBoxagency_id.Name = "textBoxagency_id";
            this.textBoxagency_id.Size = new System.Drawing.Size(100, 22);
            this.textBoxagency_id.TabIndex = 1;
            this.textBoxagency_id.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBoxagent_id
            // 
            this.textBoxagent_id.Location = new System.Drawing.Point(138, 173);
            this.textBoxagent_id.Name = "textBoxagent_id";
            this.textBoxagent_id.Size = new System.Drawing.Size(100, 22);
            this.textBoxagent_id.TabIndex = 2;
            // 
            // pictureEMP
            // 
            this.pictureEMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureEMP.Location = new System.Drawing.Point(326, 33);
            this.pictureEMP.Name = "pictureEMP";
            this.pictureEMP.Size = new System.Drawing.Size(173, 162);
            this.pictureEMP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureEMP.TabIndex = 3;
            this.pictureEMP.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "listingPrice";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "agency_id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "agent_id";
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(286, 329);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(75, 23);
            this.buttonShow.TabIndex = 7;
            this.buttonShow.Text = "show";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(424, 329);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(424, 232);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 9;
            this.buttonBrowse.Text = "browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 379);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "listing ID";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBoxLID
            // 
            this.textBoxLID.Location = new System.Drawing.Point(102, 379);
            this.textBoxLID.Name = "textBoxLID";
            this.textBoxLID.Size = new System.Drawing.Size(47, 22);
            this.textBoxLID.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 413);
            this.Controls.Add(this.textBoxLID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureEMP);
            this.Controls.Add(this.textBoxagent_id);
            this.Controls.Add(this.textBoxagency_id);
            this.Controls.Add(this.textBoxlPrice);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEMP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxlPrice;
        private System.Windows.Forms.TextBox textBoxagency_id;
        private System.Windows.Forms.TextBox textBoxagent_id;
        private System.Windows.Forms.PictureBox pictureEMP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLID;
    }
}

