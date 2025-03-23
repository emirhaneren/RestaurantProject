using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.BookingValidations;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DtoLayer.AboutDto;
using DtoLayer.CategoryDto;
using DtoLayer.ContactDto;
using DtoLayer.DiscountDto;
using DtoLayer.MenuTableDto;
using DtoLayer.MessageDto;
using DtoLayer.ProductDto;
using DtoLayer.SliderDto;
using DtoLayer.SocialMediaDto;
using DtoLayer.TestimonialDto;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();

            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<IBookingDal, EfBookingDal>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();

            services.AddScoped<IDiscountService, DiscountManager>();
            services.AddScoped<IDiscountDal, EfDiscountDal>();

            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IFeatureDal, EfFeatureDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();

            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();

            services.AddScoped<IOrderDetailService, OrderDetailManager>();
            services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();

            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDal, EfOrderDal>();

            services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
            services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();

            services.AddScoped<IMenuTableService, MenuTableManager>();
            services.AddScoped<IMenuTableDal, EfMenuTableDal>();

            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ISliderDal, EfSliderDal>();

            services.AddScoped<IBasketService, BasketManager>();
            services.AddScoped<IBasketDal, EfBasketDal>();

            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<INotificationDal, EfNotificationDal>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EfMessageDal>();
        }
        public static void ContainerValidations(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateBookingValidation>();

            services.AddValidatorsFromAssemblyContaining<CreateMessageDto>();

            services.AddValidatorsFromAssemblyContaining<UpdateAboutDto>();

            services.AddValidatorsFromAssemblyContaining<CreateCategoryDto>();
            services.AddValidatorsFromAssemblyContaining<UpdateCategoryDto>();

            services.AddValidatorsFromAssemblyContaining<CreateProductDto>();
            services.AddValidatorsFromAssemblyContaining<UpdateProductDto>();

            services.AddValidatorsFromAssemblyContaining<CreateDiscountDto>();
            services.AddValidatorsFromAssemblyContaining<UpdateDiscountDto>();

            services.AddValidatorsFromAssemblyContaining<UpdateContactDto>();

            services.AddValidatorsFromAssemblyContaining<CreateSliderDto>();
            services.AddValidatorsFromAssemblyContaining<UpdateSliderDto>();

            services.AddValidatorsFromAssemblyContaining<UpdateTestimonialDto>();
            services.AddValidatorsFromAssemblyContaining<CreateTestimonialDto>();

            services.AddValidatorsFromAssemblyContaining<UpdateSocialMediaDto>();
            services.AddValidatorsFromAssemblyContaining<CreateSocialMediaDto>();

            services.AddValidatorsFromAssemblyContaining<CreateMenuTableDto>();
            services.AddValidatorsFromAssemblyContaining<UpdateMenuTableDto>();
        }
    }
}
