using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SegundoProyectoVisualStudio
{
    public partial class BuscarSede : Form
    {
        public BuscarSede()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest($"/sede/id/{textBox1.Text}", Method.Get);
            RestResponse result = client.Execute(request);

            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Por favor digite el Id de la sede que desea consultar.", "Error");
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show("Usuario no encontrado.", "Error");
            }
            else if (result.StatusCode == HttpStatusCode.OK)
            {
                var jsonObj = JsonSerializer.Deserialize<Sede>(result.Content);

                textBox2.Text = jsonObj.direccion;
                textBox3.Text = jsonObj.ciudad;
                textBox4.Text = jsonObj.fechaRegistro.ToString();
                textBox5.Text = jsonObj.m2.ToString();
                List<Usuario> usuarios = jsonObj.listaUsuarios;
                dataGridView1.Rows.Clear();
                foreach (var usuario in usuarios)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = usuario.id;
                    dataGridView1.Rows[n].Cells[1].Value = usuario.nombre;
                    dataGridView1.Rows[n].Cells[2].Value = usuario.apellido;
                    dataGridView1.Rows[n].Cells[3].Value = usuario.fechaInscripcion.ToString();
                    dataGridView1.Rows[n].Cells[4].Value = usuario.mensualidad.ToString();
                }
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show("Sede no encontrada.", "Error");
            }
            else
            {
                MessageBox.Show("Id inválido.", "Error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest($"/sede/ciudad/{textBox3.Text}", Method.Get);

            RestResponse result = client.Execute(request);

            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Por favor digite la ciudad donde la sede que desea consultar se encuentra ubicada.", "Error");
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show("Sede no encontrada.", "Error");
            }
            else if (result.StatusCode == HttpStatusCode.OK)
            {
                var jsonObj = JsonSerializer.Deserialize<Sede>(result.Content);
                textBox1.Text = jsonObj.id.ToString();
                textBox2.Text = jsonObj.direccion;
                textBox4.Text = jsonObj.fechaRegistro.ToString();
                textBox5.Text = jsonObj.m2.ToString();
                List<Usuario> usuarios = jsonObj.listaUsuarios;
                dataGridView1.Rows.Clear();
                foreach (var usuario in usuarios)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = usuario.id;
                    dataGridView1.Rows[n].Cells[1].Value = usuario.nombre;
                    dataGridView1.Rows[n].Cells[2].Value = usuario.apellido;
                    dataGridView1.Rows[n].Cells[3].Value = usuario.fechaInscripcion.ToString();
                    dataGridView1.Rows[n].Cells[4].Value = usuario.mensualidad.ToString();
                }
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show("Sede no encontrada.", "Error");
            }
            else
            {
                MessageBox.Show("Formato del nombre de la ciudad de la sede inválido.", "Error");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest($"/sede/idCiudad/{textBox1.Text}/{textBox3.Text}", Method.Get);

            RestResponse result = client.Execute(request);

            if (textBox1.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Por favor digite el Id y el nombre de la sede que desea consultar.", "Error");
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show("Sede no encontrada.", "Error");
            }
            else if (result.StatusCode == HttpStatusCode.OK)
            {
                var jsonObj = JsonSerializer.Deserialize<Sede>(result.Content);
                textBox2.Text = jsonObj.direccion;
                textBox4.Text = jsonObj.fechaRegistro.ToString();
                textBox5.Text = jsonObj.m2.ToString();
                List<Usuario> usuarios = jsonObj.listaUsuarios;
                dataGridView1.Rows.Clear();
                foreach (var usuario in usuarios)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = usuario.id;
                    dataGridView1.Rows[n].Cells[1].Value = usuario.nombre;
                    dataGridView1.Rows[n].Cells[2].Value = usuario.apellido;
                    dataGridView1.Rows[n].Cells[3].Value = usuario.fechaInscripcion.ToString();
                    dataGridView1.Rows[n].Cells[4].Value = usuario.mensualidad.ToString();
                }
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show("Sede no encontrada.", "Error");
            }
            else
            {
                MessageBox.Show("Formato del Id y/o nombre inválido.", "Error");
            }
        }

        private void BuscarSede_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
            dataGridView1.Rows.Clear();
        }
    }
}
