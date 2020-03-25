using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DjongaTracker
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
