namespace LIstaProductos.Client.Servicios
{
    public class HttpRespuesta<T>
    {
        public T Respuesta { get; set; }

        public bool Error { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }

        public HttpRespuesta(T repuesta, bool error, HttpResponseMessage httpResponseMessage)
        {
            this.Respuesta = repuesta;
            this.Error = error;
            this.HttpResponseMessage = httpResponseMessage;
        }

        public async Task<string> ObtenerError()
        {
            if(!Error)
            {
                return "";
            }

            var CodigoStatus = HttpResponseMessage.StatusCode;

            switch (CodigoStatus)
            {
                case System.Net.HttpStatusCode.NotFound:
                    return "Error, dirección no encontrada";
                    break;
                case System.Net.HttpStatusCode.BadRequest:
                    return "Error, No sepuede procesar la información enviada";
                    break;

                default:
                    return HttpResponseMessage.Content.ReadAsStringAsync().Result;  
                    break;
            }

        }
    }
}
