using ITSTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSTracker.Services
{
    public interface IDeviceService
    {
        TcDevices GetDevice(string uniqueid);
        List<TcDevices> GetDevices();
        TcDevices UpdateDevice(TcDevices device);
    }
}
