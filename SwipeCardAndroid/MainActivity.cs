using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Com.Huxq17.Swipecardsview;
using System.Collections.Generic;
using SwipeCardAndroid.Models;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using SwipeCardAndroid.Adapter;

namespace SwipeCardAndroid
{
    [Activity(Label = "SwipeCardAndroid", MainLauncher = true, Icon = "@mipmap/icon",Theme = "@style/Theme.AppCompat")]
    public class MainActivity : AppCompatActivity
    {
        private SwipeCardsView swipecardView;
        private List<Data> mainresult = new List<Data>();
        private Picture picture;
        private List<string> imgurls = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            swipecardView = FindViewById<SwipeCardsView>(Resource.Id.swipecard);
            swipecardView.RetainLastCard(false);
            swipecardView.EnableSwipe(true);
            GetData();
        }

        public async void GetData()
        {
            //create url and data       
            try
            {
                string requestUrlString = "https://randomuser.me/api/";
                var obj = new RestServiceCls();
                using (var client = obj.ConfigurateHttpClient())
                {
                    var content = new StringContent("");
                    var response = await client.GetAsync(new Uri(requestUrlString));
                    string jsonString = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RootObject>(jsonString);
                    if (result != null)
                    {
                        mainresult = result.results;

                        foreach (var item in mainresult)
                        {
                            if (item.picture.large != null)
                            imgurls.Add(item.picture.large);
                            if (item.picture.medium != null)
                            imgurls.Add(item.picture.medium);
                            if (item.picture.thumbnail != null)
                            imgurls.Add(item.picture.thumbnail);
                        }
                       
                    }
                }

                CardAdapter cardAdapter = new CardAdapter(this, imgurls);
                swipecardView.SetAdapter(cardAdapter);
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}

