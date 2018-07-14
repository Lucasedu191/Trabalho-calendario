namespace TrabalhoCalendáriov1
{
    partial class FormFeriados
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
            this.labelAno = new System.Windows.Forms.Label();
            this.ButtonCalcular = new System.Windows.Forms.Button();
            this.richTextBoxFeriados = new System.Windows.Forms.RichTextBox();
            this.maskedTextBoxAno = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // labelAno
            // 
            this.labelAno.AutoSize = true;
            this.labelAno.Location = new System.Drawing.Point(65, 36);
            this.labelAno.Name = "labelAno";
            this.labelAno.Size = new System.Drawing.Size(29, 13);
            this.labelAno.TabIndex = 0;
            this.labelAno.Text = "Ano:";
            // 
            // ButtonCalcular
            // 
            this.ButtonCalcular.Location = new System.Drawing.Point(237, 33);
            this.ButtonCalcular.Name = "ButtonCalcular";
            this.ButtonCalcular.Size = new System.Drawing.Size(103, 23);
            this.ButtonCalcular.TabIndex = 2;
            this.ButtonCalcular.Text = "Calcular Feriados";
            this.ButtonCalcular.UseVisualStyleBackColor = true;
            this.ButtonCalcular.Click += new System.EventHandler(this.ButtonCalcular_Click);
            // 
            // richTextBoxFeriados
            // 
            this.richTextBoxFeriados.Location = new System.Drawing.Point(27, 93);
            this.richTextBoxFeriados.Name = "richTextBoxFeriados";
            this.richTextBoxFeriados.Size = new System.Drawing.Size(313, 226);
            this.richTextBoxFeriados.TabIndex = 3;
            this.richTextBoxFeriados.Text = "";
            // 
            // maskedTextBoxAno
            // 
            this.maskedTextBoxAno.Location = new System.Drawing.Point(101, 35);
            this.maskedTextBoxAno.Mask = "0000";
            this.maskedTextBoxAno.Name = "maskedTextBoxAno";
            this.maskedTextBoxAno.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxAno.TabIndex = 4;
            this.maskedTextBoxAno.ValidatingType = typeof(System.DateTime);
            // 
            // FormFeriados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 345);
            this.Controls.Add(this.maskedTextBoxAno);
            this.Controls.Add(this.richTextBoxFeriados);
            this.Controls.Add(this.ButtonCalcular);
            this.Controls.Add(this.labelAno);
            this.Name = "FormFeriados";
            this.Text = "Feriados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAno;
        private System.Windows.Forms.Button ButtonCalcular;
        private System.Windows.Forms.RichTextBox richTextBoxFeriados;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxAno;
    }
}

