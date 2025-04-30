using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Terapix.API.Filters;
using Terapix.CORE.DTOs;
using Terapix.CORE.Models;
using Terapix.CORE.Services;
using Terapix.SERVICE.Services;

namespace Terapix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : CustomBaseController
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var patients = _patientService.GetAll();
            var dtos = _mapper.Map<List<PatientDto>>(patients).ToList();
            return CreateActionResult(CustomResponseDto<List<PatientDto>>.Success(200, dtos));
        }
        [Authorize]
        [ServiceFilter(typeof(NotFoundFilter<Patient>))]
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {

            var patient = await _patientService.GetByIdAssync(id);
            var patientDto = _mapper.Map<PatientDto>(patient);
            return CreateActionResult(CustomResponseDto<PatientDto>.Success(200, patientDto));
        }
        [Authorize]
        [ServiceFilter(typeof(NotFoundFilter<Patient>))]
        [HttpDelete("[action]")]
        public async Task<IActionResult> Remove(int id)
        {

            var patient = await _patientService.GetByIdAssync(id);

            await _patientService.RemoveAsync(patient);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Save(PatientDto patientDto)
        {

            var processedEntity = _mapper.Map<Patient>(patientDto);

            var patient = await _patientService.AddyAsync(processedEntity);

            var patientResponseDto = _mapper.Map<PatientDto>(patient);

            return CreateActionResult(CustomResponseDto<PatientDto>.Success(201, patientDto));


        }
    }
}

