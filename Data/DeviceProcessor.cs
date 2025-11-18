using Infision.Data.Models;
using Infision.MHCP.Entities.Response;
using System.Linq;

namespace Infision.Data
{
    public class DeviceProcessor
    {
        DBContext dbContext = new DBContext();
        public void ShundownDevice(RegisteredDevices device)
        {
            var devices = dbContext.Devices.Where(p => p.SerialNumber == device.SerialNumber).First();
            devices.Status = false;
            dbContext.SaveChanges();
        }
        public void SetSerialNumber(RegisteredDevices device)
        {
            var devices = dbContext.Devices.Where(p => p.Address == device.Address).First();
            devices.SerialNumber = device.SerialNumber;
            dbContext.SaveChanges();
        }
        public void OnlineDevice(RegisteredDevices device)
        {
            var devices = dbContext.Devices.Where(p => p.SerialNumber == device.SerialNumber).First();
            devices.Status = true;
            dbContext.SaveChanges();
        }

        public void Identity(RegisteredDevices device, DeviceInfoResponse deviceInfo)
        {
            if (dbContext.Devices.Where(p => p.Address != device.Address & p.SerialNumber==deviceInfo.DeviceId.SerialNumber).Count() > 0)
            {

                var dd = dbContext.Devices.Where(p => p.Address != device.Address & p.SerialNumber == deviceInfo.DeviceId.SerialNumber).FirstOrDefault();

                dbContext.Devices.Remove(dd);
                dbContext.SaveChanges();

            }
           if (dbContext.Devices.Where(p => p.Address == device.Address & p.SerialNumber != deviceInfo.DeviceId.SerialNumber).Count() > 0)
            {
                var dd = dbContext.Devices.Where(p => p.Address == device.Address & p.SerialNumber != deviceInfo.DeviceId.SerialNumber).FirstOrDefault();

                dbContext.Devices.Remove(dd);
                dbContext.SaveChanges();
            }
            if (dbContext.Devices.Where(p =>  p.SerialNumber == deviceInfo.DeviceId.SerialNumber).Count() == 0)
            {
                var ad = new Data.Models.Device()
                {
                    Address = device.Address,
                    Model = deviceInfo.DeviceId.ModelNumber,
                    DeviceType = deviceInfo.DeviceId.DeviceType.ToString(),
                    SerialNumber = deviceInfo.DeviceId.SerialNumber
,
                    BootVersion = deviceInfo.BootLoaderVersion,
                    ProtocolVersion = deviceInfo.ProtocolVersion,
                    Protocol = device.Protocol,
                    Status = true
                };


                dbContext.Devices.Add(ad);
                dbContext.SaveChanges();
            }
      
        }
    }
}
