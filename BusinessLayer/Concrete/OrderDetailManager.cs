﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public void TAdd(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public OrderDetail TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
