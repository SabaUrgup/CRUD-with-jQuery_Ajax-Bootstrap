using Device.Business.Abstract;
using Device.DataAccessLayer.Context;
using Device.DataAccessLayer.DataTransferObject.TvDTO;
using Device.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device.Business.Concrete
{
    public class TvService : ITvService
    {
        public DeviceDatabaseContext _deviceDatabaseContext;

        public TvService (DeviceDatabaseContext deviceDatabaseContext)
        {
            _deviceDatabaseContext = deviceDatabaseContext;
        }

        public int AddTv(TvAddDTO tv)
        {
            var newTv = new Tv
            {
                Brand = tv.Brand,
                Size = tv.Size,
                WarrantyStarting = tv.WarrantyStarting
            };
            _deviceDatabaseContext.Tvs.Add(newTv);
            return _deviceDatabaseContext.SaveChanges();
        }

        public int DeleteTv(int Id)
        {
            var currentTv = _deviceDatabaseContext.Tvs
                .Where(p => !p.IsDeleted && p.Id == Id).FirstOrDefault();
            if(currentTv == null)
            {
                return 0;
            }
            currentTv.IsDeleted = true;
            _deviceDatabaseContext.Tvs.Update(currentTv);
            return _deviceDatabaseContext.SaveChanges();
        }

        public TvGetDTO GetTvById(int Id)
        {
            return _deviceDatabaseContext.Tvs
                .Where(p => !p.IsDeleted && p.Id == Id)
                .Select(p => new TvGetDTO
                {
                    Brand = p.Brand,
                    Size = p.Size,
                    WarrantyStarting = p.WarrantyStarting,
                }).FirstOrDefault();
        }

        public List<TvListDTO> ListTv()
        {
            return _deviceDatabaseContext.Tvs.Where(p => !p.IsDeleted)
                .Select(p => new TvListDTO
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Size = p.Size,
                    WarrantyStarting = p.WarrantyStarting

                }).ToList();
        }

        public int UpdateTv(TvUpdateDTO tv)
        {
            var currentTv = _deviceDatabaseContext.Tvs
                .Where(p => !p.IsDeleted && p.Id == tv.Id).FirstOrDefault();
            if(currentTv == null)
            {
                return 0;
            }
            currentTv.Size = tv.Size;
            currentTv.Brand = tv.Brand;
            currentTv.WarrantyStarting = tv.WarrantyStarting;

            _deviceDatabaseContext.Tvs.Update(currentTv);
            return _deviceDatabaseContext.SaveChanges();
        }
    }
}
