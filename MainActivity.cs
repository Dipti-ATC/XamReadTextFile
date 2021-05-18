using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace XamReadTextFile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btnDisplayWord;
        private TextView txtAnimal;
        private char[] wordToGuess;
        private List<string> wordList = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnDisplayWord = FindViewById<Button>(Resource.Id.btnDisplayWord);
            txtAnimal = FindViewById<TextView>(Resource.Id.txtAnimal);
            btnDisplayWord.Click += btnDisplayWord_Click;
        }

        private void btnDisplayWord_Click(object sender, EventArgs e)
        {
           
        // Open the textfile
        Stream myStream = Assets.Open("Words.txt");
            using (StreamReader sr = new StreamReader(myStream))
            {

                string line;
                // while the line that is being read is not equal to null (meaning there is still text to be read)
                while ((line = sr.ReadLine()) != null)
                { // Add that line to the wordlist
                    wordList.Add(line);
                }
            }
            Random randomGen = new Random();
            var rand = wordList[randomGen.Next(0,wordList.Count)];
            rand = rand.ToUpper();
            //wordToGuess = rand.ToArray();
            txtAnimal.Text = rand.ToString();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}