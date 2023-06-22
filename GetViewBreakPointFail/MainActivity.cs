using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;

using static Android.Widget.AdapterView;


namespace GetViewBreakPointFail
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
		private readonly List<ListItemBase> _menuItems = new();
		internal ArrayAdapter<ListItemBase> ListAdapter;
		private ListView _listView;

		protected override void OnCreate(Bundle savedInstanceState)
        {
			base.OnCreate(savedInstanceState);

			AppDomain.CurrentDomain.UnhandledException += (_, args) => System.Diagnostics.Debug.WriteLine(args.ToString());

			SetContentView(Resource.Layout.ListLayout);

			lock (_menuItems)
			{
				ListAdapter = new ArrayAdapters.SimpleListItem2<ListItemBase>(this, Android.Resource.Layout.SimpleListItem2, Android.Resource.Id.Text1, _menuItems);
				_listView = FindViewById<ListView>(Resource.Id.list);
				_listView.Adapter = ListAdapter;

				_menuItems.Add(new ConcreteListItem(this));
				RunOnUiThread(() =>
				{
					ListAdapter.AddAll(_menuItems);
					ListAdapter?.NotifyDataSetChanged();
				});
			}

			_listView.ItemClick += OnListItemClick;
		}

		private static void OnListItemClick(object _, ItemClickEventArgs args) => ((ArrayAdapter<ListItemBase>)((ListView)args.Parent)?.Adapter)?.GetItem(args.Position)?.OnItemClick(_, args);
	}

	internal class ConcreteListItem : ListItemBase
	{
		private readonly MainActivity _activity;

		protected internal ConcreteListItem(MainActivity activity) : base("Default") => _activity = activity;

		public override string PrimaryText => "Primary";

		public override string SecondaryText => "Secondary";

		#region Overrides of ListItemBase

		public override void OnItemClick(object sender, ItemClickEventArgs args) => _activity.ListAdapter?.NotifyDataSetChanged();

		#endregion
	}
}