using AutoMapper;
using Getty.Core.DTOs;
using Getty.Core.Entities;

//using Getty.Core.Entities;
namespace Getty.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Campaigns
            CreateMap<CampCampaign, CampCampaignDTO>().ReverseMap();
            //Country
            CreateMap<CntCountry, CntCountryDTO>().ReverseMap();

            //Employee
            CreateMap<EmpEmployee, EmpEmployeeDTO>().ReverseMap();

            //Employee Schedule
            CreateMap<EschEmployeeSchedule, EschEmployeeScheduleDTO>().ReverseMap();

            //Schedule days
            CreateMap<SchdScheduleDay, SchdScheduleDayDTO>().ReverseMap();

            //Schedules 
            CreateMap<SchSchedule, SchScheduleDTO>().ReverseMap();

            //Sites
            CreateMap<StsSite, StsSiteDTO>().ReverseMap();

            //team members
            CreateMap<TmmbTeamMember, TmmbTeamMemberDTO>().ReverseMap();

            //teams
            CreateMap<TmsTeam, TmsTeamDTO>().ReverseMap();

            //User Roles
            CreateMap<UsrlUserRole, UsrlUserRoleDTO>().ReverseMap();

            //Punches
            CreateMap<PnchPunchClock, PnchPunchClockDTO>().ReverseMap();

            //Users
            CreateMap<UsrUser, UsrUserDTO>().ReverseMap()
                .ForMember(x => x.UsrSalt , x => x.Ignore());

        }
    }
}
