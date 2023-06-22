using static Android.Widget.AdapterView;


namespace MotoConfig.App.Ui.Legacy.MenuScaffold
{
	internal class ListItemBase : IListItem
	{
		protected internal ListItemBase(object itemData, string primaryText, string secondaryText = "", int order = int.MinValue)
		{
			ItemData = itemData;
			PrimaryText = primaryText;
			SecondaryText = secondaryText;
			Order = order;
		}

		protected enum RequestCode { Rename = 2, Scan, Application }

		public object ItemData { get; }

		#region Implementation of IListItem

		public virtual string PrimaryText { get; }

		public virtual string SecondaryText { get; }

		public virtual int Order { get; }

		public virtual void OnItemClick(object sender, ItemClickEventArgs args) { }

		public virtual void OnLongClick(object sender, ItemLongClickEventArgs args) { }
		#endregion

		public override string ToString() => PrimaryText;
	}
}