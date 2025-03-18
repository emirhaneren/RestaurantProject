﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;
        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void TAdd(Discount entity)
        {
            _discountDal.Add(entity);
        }

        public void TChangeStatus(int id)
        {
            _discountDal.ChangeStatus(id);
        }

        public void TDelete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public List<Discount> TGetActiveDiscounts()
        {
            return _discountDal.GetActiveDiscounts();
        }

        public Discount TGetByID(int id)
        {
            return _discountDal.GetByID(id);
        }

        public List<Discount> TGetListAll()
        {
            return _discountDal.GetListAll();
        }

        public void TUpdate(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}
