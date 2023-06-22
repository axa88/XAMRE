# Xamarin Android Minimal Reproducible Examples

GetViewBreakPoint fail.

Cannot successfully set breakpoint in ArrayAdapter GetView Method.

Reproduce
Set breakpoint on ArrayAdapter GetView method and select item in main page list view to trigger.

Result
Setting a breakpoint the output window will log:

Resolved pending breakpoint at 'ArrayAdapters.cs:18,1' to Android.Views.View GetViewBreakPointFail.ArrayAdapters.SimpleListItem2<GetViewBreakPointFail.ListItemBase>.GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent) [0x00000].
Resolved pending breakpoint at 'ArrayAdapters.cs:18,4' to Android.Views.View GetViewBreakPointFail.ArrayAdapters.SimpleListItem2<T_REF>.GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent) [0x00000].


Triggering the method the debugger will 'crash' with error:

The selected debug engine does not support any code executing on the current thread (e.g. only native runtime code is executing). You can switch to another thread to see if there is compatible code running.

