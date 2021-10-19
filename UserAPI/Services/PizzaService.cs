using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UserPizzaAPI.Models;

namespace UserPizzaAPI.Services
{
    public class PizzaService
    {
        public ICollection<PizzaDTO> GetAll()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:33854/api/");
                    var getdata = client.GetFromJsonAsync<ICollection<PizzaDTO>>("Pizza");
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
        public PizzaDTO Get(int id)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    //PizzaDTO pizza = new PizzaDTO() { ID = id };

                    //var value = new List<KeyValuePair<int, int>>();
                    //value.Add(new KeyValuePair<int, int>(id, id));
                    client.BaseAddress = new Uri("http://localhost:33854/api/");

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
