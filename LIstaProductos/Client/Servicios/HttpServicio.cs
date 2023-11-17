using System.Text.Json;

namespace LIstaProductos.Client.Servicios
{
    //GET
    //POST
    //PUT
    //DELETE
    public class HttpServicio : IHttpServicio
    {
        private readonly HttpClient http;

        public HttpServicio(HttpClient http)
        {
            this.http = http;
        }

        public async Task<HttpRespuesta<T>> Get<T>(string url)
        {
            var response = await http.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerializador<T>(response);
                return new HttpRespuesta<T>(respuesta, false, response);
            }
            else
            {
                return new HttpRespuesta<T>(default, true, response);
            }
        }


        public async Task<T> DesSerializador<T>(HttpResponseMessage response)
        {
            var respuestaStr = await response.Content.ReadAsStringAsync();

            var res = JsonSerializer.Deserialize<T>(respuestaStr,
                         new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return res;
        }

    }
}
