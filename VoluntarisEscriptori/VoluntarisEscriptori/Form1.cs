using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Net;
using System.IO;


namespace VoluntarisEscriptori
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public async void button1_Click(object sender, EventArgs e)
        {
            getRolsPerPantalla();
        }

        public async void getRolsPerPantalla() {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1099");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                List<Rol> llistaRols = null;

                //var client = new HttpClient();

                var task = client.GetAsync("http://localhost:1099/api/RolsApi")
                  .ContinueWith((taskwithresponse) =>
                  {
                      var response = taskwithresponse.Result;
                      var jsonString = response.Content.ReadAsStringAsync();
                      jsonString.Wait();
                      llistaRols = JsonConvert.DeserializeObject<List<Rol>>(jsonString.Result);

                  });
                task.Wait();

                dataGridView1.Rows.Clear();
                foreach (Rol r in llistaRols)
                {
                    dataGridView1.Rows.Add(r.Name, r.Descripcio, r.Id);
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:1099/api/RolsApi/";
            var client = new HttpClient();

            string id = Guid.NewGuid().ToString();

            
            var values = new Dictionary<string, string>()
            {
                {"Id", id},
                {"Name", textBox1.Text},
                {"Descripcio", textBox2.Text},
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(apiUrl, content);
            string info = response.EnsureSuccessStatusCode().RequestMessage.ToString();        
            
            if(info == null){
                label4.Text = "Error, el rol ja existeix o no compleix l'estandard";
            }else{
                label4.Text = "Rol insertat correctament";

                getRolsPerPantalla();
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            int Columna = e.ColumnIndex;

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



    }
}
