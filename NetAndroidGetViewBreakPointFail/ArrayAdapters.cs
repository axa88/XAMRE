using Android.Content;
using Android.Views;


namespace NetAndroidGetViewBreakPointFail
{
	// ReSharper disable once ClassNeverInstantiated.Global
	internal class ArrayAdapters
	{
		internal class SimpleListItem2<T> : ArrayAdapter<T> where T : IListItem
		{
			public SimpleListItem2(Context context, int resource, int textViewResourceId, IList<T> objects) : base(context, resource, textViewResourceId, objects) {}

			public override View GetView(int position, View convertView, ViewGroup parent)
			{
				var view = base.GetView(position, convertView, parent);
				var item = GetItem(position);
				if (item != null)
				{
					var textView1 = (TextView)view.FindViewById(Android.Resource.Id.Text1);
					var textView2 = (TextView)view.FindViewById(Android.Resource.Id.Text2);
					textView1.Text = item.PrimaryText ?? "";
					textView2.Text = item.SecondaryText ?? "";
				}

				return view;
			}
		}
	}
}