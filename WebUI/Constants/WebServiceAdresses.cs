﻿using static System.Net.WebRequestMethods;

namespace WebUI.Constants
{
    public class WebServiceAdresses
    {
        public const string categoryApi = "https://localhost:7034/api/Category";
        public static readonly string categoryIdApi = "https://localhost:7034/api/Category/{id}";
        public static readonly string categoryGetByIdApi = "https://localhost:7034/api/Category/GetCategoryById/{id}";

        public const string productApi = "https://localhost:7034/api/Product";
        public static readonly string productIdApi = "https://localhost:7034/api/Product/{id}";
        public static readonly string productGetByIdApi = "https://localhost:7034/api/Product/GetProductById/{id}";
        public static readonly string productGetWithCategoryApi = "https://localhost:7034/api/Product/ProductListWithCategory";
        public static readonly string productLas9ListApi = "https://localhost:7034/api/Product/GetLast9Products";

        public const string aboutApi = "https://localhost:7034/api/About";
        public static readonly string aboutGetByIdApi = "https://localhost:7034/api/About/GetAboutById/{id}";

        public const string bookingApi = "https://localhost:7034/api/Booking";
        public static readonly string bookingIdApi = "https://localhost:7034/api/Booking/{id}";
        public static readonly string bookingGetByIdApi = "https://localhost:7034/api/Booking/GetBookingById/{id}";
        public static readonly string bookingApproveApi = "https://localhost:7034/api/Booking/BookingStatusApprove/{id}";
        public static readonly string bookingCancelApi = "https://localhost:7034/api/Booking/BookingStatusCancel/{id}";

        public const string contactApi = "https://localhost:7034/api/Contact";
        public static readonly string contactGetByIdApi = "https://localhost:7034/api/Contact/GetContactById/{id}";

        public const string discountApi = "https://localhost:7034/api/Discount";
        public static readonly string discountIdApi = "https://localhost:7034/api/Discount/{id}";
        public static readonly string discountGetByIdApi = "https://localhost:7034/api/Discount/GetDiscountById/{id}";
        public static readonly string discountChangeStatusApi = "https://localhost:7034/api/Discount/ChangeStatus/{id}";
        public static readonly string discountListByActiveApi = "https://localhost:7034/api/Discount/GetActiveDiscounts";

        public const string socialMediaApi = "https://localhost:7034/api/SocialMedia";
        public static readonly string socialMediaIdApi = "https://localhost:7034/api/SocialMedia/{id}";
        public static readonly string socialMediaGetByIdApi = "https://localhost:7034/api/SocialMedia/GetSocialMediaById/{id}";

        public const string testimonialApi = "https://localhost:7034/api/Testimonial";
        public static readonly string testimonialIdApi = "https://localhost:7034/api/Testimonial/{id}";
        public static readonly string testimonialGetByIdApi = "https://localhost:7034/api/Testimonial/GetTestimonialById/{id}";

        public const string sliderApi = "https://localhost:7034/api/Slider";
        public static readonly string sliderIdApi = "https://localhost:7034/api/Slider/{id}";
        public static readonly string sliderGetByIdApi = "https://localhost:7034/api/Slider/GetSliderById/{id}";

        public static readonly string basketPostApi = "https://localhost:7034/api/Basket";
        public static readonly string basketApi = "https://localhost:7034/api/Basket/{id}";
        public static readonly string basketGetByProductNameApi = "https://localhost:7034/api/Basket/BasketListWithProductName/{id}";

        public static readonly string notificationApi = "https://localhost:7034/api/Notification/NotificationList";
        public static readonly string notificationCreateApi = "https://localhost:7034/api/Notification/CreateNotification";
        public static readonly string notificationDeleteApi = "https://localhost:7034/api/Notification/DeleteNotification/{id}";
        public static readonly string notificationGetApi = "https://localhost:7034/api/Notification/GetNotification/{id}";
        public static readonly string notificationUpdateApi = "https://localhost:7034/api/Notification/UpdateNotification/{id}";
        public static readonly string notificationUpdateStatusApi = "https://localhost:7034/api/Notification/UpdateNotificationStatus/{id}";

        public static readonly string menuTableApi = "https://localhost:7034/api/MenuTable";
        public static readonly string menuTableIdApi = "https://localhost:7034/api/MenuTable/{id}";
        public static readonly string menuTableIdTrueApi = "https://localhost:7034/api/MenuTable/ChangeMenuTableStatusToTrue/{id}";
        public static readonly string menuTableIdFalseApi = "https://localhost:7034/api/MenuTable/ChangeMenuTableStatusToFalse/{id}";


        public static readonly string messageApi= "https://localhost:7034/api/Message";
        public static readonly string messageIdApi= "https://localhost:7034/api/Message/Get/{id}";

    }
}

