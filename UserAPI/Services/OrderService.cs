using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UserPizzaAPI.Models;

namespace UserPizzaAPI.Services
{
    public class OrderService
    {
        static readonly HttpClient client = new HttpClient();
        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            IEnumerable<OrderDTO> orders = null;

            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:60809/api/Order");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                orders = JsonConvert.DeserializeObject<ICollection<OrderDTO>>(responseBody);
                Debug.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
            }
            return orders;
        }

        public async Task<OrderDTO> AddOrder(UserDTO userDTO)
        {
            OrderDTO order = new OrderDTO();
            try
            {


                var json = Newtonsoft.Json.JsonConvert.SerializeObject(userDTO);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var url = "http://localhost:60809/api/Order";


                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(result);
                order = JsonConvert.DeserializeObject<OrderDTO>(result);

            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
            }
            return order;
        }
        public async Task<OrderDetailDTO> AddPizza(PizzaDTO pizza)
        {
            OrderDetailDTO order = new OrderDetailDTO();
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(pizza);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var url = "http://localhost:60809/api/Order/Pizza";


                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(result);
                order = JsonConvert.DeserializeObject<OrderDetailDTO>(result);

            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
            }
            return order;
        }

        public async Task<ToppingDetailDto> AddTopping(ToppingDTO toppingDto)
        {
            ToppingDetailDto topping = new ToppingDetailDto();
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(toppingDto);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var url = "http://localhost:60809/api/Order/Topping";

                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(result);
                topping = JsonConvert.DeserializeObject<ToppingDetailDto>(result);

            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
            }
            return topping;
        }


        public OrderDTO Get(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:60809/api/");
                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                    var getdata = client.GetFromJsonAsync<OrderDTO>("Order/" + id);
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
