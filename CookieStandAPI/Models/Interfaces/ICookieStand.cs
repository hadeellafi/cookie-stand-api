using CookieStandAPI.Models.DTOs;

namespace CookieStandAPI.Models.Interfaces
{
    public interface ICookieStand
    {
        Task<CookieStandDto> Create(CookieStandDto cookieStandDto);
        Task<List<CookieStandDto>> GetCookieStands();
        Task<CookieStandDto> GetCookieStandById(int id);
        Task Delete(int id);
        Task<CookieStandDto> Update(int id, CookieStandDto cookieStandDto);

    }
}
