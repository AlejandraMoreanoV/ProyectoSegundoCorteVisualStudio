using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoProyectoVisualStudio
{
    public partial class Listar : Form
    {
        public Listar()
        {
            InitializeComponent();

            /*
            //Console.WriteLine(result.Content);
            //dataGridView1 = new DataGridView();
            //dynamic jsonObj = JsonSerializer.Deserialize<List<Usuario>>(result.Content);
            // Deserializa la respuesta JSON en objetos C#
            //var data = JsonConvert.DeserializeObject<TuTipoDeDatos>(responseBody);

            

            // Asigna los datos al DataGridView
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("nombre", typeof(string));
            dt.Columns.Add("apellido", typeof(string)); // Corrected data type

            DataRow row = dt.NewRow();

            // Luego para agregar la nueva fila al DataTable, utilizamos la fila y el nombre de la columna.
            row["id"] = 1;
            row["nombre"] = "Juan";
            row["apellido"] = "Pérez";
            dt.Rows.Add(row);

            // Asignar el DataTable al DataGridView
            dataGridView1.DataSource = dt;
            //dataGridView1.DataSource = jsonObj;
            
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = jsonObj.id; ;
            dataGridView1.Rows[n].Cells[1].Value = jsonObj.nombre; ;
            dataGridView1.Rows[n].Cells[2].Value = jsonObj.apellido; ;
            dataGridView1.Rows[n].Cells[3].Value = jsonObj.fechaInscripcion.ToString();
            dataGridView1.Rows[n].Cells[4].Value = jsonObj.mensualidad.ToString();
            */
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest($"/usuario/{textBox2.Text}", Method.Get);
            RestResponse result = client.Execute(request);
            //MessageBox.Show(result.Content);
            if (textBox2.Text.Trim() == "") {
                MessageBox.Show("No ha ingresado el Id de la sede.", "Información");
            }
            else if (result.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    List<Usuario> usuarios = JsonSerializer.Deserialize<List<Usuario>>(result.Content);
                    if (usuarios.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        // Itera sobre la lista de usuarios y los agrega al DataGridView
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
                    else
                    {
                        MessageBox.Show("No hay usuarios para mostrar.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No hay usuarios para mostrar.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest($"/usuario/filtrar/{textBox2.Text}/{textBox1.Text}", Method.Get);
            RestResponse result = client.Execute(request);
            //MessageBox.Show(result.Content);

            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado el Id de la sede.", "Información");
            }
            else if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show($"No ha ingresado el nombre por el cual quiere filtrar la lista de usuarios.", "Información");
            }
            else if (result.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    List<Usuario> usuarios = JsonSerializer.Deserialize<List<Usuario>>(result.Content);
                    if (usuarios.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        // Itera sobre la lista de usuarios y los agrega al DataGridView
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
                    else
                    {
                        MessageBox.Show("No hay usuarios para mostrar.");
                    }
                }
                catch (Exception) {
                    MessageBox.Show("No hay usuarios para mostrar.");
                }
            }
            else
            {
                MessageBox.Show($"Error al obtener datos de la API. Código de estado: {result.StatusCode}.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Listar_Load(object sender, EventArgs e)
        {

        }
    }
}
