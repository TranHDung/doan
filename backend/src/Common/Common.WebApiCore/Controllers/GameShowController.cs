using Common.Services.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Common.Utils;
using Common.DTO;
using System.Linq;

namespace Common.WebApiCore.Controllers
{
    [Route("gameshow")]
    public class GameShowController : BaseApiController
    {
        private readonly IGameShowRepository _gameShowRepos;

        public GameShowController(IGameShowRepository gameShowRepos)
        {
            _gameShowRepos = gameShowRepos;
        }

        [HttpGet]
        [Route("get")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var entity = await _gameShowRepos.GetAll().ToListAsync();
            return Ok(entity);
        }

        [HttpGet]
        [Route("open")]
        [AllowAnonymous]
        public async Task<IActionResult> Open()
        {
            var entity = await _gameShowRepos.GetAll().Where(g => g.IsOpen).ToListAsync();
            return Ok(entity);
        }

        [HttpGet]
        [Route("close/{gameShowId:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Close(int gameShowId)
        {
            var entity = await _gameShowRepos.FirstOrDefaultAsync(g => g.Id == gameShowId);
            entity.IsOpen = false;
            _gameShowRepos.Update(entity);
            return Ok();
        }

        [HttpGet]
        [Route("close/{get:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int gameShowId)
        {
            var entity = await _gameShowRepos.FirstOrDefaultAsync(g => g.Id == gameShowId);
            return Ok(entity);
        }

        [HttpPost]
        [Route("add")]
        [AllowAnonymous]
        public async Task<IActionResult> Add(GameShowDTO dto)
        {

            var entity = dto.MapTo<GameShow>();
            entity.IsOpen = true;
            await _gameShowRepos.AddAsync(entity);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        [AllowAnonymous]
        public IActionResult Update(GameShowDTO dto)
        {

            var entity = dto.MapTo<GameShow>();

            _gameShowRepos.Update(entity);
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

            _gameShowRepos.Remove(id);
            return Ok();
        }

        [HttpPost]
        [Route("add-question-gameshow")]
        [AllowAnonymous]
        public async Task<IActionResult> AddUserGameshow(UserGameShow entity)
        {
            await _gameShowRepos.AddUserGameShow(entity);
            return Ok();
        }
    }
}