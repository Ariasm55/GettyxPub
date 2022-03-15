
using Getty.Core.DTOs;
using GettyX.Web.Interfaces;
using GettyX.Web.Responses;
using System.Net.Http.Json;

namespace GettyX.Web.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly HttpClient _httpclient;

        public DashboardService( HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        


        public async Task<UserIdentityDTO> GetUsername()
        {
            var CUser = await _httpclient.GetFromJsonAsync<ApiResponse<UserIdentityDTO>>("/api/auth/");

            //Getting Username
            return CUser.Data;
        }


        public async Task<List<SchdScheduleDayDTO>> GetCurrentSchedule(string user)
        {
            //getting response for schedule
            var result = await _httpclient.GetFromJsonAsync<ApiResponse<List<SchdScheduleDayDTO>>>($"/api/Schedule/{user}");

            return result.Data;

        }

        public async Task<List<PnchPunchClockDTO>> TodayPunches(string user)
        {
            //getting punches by user
            var result = await _httpclient.GetFromJsonAsync<ApiResponse<List<PnchPunchClockDTO>>>($"/api/Schedule/punches?user={user}");

            return result.Data;

        }

        public async Task InsertPunch(PnchPunchClockDTO punch)
        {
            await _httpclient.PostAsJsonAsync($"/api/Schedule/InsertPunch", punch);

        }


    }
}
