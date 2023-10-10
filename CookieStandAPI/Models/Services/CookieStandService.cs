using AutoMapper;
using CookieStandApi.Data;
using CookieStandAPI.Models.DTOs;
using CookieStandApi.Models.Entities;
using CookieStandAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CookieStandService : ICookieStand
{
    private readonly CookieStandDbContext _context;
    private readonly IMapper _mapper;

    public CookieStandService(CookieStandDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CookieStandDto> Create(CookieStandDto cookieStandDto)
    {
        CookieStand cookieStandToAdd = _mapper.Map<CookieStand>(cookieStandDto);

        await _context.CookieStands.AddAsync(cookieStandToAdd);
        await _context.SaveChangesAsync();

        var hourlySalesDtos = await GenerateHourlySales(cookieStandToAdd.Id, cookieStandToAdd.Minimum_Customers_Per_Hour, cookieStandToAdd.Maximum_Customers_Per_Hour, cookieStandToAdd.Average_Cookies_Per_Sale);
        cookieStandToAdd.HourlySales = _mapper.Map<List<HourlySale>>(hourlySalesDtos);

        await _context.SaveChangesAsync();
        cookieStandDto.Id = cookieStandToAdd.Id;

        return await GetCookieStandById(cookieStandToAdd.Id);
    }



    public async Task Delete(int id)
    {
        CookieStand existingCookieStand = await _context.CookieStands.FindAsync(id);
        _context.CookieStands.Remove(existingCookieStand);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CookieStandDto>> GetCookieStands()
    {
        var cookieStands = await _context.CookieStands.Include(cs => cs.HourlySales).ToListAsync();
        var cookieStandDtos = _mapper.Map<List<CookieStandDto>>(cookieStands);
        return cookieStandDtos;
    }

    public async Task<CookieStandDto> GetCookieStandById(int id)
    {
        var cookieStand = await _context.CookieStands.Include(cs => cs.HourlySales).FirstOrDefaultAsync(cs => cs.Id == id);
        var cookieStandDto = _mapper.Map<CookieStandDto>(cookieStand);
        return cookieStandDto;
    }




    public async Task<CookieStandDto> Update(int id, CookieStandDto cookieStandDto)
    {
        var existingCookieStand = await _context.CookieStands.FindAsync(id);

        // Update properties
        existingCookieStand.Location = cookieStandDto.Location;
        existingCookieStand.Description = cookieStandDto.Description;
        existingCookieStand.Minimum_Customers_Per_Hour = cookieStandDto.Minimum_Customers_Per_Hour;
        existingCookieStand.Maximum_Customers_Per_Hour = cookieStandDto.Maximum_Customers_Per_Hour;
        existingCookieStand.Average_Cookies_Per_Sale = cookieStandDto.Average_Cookies_Per_Sale;
        existingCookieStand.Owner = cookieStandDto.Owner;

        // Save changes to database
        _context.CookieStands.Update(existingCookieStand);
        await _context.SaveChangesAsync();

        return _mapper.Map<CookieStandDto>(existingCookieStand);
    }

    public async Task<List<HourlySaleDto>> GenerateHourlySales(int CookieStandId, int Minimum_Customers_Per_Hour, int Maximum_Customers_Per_Hour, double Average_Cookies_Per_Sale)
    {
        var random = new Random();
        var hourlySalesList = new List<HourlySaleDto>();

        for (int hour = 1; hour <= 14; hour++)
        {
            var customersThisHour = random.Next(Minimum_Customers_Per_Hour, Maximum_Customers_Per_Hour + 1);
            var cookiesSoldThisHour = (int)(customersThisHour * Average_Cookies_Per_Sale);

            var hourlySale = new HourlySale
            {
                CookieStandId = CookieStandId,
                HourSale = cookiesSoldThisHour
            };

            _context.HourlySales.Add(hourlySale);

            var hourlySaleDto = _mapper.Map<HourlySaleDto>(hourlySale);
            hourlySalesList.Add(hourlySaleDto);
        }

        await _context.SaveChangesAsync();

        return hourlySalesList;
    }


}

