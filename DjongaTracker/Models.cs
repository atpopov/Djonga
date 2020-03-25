using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DjongaTracker
{
    public class Models
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        public double Count { get; set; }

        public double PrCount { get; set; }
    }
}
