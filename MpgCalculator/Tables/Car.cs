using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace MpgCalculator.Tables
{
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int carId { get; set; }
        public string carMake { get; set; }
        public string carModel { get; set; }
        public int carYear { get; set; }
        public int carMileage { get; set; }

        
    }
}