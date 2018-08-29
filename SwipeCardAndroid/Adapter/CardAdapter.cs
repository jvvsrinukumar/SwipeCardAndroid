using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using Android.App;
using Android.Views;
using Android.Widget;
using Com.Huxq17.Swipecardsview;
using Square.Picasso;
using SwipeCardAndroid.Models;

namespace SwipeCardAndroid.Adapter
{
    public class CardAdapter : BaseCardAdapter
    {
        List<string> imgurls;
        private Activity context;

        public CardAdapter(Activity context ,List<string> imgurls)
        {
            this.context = context;
            this.imgurls = imgurls;
        }

        public override int CardLayoutId 
        {
            get {
                return Resource.Layout.Card_item;
            }
        }

        public override int Count {
            get
            {
                return imgurls.Count;
            }
        }

        public override void OnBindData(int p0, View p1)
        {
            if (imgurls == null || imgurls.Count == 0)
                return;
            //p1 = this.context.LayoutInflater.Inflate(Resource.Layout.achievement_range_row, parent, false);
            ImageView imgView = p1.FindViewById<ImageView>(Resource.Id.imgView);
            TextView txtView = p1.FindViewById<TextView>(Resource.Id.txtTitle);
            String model = imgurls[p0];
           // txtView.Text = model.Title;
           // Picasso.With(context)
            Picasso.With(context).Load(model).Into(imgView);


            
        }

       
    }
}
