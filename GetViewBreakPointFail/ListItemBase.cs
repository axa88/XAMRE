using static Android.Widget.AdapterView;


namespace GetViewBreakPointFail
{
	internal class ListItemBase : IListItem
	{
		protected ListItemBase(string primaryText, string secondaryText = "")
		{
			PrimaryText = primaryText;
			SecondaryText = secondaryText;
		}

		#region Implementation of IListItem

		public virtual string PrimaryText { get; }

		public virtual string SecondaryText { get; }

		public virtual void OnItemClick(object sender, ItemClickEventArgs args) { }

		#endregion

		//public override string ToString() => PrimaryText;
	}
}