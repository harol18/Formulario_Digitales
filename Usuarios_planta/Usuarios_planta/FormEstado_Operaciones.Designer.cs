
namespace Usuarios_planta
{
    partial class FormEstado_Operaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.BtnExportarTxt = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Nombreprocesobusqueda = new System.Windows.Forms.TextBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cmbEstado_Operacion = new System.Windows.Forms.ComboBox();
            this.btnVer_pte_Correos = new FontAwesome.Sharp.IconButton();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(411, 16);
            this.panel3.TabIndex = 266;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(101)))), ((int)(((byte)(124)))));
            this.panel2.Location = new System.Drawing.Point(604, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(455, 16);
            this.panel2.TabIndex = 267;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(101)))), ((int)(((byte)(124)))));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(411, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 16);
            this.panel1.TabIndex = 267;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(101)))), ((int)(((byte)(124)))));
            this.panel4.Location = new System.Drawing.Point(604, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(455, 16);
            this.panel4.TabIndex = 267;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(187)))), ((int)(((byte)(33)))));
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(725, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(284, 13);
            this.panel5.TabIndex = 268;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(101)))), ((int)(((byte)(124)))));
            this.panel6.Location = new System.Drawing.Point(604, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(455, 16);
            this.panel6.TabIndex = 267;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Roboto Cn", 24F, System.Drawing.FontStyle.Bold);
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label30.Location = new System.Drawing.Point(291, 29);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(445, 38);
            this.label30.TabIndex = 281;
            this.label30.Text = "Validar Estado de las operaciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Cn", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 19);
            this.label1.TabIndex = 252;
            this.label1.Text = "Seleccionar estado";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Lavender;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.BtnExportarTxt);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.Txt_Nombreprocesobusqueda);
            this.panel7.Controls.Add(this.dgvDatos);
            this.panel7.Controls.Add(this.cmbEstado_Operacion);
            this.panel7.Controls.Add(this.btnVer_pte_Correos);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Font = new System.Drawing.Font("Roboto Lt", 15.75F, System.Drawing.FontStyle.Bold);
            this.panel7.Location = new System.Drawing.Point(23, 86);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(985, 603);
            this.panel7.TabIndex = 284;
            // 
            // BtnExportarTxt
            // 
            this.BtnExportarTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.BtnExportarTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportarTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportarTxt.Font = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportarTxt.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnExportarTxt.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.BtnExportarTxt.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnExportarTxt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnExportarTxt.IconSize = 19;
            this.BtnExportarTxt.Location = new System.Drawing.Point(387, 36);
            this.BtnExportarTxt.Name = "BtnExportarTxt";
            this.BtnExportarTxt.Size = new System.Drawing.Size(103, 28);
            this.BtnExportarTxt.TabIndex = 295;
            this.BtnExportarTxt.Text = "Exp. Txt";
            this.BtnExportarTxt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExportarTxt.UseVisualStyleBackColor = false;
            this.BtnExportarTxt.Click += new System.EventHandler(this.BtnExportarTxt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Cn", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label2.Location = new System.Drawing.Point(190, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 290;
            this.label2.Text = "Convenio";
            // 
            // Txt_Nombreprocesobusqueda
            // 
            this.Txt_Nombreprocesobusqueda.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_Nombreprocesobusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_Nombreprocesobusqueda.Font = new System.Drawing.Font("Roboto Cn", 12F);
            this.Txt_Nombreprocesobusqueda.Location = new System.Drawing.Point(193, 37);
            this.Txt_Nombreprocesobusqueda.Multiline = true;
            this.Txt_Nombreprocesobusqueda.Name = "Txt_Nombreprocesobusqueda";
            this.Txt_Nombreprocesobusqueda.Size = new System.Drawing.Size(104, 28);
            this.Txt_Nombreprocesobusqueda.TabIndex = 289;
            this.Txt_Nombreprocesobusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Nombreprocesobusqueda.TextChanged += new System.EventHandler(this.Txt_Nombreprocesobusqueda_TextChanged);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto Lt", 15.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(15, 81);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(950, 505);
            this.dgvDatos.TabIndex = 288;
            // 
            // cmbEstado_Operacion
            // 
            this.cmbEstado_Operacion.BackColor = System.Drawing.Color.White;
            this.cmbEstado_Operacion.Font = new System.Drawing.Font("Roboto Cn", 12F);
            this.cmbEstado_Operacion.FormattingEnabled = true;
            this.cmbEstado_Operacion.Items.AddRange(new object[] {
            "Aprobado",
            "Negado",
            "Suspendido",
            "Devuelto",
            "Devuelto 1",
            "Devuelto 2",
            "Devuelto 3",
            "Pendiente Respuesta"});
            this.cmbEstado_Operacion.Location = new System.Drawing.Point(15, 37);
            this.cmbEstado_Operacion.Name = "cmbEstado_Operacion";
            this.cmbEstado_Operacion.Size = new System.Drawing.Size(172, 27);
            this.cmbEstado_Operacion.TabIndex = 286;
            // 
            // btnVer_pte_Correos
            // 
            this.btnVer_pte_Correos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.btnVer_pte_Correos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVer_pte_Correos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer_pte_Correos.Font = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVer_pte_Correos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVer_pte_Correos.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnVer_pte_Correos.IconColor = System.Drawing.Color.Gainsboro;
            this.btnVer_pte_Correos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVer_pte_Correos.IconSize = 19;
            this.btnVer_pte_Correos.Location = new System.Drawing.Point(303, 37);
            this.btnVer_pte_Correos.Name = "btnVer_pte_Correos";
            this.btnVer_pte_Correos.Size = new System.Drawing.Size(67, 28);
            this.btnVer_pte_Correos.TabIndex = 285;
            this.btnVer_pte_Correos.Text = "Ver";
            this.btnVer_pte_Correos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVer_pte_Correos.UseVisualStyleBackColor = false;
            this.btnVer_pte_Correos.Click += new System.EventHandler(this.btnVer_pte_Correos_Click);
            // 
            // FormEstado_Operaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 701);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "FormEstado_Operaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEstado_Operaciones";
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private FontAwesome.Sharp.IconButton btnVer_pte_Correos;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox cmbEstado_Operacion;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.TextBox Txt_Nombreprocesobusqueda;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton BtnExportarTxt;
    }
}