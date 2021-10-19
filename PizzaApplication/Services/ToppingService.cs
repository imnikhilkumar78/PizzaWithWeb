using PizzaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzaApplication.Services
{
    public class ToppingService
    {
        public ICollection<ToppingDTO> GetAll(string Token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:38772/api/");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
                    var getdata = client.GetFromJsonAsync<ICollection<ToppingDTO>>("Topping/GetTopping");
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

        public ToppingDTO Get(int id, string Token)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:38772/api/");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                    var getdata = client.GetFromJsonAsync<ToppingDTO>("Topping/" + id);
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
