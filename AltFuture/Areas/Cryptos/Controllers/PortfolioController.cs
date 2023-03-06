using AltFuture.Areas.Cryptos.Models;
using AltFuture.Areas.Cryptos.Models.APIModels;
using AltFutureWeb.Areas.Cryptos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AltFuture.Areas.Cryptos.Controllers
{
    [Area("Cryptos")]
    [Authorize]
    public class PortfolioController : AltFuture.Controllers.BaseController
    {
        // private readonly ILogger<HomeController> _logger;
        private CryptoPortfolioRepository _cryptoPortfolioRepository;
        private LKCryptoRepository _lkCryptoRepository;
        private CryptoAPIRepository _cryptoAPIRepository;
        private CryptoPriceRepository _cryptoPriceRepository;


        public PortfolioController(
            // ILogger<HomeController> logger,
            IConfiguration configuration,
            ISQLService sqlService,
            ICryptoPortfolioRepository cryptoPortfolioRepository,
            ILKCryptoRepository lkCryptoRepository,
            ICryptoAPIRepository cryptoAPIRepository,
            ICryptoPriceRepository cryptoPriceRepository
            ) : base(configuration, sqlService)
        {
            //  _logger = logger;
            _cryptoPortfolioRepository = (CryptoPortfolioRepository)cryptoPortfolioRepository;
            _lkCryptoRepository = (LKCryptoRepository)lkCryptoRepository;
            _cryptoAPIRepository = (CryptoAPIRepository)cryptoAPIRepository;
            _cryptoPriceRepository = (CryptoPriceRepository)cryptoPriceRepository;

        }

        
        [Authorize(Policy = "CryptoViewPolicy")]
        public IActionResult Index()
        {
            return View(_cryptoPortfolioRepository.CryptoPortfolioGetList());
        }

        public IActionResult UpdateCryptoPricesAPI()
        {
            return View();
        }


        //[Authorize(Policy = "CryptoAdminPolicy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCryptoPricesAPI(int id)
        {
            try
            {
                List<LK_Crypto> lkCryptos = _lkCryptoRepository.LKCryptoGetList();
                if (lkCryptos != null)
                {
                    List<string> ticker_symbols = lkCryptos.Select(c => c.ticker_symbol).ToList();

                    List<Crypto> cryptoQuotes = _cryptoAPIRepository.APICoinMarketCapQuotesGetList(ticker_symbols);
                    if (cryptoQuotes != null)
                    {
                        foreach (Crypto cryptoQuote in cryptoQuotes)
                        {
                            _cryptoPriceRepository.CryptoPriceAdd(cryptoQuote.symbol, cryptoQuote.quote.USD.price);
                        }
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
