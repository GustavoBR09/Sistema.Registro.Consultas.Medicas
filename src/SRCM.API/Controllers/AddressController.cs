using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRCM.Services.AppService.Interfaces;
using SRCM.Domain.Shared.ViewModel;

namespace SRCM.API.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        protected readonly IAddressAppServices _addressAppServices;

        public AddressController(IAddressAppServices addressAppServices)
        {
            _addressAppServices = addressAppServices;
        }
        [HttpGet]
        public ActionResult<IEnumerable<AddressViewModel>> Get()
        {
            var result = _addressAppServices.Search(a => true);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<AddressViewModel> Get(Guid id)
        {
            var result = _addressAppServices.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post([FromBody] AddressViewModel addressViewModel)
        {
            var result = _addressAppServices.Add(addressViewModel);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Put(AddressViewModel addressViewModel)
        {
            var result = _addressAppServices.Update(addressViewModel);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _addressAppServices.Remove(id);
            return Ok();
        }
    }
}
