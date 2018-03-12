package com.example.v_user.modernhelloworld;

import android.app.PendingIntent;
import android.appwidget.AppWidgetManager;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.RemoteViews;
import android.widget.TextView;

import java.util.Random;

//import static com.example.v_user.modernhelloworld.HelloWorldW.tvw;
import static com.example.v_user.modernhelloworld.R.id.textView;
//import static com.example.v_user.modernhelloworld.HelloWorldW.getTextView;
//import static com.example.v_user.modernhelloworld.HelloWorldW.getContext;
import static com.example.v_user.modernhelloworld.R.id.textViewWidget;

public class HelloWorld extends AppCompatActivity {



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_hello_world);
//        open = true;

    }

    public static int generateRandomColor() {
        int randomColor;
        Random rand = new Random();
        //generates random colo
        int r = rand.nextInt();
        int g = rand.nextInt();
        int b = rand.nextInt();
        randomColor = Color.rgb(r, g, b);
        return randomColor;
        //
        //gets textview
//        TextView tv = (TextView) findViewById(textView);
        //sets random color to textview
//        tv.setTextColor(randomColor);
//        RemoteViews viewsact = new RemoteViews(mContext.getPackageName(), textView);
//        viewsact.setTextColor(textView, randomColor);


//        tvw.putInt("color", randomColor);
//        if (tvw==null){
//        getTextView(getContext()).setTextColor(textViewWidget, randomColor);
//        }
//        //update widget
//        Intent intent = new Intent(this,HelloWorldW.class);
//        intent.setAction(AppWidgetManager.ACTION_APPWIDGET_UPDATE);
////      Use an array and EXTRA_APPWIDGET_IDS instead of AppWidgetManager.EXTRA_APPWIDGET_ID,
////      since it seems the onUpdate() is only fired on that:
//        int[] ids = {R.xml.modern_hello_world_w_info};
//        intent.putExtra(AppWidgetManager.EXTRA_APPWIDGET_IDS,ids);
//        sendBroadcast(intent);
//        ChangeTextColor(randomColor);

    }

//    public void ChangeTextColor(int color) {
//        TextView tv = (TextView)findViewById(textView);
//        tv.setTextColor(generateRandomColor());


    //gets texview
//        TextView tvw = (TextView) findViewById(R.id.textViewWidget);
//        //sets color
//        tvw.setTextColor(color);
//        //update widget
//        Intent intent = new Intent(this,HelloWorldW.class);
//        intent.setAction(AppWidgetManager.ACTION_APPWIDGET_UPDATE);
////      Use an array and EXTRA_APPWIDGET_IDS instead of AppWidgetManager.EXTRA_APPWIDGET_ID,
////      since it seems the onUpdate() is only fired on that:
//        int[] ids = {R.xml.modern_hello_world_w_info};
//        intent.putExtra(AppWidgetManager.EXTRA_APPWIDGET_IDS,ids);
//        sendBroadcast(intent);
//    }
//    }

    public void ChangeTextColor(View view) {
        //get textview
        TextView tv = (TextView) findViewById(textView);
        //set random color to textivew
        tv.setTextColor(generateRandomColor());
        //tell to widget to change color too
        Intent intent = new Intent();
        intent.setAction("change_color");
        sendBroadcast(intent);
//        // Fire Widget's update with Intent
//        Intent intent = new Intent(this, HelloWorldW.class);
//        intent.setAction("android.appwidget.action.APPWIDGET_UPDATE");
//        // Use an array and EXTRA_APPWIDGET_IDS instead of
//        // AppWidgetManager.EXTRA_APPWIDGET_ID,
//        // since it seems the onUpdate() is only fired on that:
//        int[] ids = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
//        intent.putExtra(AppWidgetManager.EXTRA_APPWIDGET_IDS, ids);
//        sendBroadcast(intent);
    }
//    public void OpenActivity(View view){
//        Intent intent = new Intent(mContext, HelloWorld.class);
//        PendingIntent pendingIntent = PendingIntent.getActivity(mContext, 0, intent, 0);
//        // Get the layout for the App Widget and attach an on-click listener
//        // to the button
//        RemoteViews views = new RemoteViews(mContext.getPackageName(), R.layout.hello_world_w);
//        views.setOnClickPendingIntent(R.id.button_widget, pendingIntent);
//
//    }
//    public static boolean isOpen() {
//        return open;
//    }

//    @Override
//    protected void onDestroy() {
//        super.onDestroy();
//        open = false;
//    }
}

