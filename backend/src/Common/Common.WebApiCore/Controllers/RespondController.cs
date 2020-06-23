using Common.Services.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Common.Utils;

namespace Common.WebApiCore.Controllers
{
    [Route("respond")]
    public class RespondController : BaseApiController
    {
        private readonly IRespondRepository _respondRepos;

        public RespondController(IRespondRepository respondRepos)
        {
            _respondRepos = respondRepos;
        }

        [HttpGet]
        [Route("get")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var entity = await _respondRepos.GetAll().ToListAsync();
            return Ok(entity);
        }

        [HttpPost]
        [Route("add")]
        [AllowAnonymous]
        public async Task<IActionResult> Add(Respond dto)
        {

            var entity = dto.MapTo<Respond>();

            await _respondRepos.AddAsync(entity);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        [AllowAnonymous]
        public IActionResult Update(Respond dto)
        {

            var entity = dto.MapTo<Respond>();

            _respondRepos.Update(entity);
            return Ok();
        }

        [HttpGet]
        [Route("remove/{id:int}")]
        [AllowAnonymous]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            _respondRepos.Remove(id);
            return Ok();
        }
    }
}