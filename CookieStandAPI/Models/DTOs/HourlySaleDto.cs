using CookieStandApi.Models.Entities;
using CookieStandAPI.Models.DTOs;

namespace CookieStandAPI.Models.DTOs
{
    public class HourlySaleDto
    {
        public int Id { get; set; }
        public int Hour { get; set; }
        public int Sales { get; set; }

        public int CookieStandId { get; set; }

        public CookieStandDto? CookieStand { get; set; }
    }
}

