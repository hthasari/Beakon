﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
namespace BeakonMvvm.Core.Interfaces
{
    public interface IAzureDatabase
    {
        MobileServiceClient GetMobileServiceClient();
    }
}
