namespace CookieStandApi.Models.Entities
{
    public class HourlySale
    {
            public int Id { get; set; }
            public int Hour { get; set; }
            public int Sales { get; set; }

            public int CookieStandId { get; set; }

            public CookieStand? CookieStand { get; set; }
        }
}
