using Microsoft.AspNetCore.Mvc;

namespace salaryservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaryController : ControllerBase
    {
        [HttpGet]
        public string GetSalary()
        {
            double baseSalary = 70000.0;///оклад
            int bonus;///премия в процентах от оклада
            Random rnd = new Random();
            bonus = rnd.Next(50, 100);
            return Convert.ToString(baseSalary + baseSalary * bonus / 100);
        }
    }
}
