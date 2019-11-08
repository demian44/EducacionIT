using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClienteWebForm
{
    public partial class ClienteWebAPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.VerAmigos();
            }
        }

        void VerAmigos()
        {
            var t = Task.Run(() => GetURI(new Uri("https://localhost:44340/api/amigos")));
            t.Wait();
            JArray j = JArray.Parse(t.Result);
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(j));
            GVAmigos.DataSource = dt;
            GVAmigos.DataBind();
        }

        static async Task<string> GetURI(Uri uri)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(uri);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
            }

            return response;
        }

        protected void GVAmigos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnIDSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtID.Text))
            {
                return;
            }

            var t = Task.Run(() => GetURI(new Uri("https://localhost:44340/api/amigos/" + this.txtID.Text)));
            t.Wait();
            if (string.IsNullOrWhiteSpace(t.Result))
            {
                this.VerAmigos();
                return;
            }
            else
            {
                this.TraerAmigo(int.Parse(this.txtID.Text));
            }

            var JSONResult = JObject.Parse(t.Result);
            JArray jArray = new JArray { { JSONResult } };
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(jArray));
            GVAmigos.DataSource = dt;
            GVAmigos.DataBind();
        }

        public void TraerAmigo(int id)
        {
            string url = "https://localhost:44340/api/amigos";
            var t = Task.Run(() => GetURI(new Uri(url)));
            t.Wait();
            List<Amigo> friends = JsonConvert.DeserializeObject<List<Amigo>>(t.Result.ToString());

            if (id != 0)
            {
                friends = (from f in friends
                           where f.ID == id
                           select f).ToList();
            }
           
            GVAmigos.DataSource = friends;
            GVAmigos.DataBind();

        }
    }
}