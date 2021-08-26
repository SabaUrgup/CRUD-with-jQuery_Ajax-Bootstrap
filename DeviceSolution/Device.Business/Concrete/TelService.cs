using Device.Business.Abstract;
using Device.DataAccessLayer.Context;
using Device.DataAccessLayer.DataTransferObject.TelDTO;
using Device.DataAccessLayer.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Device.Business.Concrete
{
    public class TelService : ITelService
    {
        public DeviceDatabaseContext _deviceDatabaseContext;

        public TelService(DeviceDatabaseContext deviceDatabaseContext)
        {
            _deviceDatabaseContext = deviceDatabaseContext;
        }

        public int AddTel(TelAddDTO tel)
        {
            var newTel = new Tel
            {
                Brand = tel.Brand,
                Color = tel.Color,
                WarrantyStarting = tel.WarrantyStarting

            };
            _deviceDatabaseContext.Tels.Add(newTel);
            return _deviceDatabaseContext.SaveChanges();
        }

        public int DeleteTel(int Id)
        {
            var currentTel = _deviceDatabaseContext.Tels
                .Where(p => !p.IsDeleted && p.Id == Id).FirstOrDefault();
            if (currentTel == null)
            {
                return 0;
            }
            currentTel.IsDeleted = true;
            _deviceDatabaseContext.Tels.Update(currentTel);
            return _deviceDatabaseContext.SaveChanges();
        }

        public TelGetDTO GetTelById(int Id)
        {
            return _deviceDatabaseContext.Tels
                .Where(p => !p.IsDeleted && p.Id == Id)
                .Select(p => new TelGetDTO
                {
                    Brand = p.Brand,
                    Color = p.Color,
                    WarrantyStarting = p.WarrantyStarting,
                }).FirstOrDefault();
        }

        public List<TelListDTO> ListTel()
        {
            return _deviceDatabaseContext.Tels.Where(p => !p.IsDeleted)
                .Select(p => new TelListDTO
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Color = p.Color,
                    WarrantyStarting = p.WarrantyStarting

                }).ToList();
        }

        public int UpdateTel(TelUpdateDTO tel)
        {
            var currentTel = _deviceDatabaseContext.Tels
                .Where(p => !p.IsDeleted && p.Id == tel.Id).FirstOrDefault();
            if (currentTel == null)
            {
                return 0;
            }
            currentTel.Brand = tel.Brand;
            currentTel.Color = tel.Color;
            currentTel.WarrantyStarting = tel.WarrantyStarting;

            _deviceDatabaseContext.Tels.Update(currentTel);
            return _deviceDatabaseContext.SaveChanges();
        }
    }
}
