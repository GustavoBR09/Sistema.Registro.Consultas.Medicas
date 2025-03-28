﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRCM.Services.AppService.Interfaces;
using SRCM.Domain.Shared.ViewModel;
using SRCM.Domain.Shared;
using SRCM.Domain.Shared.Models;
using SRCM.Services.AppService.Services;

namespace SRCM.API.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        protected readonly IDoctorAppServices _doctorAppServices;

        public DoctorController(IDoctorAppServices doctorAppServices)
        {
            _doctorAppServices = doctorAppServices;
        }
        [HttpGet]
        public ActionResult<IEnumerable<DoctorModel>> Get()
        {
            var result = _doctorAppServices.Search(a => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<DoctorViewModel> Get(Guid id)
        {
            var result = _doctorAppServices.GetById(id);
            return Ok(result);
        }
        [HttpGet("search/{filter}")]
        public ActionResult<IEnumerable<DoctorModel>> Get(string filter)
        {
            var result = _doctorAppServices.Search(a => a.Name.ToUpper().Contains(filter.ToUpper()) ||
            a.Cpf == filter ||
            a.Email.ToUpper().Contains(filter.ToUpper()) ||
            a.Crm == filter);

            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post([FromBody] DoctorViewModel doctorViewModel)
        {
            var result = _doctorAppServices.Add(doctorViewModel);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put(DoctorViewModel doctorViewModel)
        {
            var result = _doctorAppServices.Update(doctorViewModel);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _doctorAppServices.Remove(id);
            return Ok();
        }
    }
}
