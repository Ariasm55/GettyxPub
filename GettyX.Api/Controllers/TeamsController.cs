using AutoMapper;
using Getty.Core.DTOs;
using Getty.Core.Entities;
using Getty.Core.Interfaces;
using GettyX.Api.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GettyX.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsRepository _teamrepository;
        private readonly IMapper _mapper;

        public TeamsController(ITeamsRepository teamrepository, IMapper mapper)
        {
            _teamrepository = teamrepository;

            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var _teams = await _teamrepository.GetTeams();
            var _teamsDTO = _mapper.Map<IEnumerable<TmsTeamDTO>>(_teams);
            var response = new ApiResponse<IEnumerable<TmsTeamDTO>>(_teamsDTO);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {

            var _teams = await _teamrepository.GetTeam(id);
            var _teamsDTO = _mapper.Map<TmsTeamDTO>(_teams);
            var response = new ApiResponse<TmsTeamDTO>(_teamsDTO);

            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> NewTeam(TmsTeamDTO _teamDTO)
        {
            var _team = _mapper.Map<TmsTeam>(_teamDTO);

            await _teamrepository.NewTeam(_team);

            _teamDTO = _mapper.Map<TmsTeamDTO>(_team);

            var response = new ApiResponse<TmsTeamDTO>(_teamDTO);

            return Ok(response);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateTeam(int TeamID, TmsTeamDTO TeamDTO)
        {
            var _team = _mapper.Map<TmsTeam>(TeamDTO);
            _team.TmsId = TeamID;

            var result = await _teamrepository.UpdateTeam(_team);

            var response = new ApiResponse<bool>(result);

            return Ok(response);

        }

        [HttpDelete("{TeamID}")]
        public async Task<IActionResult> DeleteEmployee(int TeamID)
        {
            var result = await _teamrepository.DeleteTeam(TeamID);
            var response = new ApiResponse<bool>(result);

            return Ok(response);

        }


    }
}
