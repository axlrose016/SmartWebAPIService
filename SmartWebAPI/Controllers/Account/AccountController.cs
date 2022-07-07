using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartRepository.Core.Models;
using SmartRepository.Core.Repositories;
using SmartRepository.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWebAPI.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRepository<User> context;
        public AccountController(IRepository<User> _context)
        {
            context = _context;
        }
        [HttpGet, Route("GetAccount/{id}")]
        public async Task<ActionResult> GetAccount([FromRoute] Guid id)
        {
            try
            {
                var account = await context.Get(id);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest($"GetAccount: {ex}");
            }
        }

        [HttpGet, Route("GetAllAccount")]
        public async Task<ActionResult> GetAllAccount()
        {
            try
            {
                var accounts = await context.GetAll();
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return BadRequest($"GetAllAccount: {ex}");
            }
        }
    }
}
