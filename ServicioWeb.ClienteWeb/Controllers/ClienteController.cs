﻿using Newtonsoft.Json;
using ServiciosWeb.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;

namespace ServicioWeb.ClienteWeb.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:13089/");


            var rq = clienteHttp.GetAsync("api/Cliente").Result;

            if (rq.IsSuccessStatusCode)
            {

                var resultString = rq.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Cliente>>(resultString);

                return View(listado);
            }
            return View(new List<Cliente>());
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Cliente cliente)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:13089/");


            var rq = clienteHttp.PostAsync("api/Cliente", cliente, new JsonMediaTypeFormatter()).Result;

            if (rq.IsSuccessStatusCode)
            {

                var resultString = rq.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            return View(cliente);

            
        }


        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:13089/");


            var rq = clienteHttp.GetAsync("api/Cliente?id="+ id).Result;

            if (rq.IsSuccessStatusCode)
            {

                var resultString = rq.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<Cliente>(resultString);

               
                return View(informacion);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(Cliente cliente)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:13089/");


            var rq = clienteHttp.PutAsync("api/Cliente", cliente, new JsonMediaTypeFormatter()).Result;

            if (rq.IsSuccessStatusCode)
            {

                var resultString = rq.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            return View(cliente);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:13089/");


            var rq = clienteHttp.DeleteAsync("api/Cliente?id=" + id).Result;

            if (rq.IsSuccessStatusCode)
            {

                var resultString = rq.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }


        [HttpGet]
        public ActionResult Detalle(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:13089/");


            var rq = clienteHttp.GetAsync("api/Cliente?id=" + id).Result;

            if (rq.IsSuccessStatusCode)
            {

                var resultString = rq.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<Cliente>(resultString);


                return View(informacion);
            }
            return View();
        }

    }
}