using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Clinic.Application.Common;
using Clinic.Application.Exams;
using Clinic.Application.Exams.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Services.Api.Controllers
{
    [ApiController]
    [Route("api/exam")]
    public class ExamController : ControllerBase
    {
        readonly IExamAppService _examAppService;

        public ExamController(IExamAppService examAppService)
        {
            _examAppService = examAppService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _examAppService.Register(request);
            if (result.Success)
                return Ok();
            if (result.Error == Errors.Default.UnprocessableEntity())
                return UnprocessableEntity();
            return BadRequest();
        }

        [HttpGet]
        [Route("filter")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Filter([FromQuery] FilterRequest request)
        {
            var result = await _examAppService.Filter(request);
            if (result.Success)
                return Ok(result.Value);
            if (result.Error == Errors.Default.NotFound())
                return NotFound();
            return BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RecoverById([Required][FromRoute] int id)
        {
            var result = await _examAppService.RecoverById(id);
            if (result.Success)
                return Ok(result.Value);
            if (result.Error == Errors.Default.NotFound())
                return NotFound();
            return BadRequest();
        }

        [HttpPut]
        [Route("activate/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Activate([Required][FromRoute] int id)
        {
            var result = await _examAppService.Activate(id);
            if (result.Success)
                return Ok();
            if (result.Error == Errors.Default.NotFound())
                return NotFound();
            return BadRequest();
        }

        [HttpPut]
        [Route("inactivate/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Inactivate([Required][FromRoute] int id)
        {
            var result = await _examAppService.Inactivate(id);
            if (result.Success)
                return Ok();
            if (result.Error == Errors.Default.NotFound())
                return NotFound();
            return BadRequest();
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> Update([FromBody] UpdateRequest request)
        {
            var result = await _examAppService.Update(request);
            if (result.Success)
                return Ok();
            if (result.Error == Errors.Default.NotFound())
                return NotFound();
            if (result.Error == Errors.Default.UnprocessableEntity())
                return UnprocessableEntity();
            return BadRequest();
        }
    }
}