using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRCM.Services.AppService.Interfaces;
using SRCM.Domain.Shared.ViewModel;
using SRCM.Domain.Shared.Models;

namespace SRCM.API.Controllers
{
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        protected readonly IStaffAppServices _staffAppServices;

        public StaffController(IStaffAppServices staffAppServices)
        {
            _staffAppServices = staffAppServices;
        }
        [HttpGet]
        public ActionResult<IEnumerable<StaffModel>> Get()
        {
            var result = _staffAppServices.Search(a => true);
            return Ok(result);
        }

        [HttpGet("model/{id}")]
        public ActionResult<StaffModel> Get(Guid id)
        {
            var result = _staffAppServices.GetModelById(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<StaffViewModel> GetById(Guid id)
        {
            var result = _staffAppServices.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post([FromBody] StaffViewModel staffViewModel)
        {
            var result = _staffAppServices.Add(staffViewModel);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put(StaffViewModel staffViewModel)
        {
            var result = _staffAppServices.Update(staffViewModel);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _staffAppServices.Remove(id);
            return Ok();
        }
    }
}
