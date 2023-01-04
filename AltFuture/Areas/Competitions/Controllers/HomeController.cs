using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltFuture.Areas.Competitions.Services;
using Microsoft.AspNetCore.Authorization;

namespace AltFutureWeb.Areas.Competitions.Controllers
{
    [Area("Competitions")]
    [Authorize]
    [Authorize(Policy = "CompetitionPlayerPolicy")]
    public class HomeController : AltFuture.Controllers.BaseController
    {

        private LKCompetitionTypeRepository _lkCompetitionTypeRepository;
        private CompetitionRepository _competitionRepository;
        private CompetitionPlayerRepository _competitionPlayerRepository;


        public HomeController(
            // ILogger<HomeController> logger,
            IConfiguration configuration,
            ISQLService sqlService,
            ILKCompetitionTypeRepository lkCompetitionTypeRepository,
            ICompetitionRepository competitionRepository,
            ICompetitionPlayerRepository competitionPlayerRepository
            ) : base(configuration, sqlService)
        {
            //  _logger = logger;
            _lkCompetitionTypeRepository = (LKCompetitionTypeRepository)lkCompetitionTypeRepository;
            _competitionRepository = (CompetitionRepository)competitionRepository;
            _competitionPlayerRepository = (CompetitionPlayerRepository)competitionPlayerRepository;
           
        }

        public ActionResult Index()
        {
            return View(_competitionPlayerRepository.CompetitionPlayerGetList(0,1, User.UserKey()));
        }

        
    }
}
