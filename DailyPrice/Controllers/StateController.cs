using Microsoft.AspNetCore.Mvc; 
using DailyPrice.API.BusinessLogic.Services.Shared;

namespace DailyPrice.Controllers
{
    [Route("api/[controller]")]
    public class StateController : Controller
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            this._stateService=stateService;
        }

          // GET api/values
        [HttpGet]
        public IActionResult GetStates()
        {
          var states=_stateService.GetStates();
          return new OkObjectResult(states);
        }

    
    }
}