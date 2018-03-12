package com.example.v_user.modernhelloworld;

import android.app.PendingIntent;
import android.appwidget.AppWidgetManager;
import android.appwidget.AppWidgetProvider;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.widget.RemoteViews;
import android.widget.Toast;

import static com.example.v_user.modernhelloworld.HelloWorld.generateRandomColor;
import static com.example.v_user.modernhelloworld.R.id.textViewWidget;

/**
 * Implementation of App Widget functionality.
 */
public class HelloWorldW extends AppWidgetProvider {
//    public static Bundle tvw;
//    public static RemoteViews getTextView(){
//        RemoteViews views = new RemoteViews(mContext.getPackageName(), R.id.textViewWidget);
//        return views;
//    }
//    private static Context mContext;

    //    public static Context getContext() {
//        return mContext;
//    }
//   private static final String SYNC_CLICKED    = "automaticWidgetSyncButtonClick";
    static void updateAppWidget(Context context, AppWidgetManager appWidgetManager,
                                int appWidgetId) {


        // Construct the RemoteViews object
        RemoteViews views = new RemoteViews(context.getPackageName(), R.layout.hello_world_w);
        // Instruct the widget manager to update the widget
        appWidgetManager.updateAppWidget(appWidgetId, views);
    }

    @Override
    public void onUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds) {
        // There may be multiple widgets active, so update all of them
//        mContext = this;
        for (int appWidgetId : appWidgetIds) {
//            if(!HelloWorld.isOpen()){
//                Toast.makeText(context, "Abre a aplicação primeiro", Toast.LENGTH_SHORT).show();
//                break;
//            }
            updateAppWidget(context, appWidgetManager, appWidgetId);
            // Create an Intent to launch Activity
            Intent intent = new Intent(context, HelloWorld.class);
            PendingIntent pendingIntent = PendingIntent.getActivity(context, 0, intent, 0);
            //
            // Get the layout for the App Widget and attach an on-click listener
            // to the button
            RemoteViews views = new RemoteViews(context.getPackageName(), R.layout.hello_world_w);
            views.setOnClickPendingIntent(R.id.button_widget, pendingIntent);

            // Tell the AppWidgetManager to perform an update on the current app widget
            appWidgetManager.updateAppWidget(appWidgetId, views);
//            // Set widget's textview to color
//
////            RemoteViews views2 = new RemoteViews(context.getPackageName(),
////                    R.layout.hello_world_w);
////            if (HelloWorld.getContext() == null) {
////                break;
////            }
////            AppWidgetManager mManager = AppWidgetManager.getInstance((HelloWorld
////                    .getContext()));
////            ComponentName cn = new ComponentName(HelloWorld.getContext(),
////                    HelloWorldW.class);
////            views2.setTextColor(textViewWidget, generateRandomColor());
////            mManager.updateAppWidget(cn, views2);
//            // Create an Intent to launch ExampleActivity
//            Intent intent = new Intent(context, HelloWorld.class);
//            PendingIntent pendingIntent = PendingIntent.getActivity(context, 0, intent, 0);
//            //
//            // Get the layout for the App Widget and attach an on-click listener
//            // to the button
//            RemoteViews views = new RemoteViews(context.getPackageName(), R.layout.hello_world_w);
//            views.setOnClickPendingIntent(R.id.button_widget, pendingIntent);
//
//
//            // Tell the AppWidgetManager to perform an update on the current app widget
//            appWidgetManager.updateAppWidget(appWidgetId, views);
        }
    }



    @Override
    public void onEnabled(Context context) {
        // Enter relevant functionality for when the first widget is created

//        RemoteViews views = new RemoteViews(context.getPackageName(), R.layout.activity_hello_world);
//        TextView tv= (TextView)findByViewId(textView);
    }

    @Override
    public void onDisabled(Context context) {
        // Enter relevant functionality for when the last widget is disabled
    }

//    public void ChangeColorW(Context context, AppWidgetManager appWidgetManager, int appWidget) {
//        // Create an Intent to launch ExampleActivity
//        Intent intent = new Intent(context, HelloWorld.class);
//        PendingIntent pendingIntent = PendingIntent.getActivity(context, 0, intent, 0);
//        //
//        // Get the layout for the App Widget and attach an on-click listener
//        // to the button
//        RemoteViews views = new RemoteViews(context.getPackageName(), R.layout.hello_world_w);
//        views.setOnClickPendingIntent(R.id.button_widget, pendingIntent);
//        // Tell the AppWidgetManager to perform an update on the current app widget
//        appWidgetManager.updateAppWidget(appWidget, views);
//    }

//    @Override
//    public void onReceive(Context context, Intent intent) {
//        super.onReceive(context, intent);
//        String action = intent.getAction();
//        if (AppWidgetManager.ACTION_APPWIDGET_UPDATE.equals(action)) {
//            RemoteViews views2 = new RemoteViews(context.getPackageName(),
//                    R.layout.hello_world_w);
////            if () {
////                Toast.makeText(context, "a app está fechada", Toast.LENGTH_SHORT).show();
////            }
//            //condition to correct null error of context, in case the app is terminated
//            if(HelloWorld.getContext()==null){
//                return;
//            }
//            AppWidgetManager mManager = AppWidgetManager.getInstance((HelloWorld
//                    .getContext()));
//            ComponentName cn = new ComponentName(HelloWorld.getContext(),
//                    HelloWorldW.class);
//            views2.setTextColor(textViewWidget, generateRandomColor());
//            mManager.updateAppWidget(cn, views2);
//            super.onReceive(context, intent);

//            RemoteViews views = new RemoteViews(context.getPackageName(), R.layout.hello_world_w);
//            AppWidgetManager.getInstance(context).updateAppWidget(intent.getIntArrayExtra(AppWidgetManager.EXTRA_APPWIDGET_IDS), views);

    @Override
    public void onReceive(Context context, Intent intent) {
        super.onReceive(context, intent);

        String action = intent.getAction();
        if (action.equals("change_color")) {
            //change text color
            RemoteViews views2 = new RemoteViews(context.getPackageName(),
                    R.layout.hello_world_w);
            views2.setTextColor(textViewWidget, generateRandomColor());
            //update widget
            AppWidgetManager mManager = AppWidgetManager.getInstance(context);
            ComponentName cn = new ComponentName(context, HelloWorldW.class);
            mManager.updateAppWidget(cn, views2);
        }
    }
}

//        super.onReceive(context, intent);
//        RemoteViews views = new RemoteViews(context.getPackageName(),
//                R.layout.hello_world_w);
//        AppWidgetManager appWidgetManager = AppWidgetManager
//                .getInstance(context);
//        appWidgetManager.updateAppWidget(new ComponentName(context,
//                HelloWorldW.class), views);



