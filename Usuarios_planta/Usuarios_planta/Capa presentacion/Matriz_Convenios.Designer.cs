namespace Usuarios_planta.Capa_presentacion
{
    partial class Matriz_Convenios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TxtCodigo_Convenio = new System.Windows.Forms.TextBox();
            this.Btnbuscar_matriz = new System.Windows.Forms.PictureBox();
            this.cmbDirigido = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Actualizar_matriz = new FontAwesome.Sharp.IconButton();
            this.TxtCod_Matriz = new System.Windows.Forms.TextBox();
            this.dgvDatos_Matriz = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDescargar_Excel = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.Btnbuscar_matriz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos_Matriz)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCodigo_Convenio
            // 
            this.TxtCodigo_Convenio.BackColor = System.Drawing.SystemColors.Window;
            this.TxtCodigo_Convenio.Font = new System.Drawing.Font("Roboto Cn", 11.25F);
            this.TxtCodigo_Convenio.Location = new System.Drawing.Point(32, 200);
            this.TxtCodigo_Convenio.MaxLength = 10;
            this.TxtCodigo_Convenio.Multiline = true;
            this.TxtCodigo_Convenio.Name = "TxtCodigo_Convenio";
            this.TxtCodigo_Convenio.Size = new System.Drawing.Size(109, 28);
            this.TxtCodigo_Convenio.TabIndex = 251;
            this.TxtCodigo_Convenio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Btnbuscar_matriz
            // 
            this.Btnbuscar_matriz.BackColor = System.Drawing.SystemColors.Window;
            this.Btnbuscar_matriz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnbuscar_matriz.Image = global::Usuarios_planta.Properties.Resources.search_26px;
            this.Btnbuscar_matriz.Location = new System.Drawing.Point(487, 200);
            this.Btnbuscar_matriz.Name = "Btnbuscar_matriz";
            this.Btnbuscar_matriz.Size = new System.Drawing.Size(35, 28);
            this.Btnbuscar_matriz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Btnbuscar_matriz.TabIndex = 253;
            this.Btnbuscar_matriz.TabStop = false;
            this.Btnbuscar_matriz.Click += new System.EventHandler(this.Buscar_Matriz);
            // 
            // cmbDirigido
            // 
            this.cmbDirigido.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDirigido.Font = new System.Drawing.Font("Roboto Cn", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDirigido.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDirigido.FormattingEnabled = true;
            this.cmbDirigido.Location = new System.Drawing.Point(163, 200);
            this.cmbDirigido.Name = "cmbDirigido";
            this.cmbDirigido.Size = new System.Drawing.Size(169, 27);
            this.cmbDirigido.TabIndex = 287;
            this.cmbDirigido.SelectedValueChanged += new System.EventHandler(this.cmbDirigido_SelectedValueChanged);
            this.cmbDirigido.Click += new System.EventHandler(this.cmbDirigido_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto Cn", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(157)))));
            this.label5.Location = new System.Drawing.Point(321, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(570, 38);
            this.label5.TabIndex = 289;
            this.label5.Text = "Consulta Actualizacion Matriz de convenios";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Actualizar_matriz
            // 
            this.Btn_Actualizar_matriz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.Btn_Actualizar_matriz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Actualizar_matriz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Actualizar_matriz.Font = new System.Drawing.Font("Roboto Cn", 9.75F);
            this.Btn_Actualizar_matriz.ForeColor = System.Drawing.Color.Gainsboro;
            this.Btn_Actualizar_matriz.IconChar = FontAwesome.Sharp.IconChar.MailBulk;
            this.Btn_Actualizar_matriz.IconColor = System.Drawing.Color.Gainsboro;
            this.Btn_Actualizar_matriz.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btn_Actualizar_matriz.IconSize = 22;
            this.Btn_Actualizar_matriz.Location = new System.Drawing.Point(141, 286);
            this.Btn_Actualizar_matriz.Name = "Btn_Actualizar_matriz";
            this.Btn_Actualizar_matriz.Size = new System.Drawing.Size(103, 44);
            this.Btn_Actualizar_matriz.TabIndex = 290;
            this.Btn_Actualizar_matriz.Text = "Actualizar Base";
            this.Btn_Actualizar_matriz.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Actualizar_matriz.UseVisualStyleBackColor = false;
            this.Btn_Actualizar_matriz.Click += new System.EventHandler(this.Btn_Actualizar_matriz_Click);
            // 
            // TxtCod_Matriz
            // 
            this.TxtCod_Matriz.BackColor = System.Drawing.SystemColors.Window;
            this.TxtCod_Matriz.Enabled = false;
            this.TxtCod_Matriz.Font = new System.Drawing.Font("Roboto Cn", 11.25F);
            this.TxtCod_Matriz.Location = new System.Drawing.Point(338, 200);
            this.TxtCod_Matriz.MaxLength = 10;
            this.TxtCod_Matriz.Multiline = true;
            this.TxtCod_Matriz.Name = "TxtCod_Matriz";
            this.TxtCod_Matriz.Size = new System.Drawing.Size(143, 28);
            this.TxtCod_Matriz.TabIndex = 291;
            this.TxtCod_Matriz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvDatos_Matriz
            // 
            this.dgvDatos_Matriz.AllowUserToAddRows = false;
            this.dgvDatos_Matriz.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDatos_Matriz.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(101)))), ((int)(((byte)(124)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos_Matriz.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos_Matriz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos_Matriz.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatos_Matriz.EnableHeadersVisualStyles = false;
            this.dgvDatos_Matriz.Location = new System.Drawing.Point(32, 336);
            this.dgvDatos_Matriz.Name = "dgvDatos_Matriz";
            this.dgvDatos_Matriz.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos_Matriz.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDatos_Matriz.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDatos_Matriz.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDatos_Matriz.Size = new System.Drawing.Size(1131, 169);
            this.dgvDatos_Matriz.TabIndex = 293;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Cn", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(32, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
            this.label1.TabIndex = 294;
            this.label1.Text = "Codigo Convenio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Cn", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label2.Location = new System.Drawing.Point(163, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 295;
            this.label2.Text = "Dirigido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Cn", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label3.Location = new System.Drawing.Point(338, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 19);
            this.label3.TabIndex = 296;
            this.label3.Text = "Cod Matriz";
            // 
            // btnDescargar_Excel
            // 
            this.btnDescargar_Excel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.btnDescargar_Excel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargar_Excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargar_Excel.Font = new System.Drawing.Font("Roboto Cn", 9.75F);
            this.btnDescargar_Excel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDescargar_Excel.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btnDescargar_Excel.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDescargar_Excel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDescargar_Excel.IconSize = 22;
            this.btnDescargar_Excel.Location = new System.Drawing.Point(32, 286);
            this.btnDescargar_Excel.Name = "btnDescargar_Excel";
            this.btnDescargar_Excel.Size = new System.Drawing.Size(103, 44);
            this.btnDescargar_Excel.TabIndex = 297;
            this.btnDescargar_Excel.Text = "Exp. Excel";
            this.btnDescargar_Excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDescargar_Excel.UseVisualStyleBackColor = false;
            this.btnDescargar_Excel.Click += new System.EventHandler(this.btnDescargar_Excel_Click);
            // 
            // Matriz_Convenios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1279, 816);
            this.Controls.Add(this.btnDescargar_Excel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDatos_Matriz);
            this.Controls.Add(this.TxtCod_Matriz);
            this.Controls.Add(this.Btn_Actualizar_matriz);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDirigido);
            this.Controls.Add(this.Btnbuscar_matriz);
            this.Controls.Add(this.TxtCodigo_Convenio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Matriz_Convenios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Matriz_Convenios";
            this.Load += new System.EventHandler(this.Matriz_Convenios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Btnbuscar_matriz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos_Matriz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtCodigo_Convenio;
        private System.Windows.Forms.PictureBox Btnbuscar_matriz;
        private System.Windows.Forms.ComboBox cmbDirigido;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton Btn_Actualizar_matriz;
        private System.Windows.Forms.TextBox TxtCod_Matriz;
        private System.Windows.Forms.DataGridView dgvDatos_Matriz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnDescargar_Excel;
    }
}