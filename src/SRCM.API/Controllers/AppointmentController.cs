using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRCM.Services.AppService.Interfaces;
using SRCM.Domain.Shared.ViewModel;

namespace SRCM.API.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        protected readonly IAppointmentAppServices _appointmentAppServices;

        public AppointmentController(IAppointmentAppServices appointmentAppServices)
        {
            _appointmentAppServices = appointmentAppServices;
        }
        [HttpGet]
        public ActionResult<IEnumerable<AppointmentViewModel>> Get()
        {
            var result = _appointmentAppServices.Search(a => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<AppointmentViewModel> Get(Guid id)
        {
            var result = _appointmentAppServices.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post([FromBody] AppointmentViewModel appointmentViewModel)
        {
            var result = _appointmentAppServices.Add(appointmentViewModel);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put(AppointmentViewModel appointmentViewModel)
        {
            var result = _appointmentAppServices.Update(appointmentViewModel);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _appointmentAppServices.Remove(id);
            return Ok();
        }
    }
}
