﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal; 
        }

        public void TAdd(Slider entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Slider entity)
        {
            throw new NotImplementedException();
        }

        public Slider TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Slider> TGetListAll()
        {
            return _sliderDal.GetListAll();
        }

        public void TUpdate(Slider entity)
        {
            throw new NotImplementedException();
        }
    }
}
