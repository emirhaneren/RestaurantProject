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
            _sliderDal.Add(entity);
        }

        public void TDelete(Slider entity)
        {
           _sliderDal.Delete(entity);
        }

        public Slider TGetByID(int id)
        {
            return _sliderDal.GetByID(id);
        }

        public List<Slider> TGetListAll()
        {
            return _sliderDal.GetListAll();
        }

        public void TUpdate(Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}
