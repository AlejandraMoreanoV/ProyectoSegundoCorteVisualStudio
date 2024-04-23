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
    public partial class EliminarSede : Form
    {
        public EliminarSede()
        {
            InitializeComponent();
        }

        private void EliminarSede_Load(object sender, EventArgs e)
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
            }
            else
            {
                MessageBox.Show("Id inválido.", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button3_Click(null, null);
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest($"/sede/id/{textBox1.Text}", Method.Get);
            RestResponse result = client.Execute(request);
            if (textBox1.Text.Trim() == ""
                || textBox2.Text.Trim() == ""
                || textBox3.Text.Trim() == ""
                || textBox4.Text.Trim() == ""
                || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, primero busque y encuentre la sede que desea eliminar y verifique la información antes de continuar.", "Precaución");
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                MessageBox.Show("Sede no encontrado.", "Error");
            }
            else if (result.StatusCode == HttpStatusCode.OK)
            {
                DialogResult decision = MessageBox.Show("¿Estás seguro de que quieres eliminar la sede?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (decision == DialogResult.Yes)
                {
                    options = new RestClientOptions("http://localhost:8080");
                    client = new RestClient(options);
                    request = new RestRequest($"/sede/{textBox1.Text}", Method.Delete);
                    RestResponse new_result = client.Execute(request);
                    if (new_result.StatusCode == HttpStatusCode.OK)
                    {
                        MessageBox.Show("La sede ha sido eliminada exitosamente.", "Información");
                        textBox1.ResetText();
                        textBox2.ResetText();
                        textBox3.ResetText();
                        textBox4.ResetText();
                        textBox5.ResetText();
                    }
                    else {
                        MessageBox.Show("Ha ocurrido un error.", "Error");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
