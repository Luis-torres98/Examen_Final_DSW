using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiciosWeb.ClienteConsola.ServiceClienteASMX;

namespace ServiciosWeb.ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            //Invocar ASMX
            //ServiceClienteASMX.ServicioClienteSoapClient cliente = new ServiceClienteASMX.ServicioClienteSoapClient();
            //var clientes =  cliente.ObtenerCliente();

            ////Invocar WCF 
            //ServiceClienteWCF.Service1Client clienteWCF = new ServiceClienteWCF.Service1Client();
            //var clientes2 = clienteWCF.ObtenerClientes();

            //Invocar Servicio Rest 

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:13089/");


            var rq = clienteHttp.GetAsync("api/Cliente").Result;

            if (rq.IsSuccessStatusCode)
            {

                var resultString = rq.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<cliente>>(resultString);

                foreach (var item in listado)
                {
                    Console.WriteLine(item.Nombres);
                }
                Console.ReadLine();
            }
            //clienteHttp.PostAsync();
            //clienteHttp.PutAsync();
            //clienteHttp.DeleteAsync();
        }
    }
}
