package com.serralheiro.indica.app;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
//import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.Spinner;
import android.widget.TextView;

import java.util.ArrayList;

//import static com.example.v_user.inef.R.id.spinner_second;
import static com.serralheiro.indica.app.R.id.textViewBalneário;
import static com.serralheiro.indica.app.R.id.textViewData;
import static com.serralheiro.indica.app.R.id.textViewLocal;
import static com.serralheiro.indica.app.XMLParser.balnearios;
import static com.serralheiro.indica.app.main.turma;

public class second_screen extends Activity {

    public Context seconds_context = this;
    public ViewGroup ViewAnimations;

    public void spinnerbutton(View view) {
        finish();
        main.spinner.performClick();

    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second_screen);


        //Set ViewAnimations
        ViewAnimations = (ViewGroup) findViewById(R.id.linear_addviews);
        //Set button
        TextView bu = (TextView) findViewById(R.id.textViewTurma2);
        bu.setText("" + turma);
        bu.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                spinnerbutton(v);
            }
        });
        //get from intent
        Intent intent = getIntent();

        ArrayList<String> datas = intent.getStringArrayListExtra("finaldates");
        ArrayList<String> locais = intent.getStringArrayListExtra("finalocal");
        boolean[] stops = intent.getBooleanArrayExtra("stops");
        int amountofaulas = intent.getIntExtra("amountofaulas", 1);


        for (int i = 0; i < amountofaulas; i++) {

            final ViewGroup vg = (ViewGroup) LayoutInflater.from(seconds_context).inflate(
                    R.layout.views, ViewAnimations, false);

            if (!(i == 0)) {
                if (datas.get(i).equals(datas.get(i - 1))) continue;
            }
//            textviews
            String data = datas.get(i);
            ((TextView) vg.findViewById(textViewData)).setText(data);
            String local = locais.get(i);
            ((TextView) vg.findViewById(textViewLocal)).setText(local);

            for (int j = 0; j < balnearios.size(); j++) {
                Balneario b = balnearios.get(j);
                if (locais.get(i).equals(b.local)) {
                    ((TextView) vg.findViewById(textViewBalneário)).setText(b.feminino + "\n" + b.masculino);
                    break;
                }
            }
            //remover os vazios
            if (locais.get(i).equals(""))
                continue;
            //stop
            if (stops[i]) break;
            ViewAnimations.addView(vg);
        }

    }


}
