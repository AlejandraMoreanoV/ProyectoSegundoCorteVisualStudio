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
    public partial class ActualizarSede : Form
    {
        public ActualizarSede()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
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
                textBox2.Enabled = true;
                textBox5.Enabled = true;
                textBox1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Id inválido.", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != ""
                && textBox2.Text.Trim() != ""
                && textBox3.Text.Trim() != ""
                && textBox4.Text.Trim() != ""
                && textBox5.Text.Trim() != ""
                && int.TryParse(textBox1.Text, out int idUsuario)
                && double.TryParse(textBox5.Text, out double mensualidad)
                && !(int.TryParse(textBox2.Text, out int nombre) || int.TryParse(textBox3.Text, out int apellido))
                )
            {
                DialogResult decision = MessageBox.Show("¿Estás seguro de que quieres actualizar el usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (decision == DialogResult.Yes)
                {
                    var new_options = new RestClientOptions("http://localhost:8080");
                    var new_client = new RestClient(new_options);
                    var new_request = new RestRequest($"/sede", Method.Put);
                    new_request.RequestFormat = DataFormat.Json;
                    try
                    {
                        string fechaString = textBox4.Text;
                        DateTime fecha = DateTime.ParseExact(fechaString, "dd/MM/yyyy hh:mm:ss tt", null);
                        string fechaISO8601 = fecha.ToString("yyyy-MM-ddTHH:mm:ss");
                        fechaISO8601 = fechaISO8601.Replace(" ", "T");
                        new_request.AddBody(new
                        {
                            id = textBox1.Text,
                            direccion = textBox2.Text,
                            ciudad = textBox3.Text,
                            fechaRegistro = fechaISO8601,
                            m2 = textBox5.Text,
                        });
                        RestResponse new_result = new_client.Execute(new_request);
                        //MessageBox.Show(new_result.Content);
                        if (new_result.StatusCode == HttpStatusCode.OK)
                        {
                            MessageBox.Show("La sede ha sido actualizada exitosamente.", "Información");
                            textBox1.ResetText();
                            textBox2.ResetText();
                            textBox3.ResetText();
                            textBox4.ResetText();
                            textBox5.ResetText();
                            textBox2.Enabled = false;
                            textBox3.Enabled = false;
                            textBox1.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("No fue posible actualizar la sede.", "Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El formato de la fecha de inscripción no es válido.", "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha ingresado toda la información requerida completa y/o correcta para actualizar la sede. Por favor, si aun no lo ha hecho, busque el usuario, obtenga su información actual y actualice completa y correctamente.", "Información");
            }
        }

        private void ActualizarSede_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
