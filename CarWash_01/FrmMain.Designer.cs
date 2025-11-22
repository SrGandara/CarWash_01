namespace CarWash_01
{
    partial class FrmMain
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
            this.gbNouCotxe = new System.Windows.Forms.GroupBox();
            this.btNouCotxe = new System.Windows.Forms.Button();
            this.rbExecutive = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbBasic = new System.Windows.Forms.RadioButton();
            this.gbCotxes = new System.Windows.Forms.GroupBox();
            this.gbNouCotxe.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNouCotxe
            // 
            this.gbNouCotxe.Controls.Add(this.btNouCotxe);
            this.gbNouCotxe.Controls.Add(this.rbExecutive);
            this.gbNouCotxe.Controls.Add(this.rbNormal);
            this.gbNouCotxe.Controls.Add(this.rbBasic);
            this.gbNouCotxe.Location = new System.Drawing.Point(13, 13);
            this.gbNouCotxe.Name = "gbNouCotxe";
            this.gbNouCotxe.Size = new System.Drawing.Size(151, 207);
            this.gbNouCotxe.TabIndex = 0;
            this.gbNouCotxe.TabStop = false;
            this.gbNouCotxe.Text = "Nou Cotxe";
            // 
            // btNouCotxe
            // 
            this.btNouCotxe.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btNouCotxe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNouCotxe.Location = new System.Drawing.Point(24, 156);
            this.btNouCotxe.Name = "btNouCotxe";
            this.btNouCotxe.Size = new System.Drawing.Size(108, 45);
            this.btNouCotxe.TabIndex = 4;
            this.btNouCotxe.Text = "Nou Cotxe";
            this.btNouCotxe.UseVisualStyleBackColor = false;
            this.btNouCotxe.Click += new System.EventHandler(this.btNouCotxe_Click);
            // 
            // rbExecutive
            // 
            this.rbExecutive.AutoSize = true;
            this.rbExecutive.Location = new System.Drawing.Point(24, 121);
            this.rbExecutive.Name = "rbExecutive";
            this.rbExecutive.Size = new System.Drawing.Size(86, 20);
            this.rbExecutive.TabIndex = 3;
            this.rbExecutive.TabStop = true;
            this.rbExecutive.Text = "Executive";
            this.rbExecutive.UseVisualStyleBackColor = true;
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(24, 80);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(72, 20);
            this.rbNormal.TabIndex = 2;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.rbNormal_CheckedChanged);
            // 
            // rbBasic
            // 
            this.rbBasic.AutoSize = true;
            this.rbBasic.Location = new System.Drawing.Point(24, 44);
            this.rbBasic.Name = "rbBasic";
            this.rbBasic.Size = new System.Drawing.Size(62, 20);
            this.rbBasic.TabIndex = 1;
            this.rbBasic.TabStop = true;
            this.rbBasic.Text = "Bàsic";
            this.rbBasic.UseVisualStyleBackColor = true;
            this.rbBasic.CheckedChanged += new System.EventHandler(this.rbBasic_CheckedChanged);
            // 
            // gbCotxes
            // 
            this.gbCotxes.Location = new System.Drawing.Point(547, 13);
            this.gbCotxes.Name = "gbCotxes";
            this.gbCotxes.Size = new System.Drawing.Size(492, 497);
            this.gbCotxes.TabIndex = 1;
            this.gbCotxes.TabStop = false;
            this.gbCotxes.Text = "Cotxes";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 731);
            this.Controls.Add(this.gbCotxes);
            this.Controls.Add(this.gbNouCotxe);
            this.Name = "FrmMain";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.gbNouCotxe.ResumeLayout(false);
            this.gbNouCotxe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNouCotxe;
        private System.Windows.Forms.RadioButton rbExecutive;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbBasic;
        private System.Windows.Forms.Button btNouCotxe;
        private System.Windows.Forms.GroupBox gbCotxes;
    }
}

