using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultsiShop.Discount.Dtos.DiscountDtos;
using MultsiShop.Discount.Services;

namespace MultsiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _discountService.GetAllCouponsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var values = await _discountService.GetByIdCouponAsync(id);
            return Ok(values);
        }

        //[HttpGet("GetCodeDetailByCodeAsync")]
        //public async Task<IActionResult> GetCodeDetailByCodeAsync(string code)
        //{
        //    var values = await _discountService.GetCodeDetailByCodeAsync(code);
        //    return Ok(values);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Kupon başarıyla oluşturuldu");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.RemoveCouponAsync(id);
            return Ok("Kupon başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("İndirim kuponu başarıyla güncellendi");
        }

        //[HttpGet("GetDiscountCouponCountRate")]
        //public IActionResult GetDiscountCouponCountRate(string code)
        //{
        //    var values = _discountService.GetDiscountCouponCountRate(code);
        //    return Ok(values);
        //}

        //[HttpGet("GetDiscountCouponCount")]
        //public async Task<IActionResult> GetDiscountCouponCount()
        //{
        //    var values = await _discountService.GetDiscountCouponCount();
        //    return Ok(values);
        //}
    }
}
