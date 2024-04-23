namespace SegundoProyectoVisualStudio
{
    partial class ListarSedes
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
            dataGridView1 = new DataGridView();
            idSede = new DataGridViewTextBoxColumn();
            direccion = new DataGridViewTextBoxColumn();
            ciudad = new DataGridViewTextBoxColumn();
            fechaRegistro = new DataGridViewTextBoxColumn();
            m2 = new DataGridViewTextBoxColumn();
            idUsuario = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            apellido = new DataGridViewTextBoxColumn();
            fechaInscripcion = new DataGridViewTextBoxColumn();
            mensualidad = new DataGridViewTextBoxColumn();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idSede, direccion, ciudad, fechaRegistro, m2, idUsuario, nombre, apellido, fechaInscripcion, mensualidad });
            dataGridView1.Location = new Point(12, 102);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(932, 199);
            dataGridView1.TabIndex = 0;
            // 
            // idSede
            // 
            idSede.HeaderText = "Id sede";
            idSede.Name = "idSede";
            idSede.Width = 40;
            // 
            // direccion
            // 
            direccion.HeaderText = "Dirección";
            direccion.Name = "direccion";
            direccion.Width = 150;
            // 
            // ciudad
            // 
            ciudad.HeaderText = "Ciudad";
            ciudad.Name = "ciudad";
            // 
            // fechaRegistro
            // 
            fechaRegistro.HeaderText = "Fecha de registro";
            fechaRegistro.Name = "fechaRegistro";
            fechaRegistro.Width = 150;
            // 
            // m2
            // 
            m2.HeaderText = "Área (m2)";
            m2.Name = "m2";
            // 
            // idUsuario
            // 
            idUsuario.HeaderText = "Id usuario";
            idUsuario.Name = "idUsuario";
            idUsuario.Width = 50;
            // 
            // nombre
            // 
            nombre.HeaderText = "Nombre";
            nombre.Name = "nombre";
            // 
            // apellido
            // 
            apellido.HeaderText = "Apellido";
            apellido.Name = "apellido";
            // 
            // fechaInscripcion
            // 
            fechaInscripcion.HeaderText = "Fecha de inscripción";
            fechaInscripcion.Name = "fechaInscripcion";
            fechaInscripcion.Width = 150;
            // 
            // mensualidad
            // 
            mensualidad.HeaderText = "Mensualidad";
            mensualidad.Name = "mensualidad";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 1;
            label1.Text = "Ciudad:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(76, 17);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(96, 23);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(194, 18);
            button1.Name = "button1";
            button1.Size = new Size(104, 23);
            button1.TabIndex = 3;
            button1.Text = "Listar todos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(194, 47);
            button2.Name = "button2";
            button2.Size = new Size(104, 23);
            button2.TabIndex = 4;
            button2.Text = "Listar por ciudad";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(869, 315);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 5;
            button3.Text = "Regresar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ListarSedes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 350);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "ListarSedes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listar sedes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridViewTextBoxColumn idSede;
        private DataGridViewTextBoxColumn direccion;
        private DataGridViewTextBoxColumn ciudad;
        private DataGridViewTextBoxColumn fechaRegistro;
        private DataGridViewTextBoxColumn m2;
        private DataGridViewTextBoxColumn idUsuario;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn apellido;
        private DataGridViewTextBoxColumn fechaInscripcion;
        private DataGridViewTextBoxColumn mensualidad;
    }
}