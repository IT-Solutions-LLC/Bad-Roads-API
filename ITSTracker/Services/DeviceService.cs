using ITSTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSTracker.Services
{
    public class DeviceService : IDeviceService
    {
        private traccarContext TraccarContext = null;
        public int MyProperty { get; set; }
        public DeviceService()
        {
            this.TraccarContext = new traccarContext();
        }
        public TcDevices GetDevice(string uniqueid)
        {
            var device = this.TraccarContext.TcDevices.FirstOrDefault((obj) => obj.Uniqueid == uniqueid);
            if (device == null) return null;
            return device;
        }

        public List<TcDevices> GetDevices()
        {
            return this.TraccarContext.TcDevices.ToList();
        }

        public TcDevices UpdateDevice(TcDevices device)
        {
            var upDevice = this.TraccarContext.TcDevices.FirstOrDefault((obj) => obj.Uniqueid == device.Uniqueid);
            if (upDevice == null) return null;
            var deviceProp = device.GetType().GetProperties();
            foreach (var prop in deviceProp)
            {
                if (prop != null && prop.CanRead)
                {
                    upDevice.GetType()
                        .GetProperty(prop.Name)
                        .SetValue(upDevice, prop.GetValue(device));
                }
            }

            this.TraccarContext.TcDevices.Update(upDevice);
            this.TraccarContext.SaveChanges();
            return upDevice;
        }
    }
}
