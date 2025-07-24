using MultsiShop.Discount.Dtos.DiscountDtos;

namespace MultsiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllCouponsAsync();
        Task CreateCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);
        Task UpdateCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);
        Task RemoveCouponAsync(int id);
        Task<GetByIdDiscountCouponDto> GetByIdCouponAsync(int id);
    }
}
