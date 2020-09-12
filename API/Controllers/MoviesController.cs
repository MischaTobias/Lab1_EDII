using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Helpers;
using API.Models;
using Lab1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        [HttpGet]
        public List<Movies> GetMovies()
        {
            return new List<Movies>();
        }

        [HttpGet]
        [Route("{traversal}")]
        public List<Movies> GetMovies(string traversal)
        {
            switch (traversal)
            {
                case "preorden":
                    return Storage.Instance.MoviesTree.GetPathing(0);
                case "inorden":
                    return Storage.Instance.MoviesTree.GetPathing(1);
                case "postorden":
                    return Storage.Instance.MoviesTree.GetPathing(2);
            }
            return new List<Movies>();
        }

        [HttpPost]
        public IActionResult PostTreeOrder([FromForm]IFormFile file)
        {
            using var content = new MemoryStream();
            try
            {
                file.CopyToAsync(content);
                var text = Encoding.ASCII.GetString(content.ToArray());
                var order = JsonSerializer.Deserialize<int>(text);
                Storage.Instance.MoviesTree = new MultipathTree<Movies>(order);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("populate")]
        public IActionResult PostMovies([FromForm]IFormFile file)
        {
            using var content = new MemoryStream();
            try
            {
                file.CopyToAsync(content);
                var text = Encoding.ASCII.GetString(content.ToArray());
                var Movies = JsonSerializer.Deserialize<List<Movies>>(text, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                foreach (var movie in Movies)
                {
                    Storage.Instance.MoviesTree.AddValue(movie);
                }
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
