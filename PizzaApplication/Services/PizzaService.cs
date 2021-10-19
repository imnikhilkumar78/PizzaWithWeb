using PizzaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzaApplication.Services
{
    public class PizzaService
    {
        /* public string GetAll(string token)
         {
             string PizzaList = null;

             using (var client = new HttpClient())
             {

                 client.BaseAddress = new Uri("http://localhost:38772/api/");
                 client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                 var getTask = client.GetAsync("Pizza");
                 getTask.Wait();
                 var result = getTask.Result;
                 if (result.IsSuccessStatusCode)
                 {
                     var data = result.Content.ReadAsStringAsync();
                     data.Wait();
                     PizzaList = data.Result;
                 }


             }
             return PizzaList;
         }*/
        public ICollection<PizzaDTO> GetAll(string Token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:38772/api/");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
                    var getdata = client.GetFromJsonAsync<ICollection<PizzaDTO>>("Pizza/GetPizza");
                    //Console.WriteLine("The number of COUNT"+getdata.Result.Count);


                    if (getdata != null)
                    {

                        return getdata.Result;

                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public PizzaDTO Get(int id, string Token)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:38772/api/");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                    var getdata = client.GetFromJsonAsync<PizzaDTO>("Pizza/" + id);
                    getdata.Wait();
                    if (getdata != null)
                    {
                        return getdata.Result;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

    }
}
