using Microsoft.AspNetCore.Mvc;
using StokTakip.Core.DTOs;
using StokTakip.Core.IServices;
using System.Threading.Tasks;

namespace StokTakip.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelService _personelService;

        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        [HttpGet]
        public async Task<IActionResult> TumPersonelleriGetir()
        {
            var personeller = await _personelService.GetAllAsync();
            return Ok(personeller);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PersonelGetir(int id)
        {
            var personel = await _personelService.GetByIdAsync(id);
            if (personel == null)
            {
                return NotFound();
            }
            return Ok(personel);
        }

        [HttpGet("{id}/detay")]
        public async Task<IActionResult> PersonelDetayGetir(int id)
        {
            var personelDetay = await _personelService.GetDetayByIdAsync(id);
            if (personelDetay == null)
            {
                return NotFound();
            }
            return Ok(personelDetay);
        }

        [HttpPost]
        public async Task<IActionResult> PersonelEkle([FromBody] PersonelEkleDto personelEkleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yeniPersonel = await _personelService.AddAsync(personelEkleDto);

            return CreatedAtAction(nameof(PersonelGetir), new { id = yeniPersonel.personelID }, yeniPersonel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PersonelGuncelle(int id, [FromBody] PersonelGuncelleDto personelGuncelleDto)
        {
            if (id != personelGuncelleDto.personelID)
            {
                return BadRequest("URL'deki ID ile gövdedeki ID uyuşmuyor.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guncellenenPersonel = await _personelService.UpdateAsync(id, personelGuncelleDto);
            if (guncellenenPersonel == null)
            {
                return NotFound();
            }

            return Ok(guncellenenPersonel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> PersonelSil(int id)
        {
            var basariliMi = await _personelService.DeleteAsync(id);

            if (!basariliMi)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}