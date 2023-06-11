using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Workorder.API.Data;
using Workorder.API.Models;

namespace Workorder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaborsController : ControllerBase
    {
        private readonly ILogger<LaborsController> _logger;
        private readonly LaborDataContext _context;

        public LaborsController(ILogger<LaborsController> logger, LaborDataContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Labor>> Get()
        {
            return await _context.Labor.Find(s => true).ToListAsync();
        }
    }
}
