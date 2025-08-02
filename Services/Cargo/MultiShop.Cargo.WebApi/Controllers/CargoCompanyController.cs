using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult GetAllCargoCompany()
        {
            var values = _cargoCompanyService.TGetAll();

            values.Select(x => new GetCargoCompanyByIdDto
            {
                CargoCompanyId = x.CargoCompanyId,
                CargoCompanyName = x.CargoCompanyName
            }).ToList();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _cargoCompanyService.TGetById(id);

            GetCargoCompanyByIdDto _dto = new GetCargoCompanyByIdDto()
            {
                CargoCompanyId = value.CargoCompanyId,
                CargoCompanyName = value.CargoCompanyName
            };

            return Ok(_dto);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            _cargoCompanyService.TInsert(new CargoCompany
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName
            });

            return Ok("Değerler Başarıyla Eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            _cargoCompanyService.TUpdate(new CargoCompany
            {
                CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
            });

            return Ok("Değerler Başarıyla Güncellendi.");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);

            return Ok("Değerler Başarıyla Silindi.");
        }
    }
}
