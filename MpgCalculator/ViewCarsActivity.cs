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
using MpgCalculator.CarAdapter;
using MpgCalculator.Tables;
using SQLite;

namespace MpgCalculator
{
    [Activity(Label = "ViewCarsActivity")]
    public class ViewCarsActivity : Activity
    {
        ListView carListView;
        string pathToDatabase;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ViewCarsView);

            FindViews();
            PopulateCarList();
        }

        private void FindViews()
        {
            carListView = FindViewById<ListView>(Resource.Id.carListView);
        }

        private void PopulateCarList()
        {
            pathToDatabase = Intent.Extras.GetString("path");
            try
            {
                var db = new SQLiteConnection(pathToDatabase);
                List<string> carList = new List<string>();
                List<Car> cars = db.Query<Car>("SELECT * FROM CAR");

                foreach (Car c in cars)
                {
                    carList.Add(string.Format("{0} {1} {2}", c.carYear, c.carMake, c.carModel));
                }
                ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, carList);


                carListView.Adapter = adapter;
                
                
            }
            catch (SQLiteException ex)
            {
                //alert.SetMessage("Failed to insert!");
            }
           
        }
    }
}