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
using MpgCalculator.Tables;

namespace MpgCalculator.CarAdapter
{
    public class CarListAdapter : BaseAdapter<Car>
    {
        List<Car> cars;
        Activity context;

        public CarListAdapter(Activity context, List<Car> cars) : base()
        {
            this.context = context;
            this.cars = cars;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Car this[int position]
        {
            get { return cars[position]; }
        }

        public override int Count
        {
            get
            {
                return cars.Count;
            }

        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var car = cars[position];
            
            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.ViewCarsView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.carYearText).Text = car.carYear.ToString();
            convertView.FindViewById<TextView>(Resource.Id.carMakeText).Text = car.carMake;
            convertView.FindViewById<TextView>(Resource.Id.carModelText).Text = car.carModel;
            
            return convertView;
        }
    }
}