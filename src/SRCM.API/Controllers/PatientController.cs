using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRCM.Services.AppService.Interfaces;
using SRCM.Services.AppService.Services;
using SRCM.Domain.Shared.ViewModel;
using SRCM.Domain.Shared.Models;

namespace SRCM.API.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        protected readonly IPatientAppServices _patientAppServices;

        public PatientController(IPatientAppServices patientAppServices)
        {
            _patientAppServices = patientAppServices;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PatientModel>> Get()
        {
            var result = _patientAppServices.Search(a => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<PatientModel> Get(Guid id)
        {
            var result = _patientAppServices.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post([FromBody] PatientViewModel patientViewModel)
        {
            var result = _patientAppServices.Add(patientViewModel);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put(PatientViewModel patientViewModel)
        {
            var result = _patientAppServices.Update(patientViewModel);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _patientAppServices.Remove(id);
            return Ok();
        }
    }
}
