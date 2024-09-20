using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FragranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FragranceController : Controller
    {
        private readonly IFragranceService _fragranceService;

        public FragranceController(IFragranceService fragranceService)
        {
            _fragranceService = fragranceService;
        }
    }
}
