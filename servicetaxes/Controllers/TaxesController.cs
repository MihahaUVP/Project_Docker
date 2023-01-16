using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace servicetaxes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxesController:ControllerBase
    {
        private HttpClient _client;

        public TaxesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://salaryservice:80/");
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Сервис работает");
        }


        [HttpGet("salary")]
        public IActionResult NetworkRequest()
        {

            var response = _client.GetAsync("Salary").Result;
            string str = response.Content.ReadAsStringAsync().Result;
            str = str.Substring(1, str.Length - 2);
            double salary = Convert.ToDouble(str);
            double taxes = salary * 0.13;
            double result = salary - taxes;
            return Ok("Зарплата до уплаты НДФЛ= "+str+"\nЗарплата после уплаты НДФЛ= "+result);
            //return Ok("Зарплата = " + str);
        }
    }
}
