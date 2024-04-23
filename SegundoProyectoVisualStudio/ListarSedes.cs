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
    public partial class ListarSedes : Form
    {
        public ListarSedes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest($"/sede", Method.Get);
            RestResponse result = client.Execute(request);
            //MessageBox.Show(result.Content);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                List<Sede> sedes = JsonSerializer.Deserialize<List<Sede>>(result.Content);
                if (sedes.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var sede in sedes)
                        if (sede.listaUsuarios.Count > 0)
                        {
                            foreach (var usuario in sede.listaUsuarios)
                            {
                                int n = dataGridView1.Rows.Add();
                                dataGridView1.Rows[n].Cells[0].Value = sede.id;
                                dataGridView1.Rows[n].Cells[1].Value = sede.direccion;
                                dataGridView1.Rows[n].Cells[2].Value = sede.ciudad;
                                dataGridView1.Rows[n].Cells[3].Value = sede.fechaRegistro.ToString();
                                dataGridView1.Rows[n].Cells[4].Value = sede.m2.ToString();
                                dataGridView1.Rows[n].Cells[5].Value = usuario.id;
                                dataGridView1.Rows[n].Cells[6].Value = usuario.nombre;
                                dataGridView1.Rows[n].Cells[7].Value = usuario.apellido;
                                dataGridView1.Rows[n].Cells[8].Value = usuario.fechaInscripcion.ToString();
                                dataGridView1.Rows[n].Cells[9].Value = usuario.mensualidad.ToString();
                            }
                        }
                        else
                        {
                            int n = dataGridView1.Rows.Add();
                            dataGridView1.Rows[n].Cells[0].Value = sede.id;
                            dataGridView1.Rows[n].Cells[1].Value = sede.direccion;
                            dataGridView1.Rows[n].Cells[2].Value = sede.ciudad;
                            dataGridView1.Rows[n].Cells[3].Value = sede.fechaRegistro.ToString();
                            dataGridView1.Rows[n].Cells[4].Value = sede.m2.ToString();
                            //dataGridView1.Rows[n].Cells[5].Value = usuario.id;
                            //dataGridView1.Rows[n].Cells[6].Value = usuario.nombre;
                            //dataGridView1.Rows[n].Cells[7].Value = usuario.apellido;
                            //dataGridView1.Rows[n].Cells[8].Value = usuario.fechaInscripcion.ToString();
                            //dataGridView1.Rows[n].Cells[9].Value = usuario.mensualidad.ToString();
                        }
                }
            }
            else 
            {
                MessageBox.Show("No hay sedes para listar.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest($"/sede/filtrar/{textBox1.Text}", Method.Get);

            RestResponse result = client.Execute(request);

            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Por favor digite la ciudad de las sedes que desea consultar.", "Error");
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show("Sede no encontrada.", "Error");
            }
            else if (result.StatusCode == HttpStatusCode.OK)
            {
                dataGridView1.Rows.Clear();
                List<Sede> sedes = JsonSerializer.Deserialize<List<Sede>>(result.Content);
                if (sedes.Count > 0)
                {
                    foreach (var sede in sedes)
                        if (sede.listaUsuarios.Count > 0)
                        {
                            foreach (var usuario in sede.listaUsuarios)
                            {
                                int n = dataGridView1.Rows.Add();
                                dataGridView1.Rows[n].Cells[0].Value = sede.id;
                                dataGridView1.Rows[n].Cells[1].Value = sede.direccion;
                                dataGridView1.Rows[n].Cells[2].Value = sede.ciudad;
                                dataGridView1.Rows[n].Cells[3].Value = sede.fechaRegistro.ToString();
                                dataGridView1.Rows[n].Cells[4].Value = sede.m2.ToString();
                                dataGridView1.Rows[n].Cells[5].Value = usuario.id;
                                dataGridView1.Rows[n].Cells[6].Value = usuario.nombre;
                                dataGridView1.Rows[n].Cells[7].Value = usuario.apellido;
                                dataGridView1.Rows[n].Cells[8].Value = usuario.fechaInscripcion.ToString();
                                dataGridView1.Rows[n].Cells[9].Value = usuario.mensualidad.ToString();
                            }
                        }
                        else {
                            int n = dataGridView1.Rows.Add();
                            dataGridView1.Rows[n].Cells[0].Value = sede.id;
                            dataGridView1.Rows[n].Cells[1].Value = sede.direccion;
                            dataGridView1.Rows[n].Cells[2].Value = sede.ciudad;
                            dataGridView1.Rows[n].Cells[3].Value = sede.fechaRegistro.ToString();
                            dataGridView1.Rows[n].Cells[4].Value = sede.m2.ToString();
                            //dataGridView1.Rows[n].Cells[5].Value = usuario.id;
                            //dataGridView1.Rows[n].Cells[6].Value = usuario.nombre;
                            //dataGridView1.Rows[n].Cells[7].Value = usuario.apellido;
                            //dataGridView1.Rows[n].Cells[8].Value = usuario.fechaInscripcion.ToString();
                            //dataGridView1.Rows[n].Cells[9].Value = usuario.mensualidad.ToString();
                        }
                }
                else {
                    MessageBox.Show("No hay sedes para listar.");
                }
            }
            else
            {
                MessageBox.Show("Formato del nombre de la ciudad de la sede inválido.", "Error");
            }
        }
    }
}