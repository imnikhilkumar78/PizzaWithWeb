using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PizzaApplication.Models;
using PizzaApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApplication.Services
{
    public class OrderService
    {
        public OrderService(ILogger<OrderService> logger)
        {
            _logger = logger;
        }
        static readonly HttpClient client = new HttpClient();
        private readonly ILogger<OrderService> _logger;

        public async Task<IEnumerable<OrderDTO>> GetAll(string token)
        {
            IEnumerable<OrderDTO> orders = null;

            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:38772/api/Order");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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

        public async Task<OrderDTO> AddOrder(UserDTO userDTO, string token)
        {
            OrderDTO order = new OrderDTO();
            try
            {


                var json = Newtonsoft.Json.JsonConvert.SerializeObject(userDTO);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var url = "http://localhost:38772/api/Order";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
        public async Task<OrderDetailDTO> AddPizza(PizzaDTO pizza, string token)
        {
            OrderDetailDTO order = new OrderDetailDTO();
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(pizza);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var url = "http://localhost:38772/api/Order/Pizza";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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

        public async Task<ToppingDetailDto> AddTopping(ToppingDTO toppingDto, string token)
        {
            ToppingDetailDto topping = new ToppingDetailDto();
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(toppingDto);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var url = "http://localhost:38772/api/Order/Topping";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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

        public OrderDTO Get(int id, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:38772/api/");
                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
        public string summary()
        {
            try
            {

            
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:60809/api/");
                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var getdata = client.GetAsync("Order/summary");
                    //getdata.Wait();
                    if (getdata.Result.IsSuccessStatusCode)
                    {
                    var data = getdata.Result.Content.ReadAsStringAsync();
                    data.Wait();
                    return data.Result;
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

