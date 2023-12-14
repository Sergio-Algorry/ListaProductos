
namespace LIstaProductos.Client.Servicios
{
    public interface IHttpServicio
    {
        Task<T> DesSerializador<T>(HttpResponseMessage response);
        Task<HttpRespuesta<T>> Get<T>(string url);
        Task<HttpRespuesta<object>> Post<T>(string url, T enviar);
        Task<HttpRespuesta<object>> Delete(string url);
    }
}