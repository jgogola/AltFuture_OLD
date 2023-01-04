using Microsoft.AspNetCore.Mvc;
using AltFuture.Services;

namespace AltFuture.Controllers
{
     
    public class BaseController : Controller
    {
        private IConfiguration _configuration;

        private SQLService _db;
        public SQLService DB
        {
            get { return _db; }
        }

        public BaseController(IConfiguration configuration, ISQLService sqlService)
        {
            _configuration = configuration;
            _db = (SQLService)sqlService;
        }
    }
}
