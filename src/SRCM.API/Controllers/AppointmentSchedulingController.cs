using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRCM.Services.AppService.Interfaces;
using SRCM.Services.AppService.Services;
using SRCM.Domain.Shared.ViewModel;

namespace SRCM.API.Controllers
{
    [Route("api/appointment-scheduling")]
    [ApiController]
    public class AppointmentSchedulingController : ControllerBase
    {
        protected readonly IAppointmentSchedulingAppServices _appointmentSchedulingAppServices;

        public AppointmentSchedulingController(IAppointmentSchedulingAppServices appointmentSchedulingAppServices)
        {
            _appointmentSchedulingAppServices = appointmentSchedulingAppServices;
        }
        [HttpGet]
        public ActionResult<IEnumerable<AppointmentSchedulingViewModel>> Get()
        {
            var result = _appointmentSchedulingAppServices.Search(a => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<AppointmentSchedulingViewModel> Get(Guid id)
        {
            var result = _appointmentSchedulingAppServices.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post([FromBody] AppointmentSchedulingViewModel appointmentSchedulingViewModel)
        {
            var result = _appointmentSchedulingAppServices.Add(appointmentSchedulingViewModel);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put(AppointmentSchedulingViewModel appointmentSchedulingViewModel)
        {
            var result = _appointmentSchedulingAppServices.Update(appointmentSchedulingViewModel);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _appointmentSchedulingAppServices.Remove(id);
            return Ok();
        }
        [HttpGet("exibition/{date}/{name}")]
        public ActionResult GetExibitionSchedules(DateTime? date, string? name)
        {
            var result = _appointmentSchedulingAppServices.GetAppointmentScheduling(date, name);
            return Ok(result);
        }
        [HttpGet("exibition/{date}")]
        public ActionResult GetExibitionSchedules(DateTime? date)
        {
            var result = _appointmentSchedulingAppServices.GetAppointmentScheduling(date, null);
            return Ok(result);
        }
        [HttpGet("exibition")]
        public ActionResult GetExibitionSchedules()
        {
            var result = _appointmentSchedulingAppServices.GetAppointmentScheduling(null, null);
            return Ok(result);
        }
    }
}
