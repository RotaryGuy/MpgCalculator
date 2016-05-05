using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MpgCalculator.Tables;
using SQLite;

namespace MpgCalculator
{
    [Activity(Label = "MPG Tracker", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        Button addCarButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // create DB path
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_sqlnet.db");

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
            FindViews();
            HandleEvents();

            createDatabase(pathToDatabase);
        }

        private void createDatabase(string path)
        {
            try
            {
                var connection = new SQLiteConnection(path);
                connection.CreateTable<Car>();
            }
            catch (SQLiteException ex)
            {
                
            }
        }

        private void FindViews()
        {
            addCarButton = FindViewById<Button>(Resource.Id.addCarButton);
        }

        private void HandleEvents()
        {
            addCarButton.Click += AddCarButton_Click;
        }

        private void AddCarButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddCarActivity));
            StartActivity(intent);
        }
    }
}

