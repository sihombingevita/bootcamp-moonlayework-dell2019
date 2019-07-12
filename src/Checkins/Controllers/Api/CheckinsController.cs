using Barebone.Controllers;
using Checkins.Data.Abstractions;
using Checkins.Data.Entities;
using Checkins.ViewModels.Checkin;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Checkins.Controllers.Api
{
    //[Authorize]
    [Route("api/checkin")]
    public class CheckinsController : ControllerBaseApi
    {
        public CheckinsController(IStorage storage) : base(storage)
        {
        }

        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            IEnumerable<Checkin> data = new CheckinModelFactory().LoadAll(this.Storage, page, size)?.Checkins;
            int count = data.Count();

            return Ok(new
            {
                success = true,
                data,
                count,
                totalPage = ((int)count / size) + 1
            });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var repo = this.Storage.GetRepository<ICheckinRepository>();

            Checkin checkin = repo.WithKey(id);

            if (checkin == null)
                return this.NotFound(new { success = false });
            return Ok(new { success = true, data = checkin });
        }

        [HttpPost]
        public IActionResult Post(CreateViewModels model)
        {
            if (this.ModelState.IsValid)
            {
                Checkin checkin = model.ToEntity();
                var repo = this.Storage.GetRepository<ICheckinRepository>();

                repo.Create(checkin, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }
    }
}
