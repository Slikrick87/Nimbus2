﻿using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Services
{
    public interface IGeoLocationService
    {
        Task<Location> GetLocationAsync();
    }
}
