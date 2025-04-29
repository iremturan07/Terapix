using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Terapix.API.Filters;
using Terapix.CORE.DTOs;
using Terapix.CORE.Models;
using Terapix.CORE.Services;

namespace Terapix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : CustomBaseController
    {
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;

        public MedicationController(IMedicationService medicationService, IMapper mapper)
        {
            _medicationService = medicationService;
            _mapper = mapper;
        } 
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var medications = _medicationService.GetAll();
            var dtos = _mapper.Map<List<MedicationDto>>(medications).ToList();
            return CreateActionResult(CustomResponseDto<List<MedicationDto>>.Success(200, dtos));
        }
        [Authorize]
        [ServiceFilter(typeof(NotFoundFilter<Medication>))]
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {

            var medication = await _medicationService.GetByIdAssync(id);
            var medicationDto = _mapper.Map<MedicationDto>(medication);
            return CreateActionResult(CustomResponseDto<MedicationDto>.Success(200, medicationDto));
        }
        [Authorize]
        [ServiceFilter(typeof(NotFoundFilter<Medication>))]
        [HttpDelete("[action]")]
        public async Task<IActionResult> Remove(int id)
        {

            var medication= await _medicationService.GetByIdAssync(id);

            _medicationService.ChangeStatus(medication);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Save(MedicationDto medicationDto)
        {

            var processedEntity = _mapper.Map<Medication>(medicationDto);

            var medication = await _medicationService.AddyAsync(processedEntity);

            var medicationResponseDto = _mapper.Map<MedicationDto>(medication);

            return CreateActionResult(CustomResponseDto<MedicationDto>.Success(201, medicationDto));


        }
    }
}

