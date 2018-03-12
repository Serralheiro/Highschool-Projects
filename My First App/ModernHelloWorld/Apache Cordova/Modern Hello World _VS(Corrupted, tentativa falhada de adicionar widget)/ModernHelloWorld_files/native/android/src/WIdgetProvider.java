package your.package.name;

public class ListWidgetProvider extends run.ace.AppWidgetProvider {
  @Override protected int getLayoutResourceId(android.content.Context context) {
    return run.ace.NativeHost.getResourceId("list_widget_layout", "layout", context);
  }

  @Override protected int getViewResourceId(android.content.Context context) {
    return run.ace.NativeHost.getResourceId("hello_world_w", "id", context);
  }

  @Override protected int getItemResourceId(android.content.Context context) {
    return run.ace.NativeHost.getResourceId("list_widget_item", "id", context);
  }

  @Override protected int getItemTextResourceId(android.content.Context context) {
    return run.ace.NativeHost.getResourceId("list_widget_item_text", "id", context);
  }

  @Override protected int getItemLayoutResourceId(android.content.Context context) {
    return run.ace.NativeHost.getResourceId("list_widget_item", "layout", context);
  }
}