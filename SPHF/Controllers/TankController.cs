using Microsoft.AspNetCore.Mvc;
using SPHF.Models;
using SPHF.Models.Services;
using SPHF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPHF.Controllers
{
    [Route("api/tanks")]
    [ApiController]
    public class TankController : ControllerBase
    {
        private readonly ITankService _tankService;
        public TankController(ITankService tankService)
        {
            _tankService = tankService;
        }
        // GET: api/<TankController>
        [HttpGet]
        public IEnumerable<Tank> Get()
        {
            return _tankService.GetAll();
        }

        // GET api/<TankController>/5
        [HttpGet("{id}")]
        public Tank Get(int id)
        {
            return _tankService.FindById(id);
        
        }

        // POST api/<TankController>
        [HttpPost]
        public void Post([FromBody] TankCreateViewModel createTank)
        {
            Tank tank = _tankService.Create(createTank);
            if (tank != null)
            {
                Response.StatusCode = 201;
            }
            Response.StatusCode = 400;// You did a really BAD request
        }

        // PUT api/<TankController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TankCreateViewModel editTank)
        {
            _tankService.Edit(id, editTank);
        }

        // DELETE api/<TankController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tankService.Remove(id);
        }
    }
}
