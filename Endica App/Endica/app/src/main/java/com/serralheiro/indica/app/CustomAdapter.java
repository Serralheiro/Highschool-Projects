package com.serralheiro.indica.app;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.List;

/**
 * Created by V-User on 31/03/2017.
 */

class CustomAdapter extends ArrayAdapter<String> {

    private int hidingItemIndex;

    //autor:http://stackoverflow.com/questions/9863378/how-to-hide-one-item-in-an-android-spinner

    CustomAdapter(Context context, int textViewResourceId, List<String> objects, int hidingItemIndex) {
        super(context, textViewResourceId, objects);
        this.hidingItemIndex = hidingItemIndex;
    }
    @Override
    public View getDropDownView(int position, View convertView, ViewGroup parent) {
        View v = null;
        if (position == hidingItemIndex) {
            TextView tv = new TextView(getContext());
            //vai parecer que não está lá
            tv.setHeight(0);
            tv.setVisibility(View.GONE);
            v = tv;
        } else {
            v = super.getDropDownView(position, null, parent);
        }
        return v;
    }
}

