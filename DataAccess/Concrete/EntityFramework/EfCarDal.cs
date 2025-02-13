﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DbCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var result =
                    from c in dbCarContext.Cars
                    join co in dbCarContext.Colors
                        on c.ColorId equals co.ColorId
                    join b in dbCarContext.Brands
                        on c.BrandId equals b.BrandId
                    join img in dbCarContext.CarImages
                        on c.CarId equals img.CarId
                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        CarName = c.CarName,
                        ColorName = co.ColorName,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        ModelYear = c.ModelYear,
                        Description = c.Description,
                        MainImage = img
                    };
                return result.ToList();
            }
        }
        public CarDetailDto GetCarDetailById(int id)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var result =
                    from c in dbCarContext.Cars
                    join co in dbCarContext.Colors
                        on c.ColorId equals co.ColorId
                    join b in dbCarContext.Brands
                        on c.BrandId equals b.BrandId
                    join img in dbCarContext.CarImages
                        on c.CarId equals img.CarId
                    where c.CarId == id

                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        CarName = c.CarName,
                        ColorName = co.ColorName,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        ModelYear = c.ModelYear,
                        Description = c.Description,
                        Images = dbCarContext.CarImages.Where(i => i.CarId == id).ToList(),
                        MainImage = img
                    };
                return result.FirstOrDefault();

            }
        }

        public List<CarDetailDto> GetAllByColorId(int colorId)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var result =
                    from c in dbCarContext.Cars
                    join co in dbCarContext.Colors
                        on c.ColorId equals co.ColorId
                    join b in dbCarContext.Brands
                        on c.BrandId equals b.BrandId
                    join img in dbCarContext.CarImages
                        on c.CarId equals img.CarId
                    where c.ColorId == colorId
                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        CarName = c.CarName,
                        ColorName = co.ColorName,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        ModelYear = c.ModelYear,
                        Description = c.Description,
                        MainImage = img
                    };
                return result.ToList();
            }
                
        }

        public List<CarDetailDto> GetAllByBrandId(int brandId)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var result =
                    from c in dbCarContext.Cars
                    join co in dbCarContext.Colors
                        on c.ColorId equals co.ColorId
                    join b in dbCarContext.Brands
                        on c.BrandId equals b.BrandId
                    join img in dbCarContext.CarImages
                        on c.CarId equals img.CarId
                    where c.BrandId == brandId
                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        CarName = c.CarName,
                        ColorName = co.ColorName,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        ModelYear = c.ModelYear,
                        Description = c.Description,
                        MainImage = img
                    };
                return result.ToList();
            }

        }
    }
}
