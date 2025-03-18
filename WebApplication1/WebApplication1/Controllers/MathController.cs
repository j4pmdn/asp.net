using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class MathController : Controller
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
}
