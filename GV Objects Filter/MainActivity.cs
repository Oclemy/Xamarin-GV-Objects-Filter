using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;

namespace GV_Objects_Filter
{
    [Activity(Label = "GridView Filter Objects", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //DECLARATIONS
        private GridView gv;
        private SearchView sv;
        private ArrayAdapter<Spacecraft> adapter;
        private readonly IList<Spacecraft> spacecrafts=new List<Spacecraft>();
         

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

           //REFERENCES
            gv = FindViewById<GridView>(Resource.Id.gv);
            sv = FindViewById<SearchView>(Resource.Id.sv);

            //POPULATE DATA
            FillData();

            //ADAPTER
            adapter=new ArrayAdapter<Spacecraft>(this,Android.Resource.Layout.SimpleListItem1,spacecrafts);
            gv.Adapter = adapter;

            //SEARCH
            sv.QueryTextChange += Sv_QueryTextChange;

            //ITEM CLICK
            gv.ItemClick += Gv_ItemClick;
        }

        private void Gv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this,adapter.GetItem(e.Position).Name,ToastLength.Short).Show();
        }

        private void Sv_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
           adapter.Filter.InvokeFilter(e.NewText);
        }

        private void FillData()
        {
            Spacecraft s = new Spacecraft("Voyager", "Nuclear", "Asteroid Belt");
            spacecrafts.Add(s);

            s = new Spacecraft("Casini", "Anti-Matter", "Canis Majos");
            spacecrafts.Add(s);

            s = new Spacecraft("Enterprise", "Warp Drive", "Andromeda");
            spacecrafts.Add(s);

            s = new Spacecraft("Pioneer", "Solar", "Venus");
            spacecrafts.Add(s);

            s = new Spacecraft("Rosetter", "Warp Drive", "Pluto");
            spacecrafts.Add(s);

            s = new Spacecraft("Spitzer", "Plasma Ions", "Andromeda");
            spacecrafts.Add(s);

            s = new Spacecraft("Discovery", "Plasma Ions", "Andromeda");
            spacecrafts.Add(s);

            s = new Spacecraft("Atlantis", "Plasma Ions", "Andromeda");
            spacecrafts.Add(s);

            s = new Spacecraft("Columbia", "Chemical", "Space");
            spacecrafts.Add(s);

            s = new Spacecraft("Apollo", "Chemical", "Space");
            spacecrafts.Add(s);

            s = new Spacecraft("Challenger", "Warp Drive", "Sombrero");
            spacecrafts.Add(s);

            s = new Spacecraft("Curiosity", "Solar", "Mars");
            spacecrafts.Add(s);

            s = new Spacecraft("Opportunity", "Solar", "Mars");
            spacecrafts.Add(s);

            s = new Spacecraft("Kepler", "Solar", "Jupiter");
            spacecrafts.Add(s);
        }

    }
}

