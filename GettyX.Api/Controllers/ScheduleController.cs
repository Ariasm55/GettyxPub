using AutoMapper;
using Getty.Core.Entities;
using Getty.Core.DTOs;
using Getty.Core.Interfaces;
using GettyX.Api.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GettyX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public ScheduleController(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        [HttpGet("{user}")]
        public async Task<IActionResult> GetCurrentSchedule(string user)
        {

            var schedule = await _scheduleRepository.GetSchedule(user);

            var _schedule = _mapper.Map<List<SchdScheduleDayDTO>>(schedule);

            var response = new ApiResponse<List<SchdScheduleDayDTO>>(_schedule);

            return Ok(response);

        }

        [HttpGet("punches")]
        public async Task<IActionResult> GetPunches(string user)
        {
            var punches = await _scheduleRepository.GetPunches(user);
            var _punches = _mapper.Map<List<PnchPunchClockDTO>>(punches);

            var response = new ApiResponse<List<PnchPunchClockDTO>>(_punches);

            return Ok(response);

        }
        [HttpPost("InsertPunch")]
        public  IActionResult InsertPunch(PnchPunchClockDTO punch)
        {
            var _punch = _mapper.Map<PnchPunchClock>(punch);

            _scheduleRepository.InsertPunch(_punch);

            punch = _mapper.Map<PnchPunchClockDTO>(_punch);

            var response = new ApiResponse<PnchPunchClockDTO>(punch);

            return Ok(response);

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSchedules()
        {
            var _schedules = await  _scheduleRepository.GetSchedules();
            var _schedulesDTO = _mapper.Map<List<SchScheduleDTO>>(_schedules);
            var response = new ApiResponse<List<SchScheduleDTO>>(_schedulesDTO);
            return Ok(response);


        }

        [HttpPost("NewScheduleWeek")]
        public  IActionResult NewScheduleDetails(List<SchdScheduleDayDTO> week)
        {
             
            var _scheduledays =  _mapper.Map<List<SchdScheduleDay>>(week);
             _scheduleRepository.NewWeek(_scheduledays);

            return Ok();

        }
        [HttpPost("NewSchedule")]

        public IActionResult NewSchedule(SchScheduleDTO schedule)
        {
            var _schedule = _mapper.Map<SchSchedule>(schedule);
            _scheduleRepository.NewSchedule(_schedule);

            return Ok();
        }
        


    }
}
