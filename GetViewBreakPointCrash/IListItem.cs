using static Android.Widget.AdapterView;


namespace MotoConfig.App.Ui.Legacy.MenuScaffold
{
	internal interface IListItem
	{
		protected internal string PrimaryText { get; }
		protected internal string SecondaryText { get; }
		int Order { get; }

		void OnItemClick(object sender, ItemClickEventArgs args);
	}
}