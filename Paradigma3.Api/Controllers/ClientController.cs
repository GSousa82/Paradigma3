using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paradigma3.Domain.Entities;
using Paradigma3.Domain.Interface.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paradigma3.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientApplication _clientApplication;

        public ClientController(IClientApplication clientApplication)
        {
            _clientApplication = clientApplication;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_clientApplication.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetClient(string clientId)
        {
            try
            {
                return Ok(_clientApplication.GetClient(clientId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertClient([FromBody] Client client)
        {
            try
            {
                _clientApplication.Insert(client);

                //return Created("api/client", client);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateClient([FromBody] Client client, string clientId)
        {
            try
            {
                _clientApplication.UpdateClient(client, clientId);

                client.Id = clientId;

                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteClient(string clientId)
        {
            try
            {
                _clientApplication.DeleteClient(clientId);

                return Ok("Client Id deleted: " + clientId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
