using black_child_tutoring_services.Models;
using Microsoft.AspNetCore.Mvc;
using black_child_tutoring_services.Controllers;
using System.Data.SqlClient;
using System.Diagnostics;


namespace black_child_tutoring_services.Controllers
{
    public class HomeController : Controller
    {
        public string connectionString = "Server=tcp:st10102523.database.windows.net,1433;Initial Catalog=DjPromoWebsite;Persist Security Info=False;User ID=admin1;Password=kabzaNeo1825;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        //public HomeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //register
        [HttpPost]
        public IActionResult Register(Register Register)
        {
            SqlCommand com;

            SqlConnection cnt = new SqlConnection(connectionString);
            cnt.Open();//open connection
            string query = "INSERT INTO Register (Username,Password,Email,Surname) VALUES (@Username,@Password,@Email,@Surname)";
            com = new SqlCommand(query, cnt);//using the command 


            com.Parameters.AddWithValue("@Username", Register.Username);
            com.Parameters.AddWithValue("@Password", Register.Password);
            com.Parameters.AddWithValue("@Email", Register.Email);
            com.Parameters.AddWithValue("@Surname", Register.Surname);


            com.ExecuteNonQuery();
            cnt.Close();//Close connecting
            return View("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Login(Login log)
        {
            SqlCommand apple;

            SqlConnection cnt = new SqlConnection(connectionString);
            string connectionstring = "Server=tcp:st10102523.database.windows.net,1433;Initial Catalog=DjPromoWebsite;Persist Security Info=False;User ID=admin1;Password=kabzaNeo1825;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";



            cnt.Open();

            string query = "INSERT INTO Login (Email,Password) VALUES (@Email,@Password)";
            SqlCommand com = new SqlCommand(query, cnt);
            com.Parameters.AddWithValue("@Email", log.Email);
            com.Parameters.AddWithValue("@Password", log.Password);

            com.ExecuteNonQuery();
            cnt.Close();//Close connecting
            return View("Index");


        }


        [HttpGet]
        //[Route("login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Donation(Donation model)
        {
            SqlCommand com;

            SqlConnection cnt = new SqlConnection(connectionString);
            cnt.Open();//open connection
            string query = "INSERT INTO Donation (Amount,FullName,Email,Message) VALUES (@Amount,@FullName,@Email,@Message)";
            com = new SqlCommand(query, cnt);//using the command 


            com.Parameters.AddWithValue("@Amount", model.Amount);
            com.Parameters.AddWithValue("@FullName", model.FullName);
            com.Parameters.AddWithValue("@Email", model.Email);
            com.Parameters.AddWithValue("@Message", model.Message);


            com.ExecuteNonQuery();
            cnt.Close();//Close connecting
            return View("ThankYou");
        }
        [HttpGet]
        public IActionResult Donation()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ThankYou()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
      


        public IActionResult Advertisement()
        {
            return View();
        }
        public IActionResult Team()
        {
            return View();
        }
        public IActionResult Timetable()
        {
            return View();
        }
        public IActionResult Branches()
        {
            return View();
        }

    }
    }