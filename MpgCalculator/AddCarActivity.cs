using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Test.Suitebuilder;
using Android.Views;
using Android.Widget;
using Java.Security;
using MpgCalculator.Tables;
using SQLite;

namespace MpgCalculator
{
    [Activity(Label = "Add A Car to Track")]
    public class AddCarActivity : Activity
    {
        EditText carYearText;
        EditText carMakeText;
        EditText carModelText;
        EditText carMileageText;
        Button addCarButton;

        string pathToDatabase;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddCarView);
            // Create your application here

            FindViews();
            HandleEvents();
            //PopulateCarYear();
        }

        private void FindViews()
        {
            pathToDatabase = Intent.Extras.GetString("path");
            carYearText = FindViewById<EditText>(Resource.Id.carYearText);
            carMakeText = FindViewById<EditText>(Resource.Id.carMakeText);
            carModelText = FindViewById<EditText>(Resource.Id.carModelText);
            carMileageText = FindViewById<EditText>(Resource.Id.carMileageText);
            addCarButton = FindViewById<Button>(Resource.Id.addCarButton);
            
            //carYearSpinner = FindViewById<Spinner>(Resource.Id.carYearSpinner);
        }

        private void HandleEvents()
        {
            addCarButton.Click += AddCarButton_Click;
        }

        private void AddCarButton_Click(object sender, EventArgs e)
        {
            Car carToInsert = new Car();
            carToInsert.carMake = carMakeText.Text;
            carToInsert.carModel = carModelText.Text;
            carToInsert.carMileage = Convert.ToInt32(carMileageText.Text);
            carToInsert.carYear = Convert.ToInt32(carYearText.Text);
            AlertDialog.Builder alert = new AlertDialog.Builder(this);

            try
            {
                var db = new SQLiteConnection(pathToDatabase);
                if (db.Insert(carToInsert) != 0)
                    db.Update(carToInsert);
                alert.SetMessage(string.Format("{0} {1} {2} added", carToInsert.carYear, carToInsert.carMake,
                    carToInsert.carModel));
            }
            catch (SQLiteException ex)
            {
                alert.SetMessage("Failed to insert!");
            }
            finally
            {
                alert.Show();
            }
            
            
          
        }

        private void PopulateCarYear()
        {
            var carYears = new ArrayAdapter(this, 0);
            for (int x = 1960; x <= 2016; x++)
            {
                carYears.Add(x);
            }

            //carYearSpinner.Adapter = carYears;
        }
    }
}