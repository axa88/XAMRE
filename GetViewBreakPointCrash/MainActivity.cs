using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;

using MotoConfig.App.Ui.Legacy.MenuScaffold;


namespace GetViewBreakPointCrash
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
		private readonly List<ListItemBase> _menuItems = new();
		private ArrayAdapter<ListItemBase> _listAdapter;
		private ListView _listView;

		protected override void OnCreate(Bundle savedInstanceState)
        {
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.ListLayout);

			lock (_menuItems)
			{
				_listAdapter = new ArrayAdapters.SimpleListItem2<ListItemBase>(this, Android.Resource.Layout.SimpleListItem2, Android.Resource.Id.Text1, _menuItems);
				_listView = FindViewById<ListView>(Resource.Id.list);
				_listView.Adapter = _listAdapter;

				_menuItems.Add(new ConcreteListItem(this, null));
				RunOnUiThread(() =>
				{
					_listAdapter.AddAll(_menuItems);
					_listAdapter?.NotifyDataSetChanged();
				});
			}
		}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

	internal class ConcreteListItem : ListItemBase
	{
		protected internal ConcreteListItem(Activity activity, object itemData) : base(itemData, "Default")
		{
		}

		public override string PrimaryText
		{
			get
			{
				return "Primary";
			}
		}

		public override string SecondaryText
		{
			get
			{
				return "Secondary";
			}
		}
	}
}