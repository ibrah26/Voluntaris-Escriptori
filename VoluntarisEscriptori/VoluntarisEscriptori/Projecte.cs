/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace ArmyHammerDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public async void button2_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44302/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/RaçaApi/" + listView1.SelectedItems[0].IndentCount);
                if (response.IsSuccessStatusCode)
                {
                    Raça raça = await response.Content.ReadAsAsync<Raça>();
                    txtInfoRaçaTriada.Text = raça.Informacio;
                    lblNomRaça.Text = raça.Nom;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

*/