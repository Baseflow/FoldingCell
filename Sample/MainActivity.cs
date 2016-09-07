using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Ramotion.Foldingcell;

namespace Sample
{
    [Activity(Label = "Sample", MainLauncher = true, Icon = "@mipmap/icon", Theme="@style/AppTheme")]
    public class MainActivity : AppCompatActivity, AdapterView.IOnItemClickListener, View.IOnClickListener
    {
        private FoldingCellListAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // get our list view
            var theListView = FindViewById<ListView>(Resource.Id.mainListView);

            // prepare elements to display
            var items = Item.getTestingList();

            // add custom btn handler to first list item
            items.ElementAt(0).setRequestBtnClickListener(this);

            // create custom adapter that holds elements and their state (we need hold a id's of unfolded elements for reusable elements)
            adapter = new FoldingCellListAdapter(this, items);

            // add default btn handler for each request btn on each item if custom handler not found
            adapter.setDefaultRequestBtnClickListener(this);

            // set elements to adapter
            theListView.Adapter = adapter;

            // set on click event listener to list view
            theListView.OnItemClickListener = this;
        }

        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            // toggle clicked cell state
            ((FoldingCell)view).Toggle(false);
            // register in adapter that state for selected cell is toggled
            adapter.registerToggle(position);
        }

        public void OnClick(View v)
        {
            Toast.MakeText(ApplicationContext, "DEFAULT HANDLER FOR ALL BUTTONS", ToastLength.Short).Show();
        }
    }
}


