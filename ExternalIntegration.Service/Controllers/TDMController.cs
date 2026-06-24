using ExternalIntegration.Service.Sync.DTOs;
using ExternalIntegration.Service.Sync.PMO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExternalIntegration.Service.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TDMController : ControllerBase
    {
     
        public TDMController()
        {
           
        }

      
    }
}
