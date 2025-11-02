using Microsoft.AspNetCore.Mvc;
using StokTakip.Core.DTOs;
using StokTakip.Core.IServices;
using System.Threading.Tasks;

namespace StokTakip.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SatisController : ControllerBase
    {
        private readonly ISatisService _satisService;

        public SatisController(ISatisService satisService)
        {
            _satisService = satisService;
        }

        [HttpGet]
        public async Task<IActionResult> TumSatislarGetir()
        {
            var satislar = await _satisService.GetAllAsync();
            return Ok(satislar);
        }

        [HttpGet("{id}/detay")]
        public async Task<IActionResult> SatisDetayGetir(int id)
        {
            var satisDetay = await _satisService.GetDetayByIdAsync(id);
            if (satisDetay == null)
            {
                return NotFound();
            }
            return Ok(satisDetay);
        }

        [HttpPost]
        public async Task<IActionResult> SatisEkle([FromBody] SatisEkleDto satisEkleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yeniSatis = await _satisService.AddAsync(satisEkleDto);

            return CreatedAtAction(nameof(SatisDetayGetir), new { id = yeniSatis.SatisID }, yeniSatis);
        }
    }
}