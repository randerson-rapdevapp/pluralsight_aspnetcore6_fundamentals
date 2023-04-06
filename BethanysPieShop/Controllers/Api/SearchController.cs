using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;
        public SearchController(IPieRepository pieRepository)
        {
            this._pieRepository = pieRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var results = this._pieRepository.AllPies;
            if (results.Any())
            {
                return Ok(results);
            }
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _pieRepository.GetPieById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuery)
        {
            IEnumerable<Pie> result = new List<Pie>();
            if (!String.IsNullOrWhiteSpace(searchQuery))
            {
                result = this._pieRepository.SearchPies(searchQuery);
            }
            if (result.Any())
            {
                return Ok(result);
            }
            return NoContent();
        }
    }
}
