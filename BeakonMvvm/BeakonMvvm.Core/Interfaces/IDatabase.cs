﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite.Net;

namespace BeakonMvvm.Core.Interfaces
{
    public interface IDatabase
    {
            SQLiteConnection GetConnection();
    }
}
