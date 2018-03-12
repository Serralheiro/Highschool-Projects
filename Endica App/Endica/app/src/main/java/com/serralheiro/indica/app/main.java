package com.serralheiro.indica.app;

import android.app.Activity;
//import android.app.PendingIntent;
import android.app.AlertDialog;
import android.content.Context;
//import android.support.v7.app.AppCompatActivity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Configuration;
import android.os.Bundle;
//import android.view.LayoutInflater;
//import android.view.MotionEvent;
import android.view.LayoutInflater;
import android.view.View;
//import android.view.ViewGroup;
import android.widget.AdapterView;
//import android.widget.AdapterViewFlipper;
//import android.widget.ArrayAdapter;
//import android.widget.LinearLayout;
import android.widget.ImageView;
import android.widget.Spinner;
//import android.widget.SpinnerAdapter;
//import android.widget.TableLayout;
//import android.widget.TextView;
//import android.widget.Toast;

import com.google.android.gms.ads.AdListener;
import com.google.android.gms.ads.AdRequest;
import com.google.android.gms.ads.InterstitialAd;
import com.google.android.gms.ads.MobileAds;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collections;
import java.util.Date;
import java.util.List;
//import java.util.Locale;

import static com.serralheiro.indica.app.R.id.imageViewA;
//import static com.example.v_user.inef.R.id.imageViewB;
//import static com.example.v_user.inef.R.id.tableRowAulas;
//import static com.example.v_user.inef.R.id.textViewD;
//import static com.example.v_user.inef.R.id.spinner;
//import static com.example.v_user.inef.R.id.textViewBalneário;
//import static com.example.v_user.inef.R.id.textViewData;
//import static com.example.v_user.inef.R.id.textViewL;
//import static com.example.v_user.inef.R.id.textViewLocal;
//import static com.example.v_user.inef.R.id.textViewPA;
//import static com.example.v_user.inef.R.id.textViewturma;
//import static com.example.v_user.inef.Turma.types;
import static com.serralheiro.indica.app.R.id.imageViewB;
import static com.serralheiro.indica.app.Turma.types;
//import static com.example.v_user.inef.XMLParser.balnearios;
//import static com.example.v_user.inef.XMLParser.rawAulas;
import static com.serralheiro.indica.app.XMLParser.rotacoes;
import static com.serralheiro.indica.app.XMLParser.xturmas;


public class main extends Activity {

    //variables
//    public ViewGroup ViewAnimations;
    public Context context;
    boolean pa = false;
    boolean ontheday = false;
    //calendário adiantado para conseguir as datas através dos ints
    public Calendar c = Calendar.getInstance();
    public List<Date> nextclasses = new ArrayList<>();
    public List<Integer> daysoftheweek = new ArrayList<>();


    public List<Aula> AulasByTurma = new ArrayList<>();
    public Aula currentaula = new Aula();
    public static String turma;
    public static Spinner spinner;
    //public String turma_picked;
    public static SimpleDateFormat df = new SimpleDateFormat("dd-MM");
    private InterstitialAd mInterstitialAd;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        context = this;
        setContentView(R.layout.activity_main);
        SharedPreferences sharedPref = getPreferences(Context.MODE_PRIVATE);

        //anúncios
        MobileAds.initialize(this, "ca-app-pub-4421043363664252~3198509375");
        mInterstitialAd = new InterstitialAd(this);
        mInterstitialAd.setAdUnitId("ca-app-pub-4421043363664252/6112447322");
        AdRequest request = new AdRequest.Builder().build();
        mInterstitialAd.loadAd(request);

        findViewById(imageViewB).setBackgroundResource(R.drawable.logotipo3);
        ImageView infoImage = (ImageView)findViewById(imageViewA);
        infoImage.setBackgroundResource(R.drawable.info_black);

        XMLParser parser = new XMLParser();
        parser.readXMLFiles(getAssets());

        //Aproveteitei a lista xturmas para o spinner
        //alfabetizar sturma
        Collections.sort(xturmas);

        //adiconar primeiro item ao spinner
        xturmas.add(0, "Selecione a turma");

        //deal with spinner
        spinner = (Spinner) findViewById(R.id.spinner);
        //
        CustomAdapter adapter = new CustomAdapter(context,
                R.layout.spinner_item, xturmas, 0);
        spinner.setAdapter(adapter);

        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

                if (position == 0) {
                    return;
                }

//                //create turma
                turma = xturmas.get(position);
                SharedPreferences sharedPref = getPreferences(Context.MODE_PRIVATE);

                SharedPreferences.Editor confs = sharedPref.edit();
                confs.putString(getString(R.string.current_t), turma);
                confs.commit();
                LancaAtividade2(turma);
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
            }
        });

        String turmaSelecionada = sharedPref.getString(getString(R.string.current_t), null);

        //sharedpref
        if (turmaSelecionada != null) {
            turma = turmaSelecionada;
            LancaAtividade2(turma);
        }

        //listener no info
        infoImage.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                //anúncios
                MobileAds.initialize(context, "ca-app-pub-4421043363664252~3198509375");
                mInterstitialAd = new InterstitialAd(context);
                mInterstitialAd.setAdUnitId("ca-app-pub-4421043363664252/6112447322");
                AdRequest request = new AdRequest.Builder().build();
                mInterstitialAd.loadAd(request);
                info(v);
            }
        });
    }

    public Date getData(Integer i, Integer amountofaulas) {
//        //variáveis
        Date daulai = null;
        Date proximaula = null;

        //primeira vez que é chamado

        if (i == 0) {
            //variáveis
            Calendar ce = Calendar.getInstance();
            Date dayofrequest = ce.getTime();
            pa = false;
            //reset daysoftheweek
            daysoftheweek = new ArrayList<>();
            //criar a lista dos dias da semana
            for (Aula a : AulasByTurma) {
                if (!daysoftheweek.contains(a.DayofTheWeek)) {
                    daysoftheweek.add(a.DayofTheWeek);
                }
            }
            //set calendar for dayofrequest, just only one
            c.setTime(dayofrequest);
            ce.setTime(dayofrequest);

            //Reset nextclasses
            nextclasses = new ArrayList<>();


            //create lista das próximas aulas
            for (int j = 0; j < amountofaulas; j++) {
                Date d = getDayByInt();
                if (!nextclasses.contains(d))
                    nextclasses.add(d);
            }
            //if aula dayforequest
            for (Integer t : daysoftheweek) {
                if (getDayofTheWeek(dayofrequest).equals(t)) {
                    //o pedido foi feito no dia
                    ontheday =true;
                    daulai = dayofrequest;
                    return daulai;
                }
            }

            //get próxima aula
            outerloop:
            for (int j = 0; j < 8; j++) {
                pa = true;
                ce.add(Calendar.DAY_OF_WEEK, 1);
                Date tomorrow = ce.getTime();
                Integer to = getDayofTheWeek(tomorrow);
                for (Integer t :
                        daysoftheweek) {
                    if (to.equals(t)) {
                        proximaula = tomorrow;
                        daulai = proximaula;
                        //get data of próximaaula
//                        data = df.format(proximaula);
                        break outerloop;
                    }
                }
            }
        } else {
            /*como deu a próxima aula, que estava no index 0
            agora é preciso ir buscar a aula que está em i-1
             */
            if (pa||ontheday) daulai = nextclasses.get(i - 1);
            else daulai = nextclasses.get(i);
            //que é para no final não faltar nenhuma aula
        }

        return daulai;
    }


    public Date getDayByInt() {
        Date datebyint = null;

        outerloop:
        for (int i = 0; i < 8; i++) {
            c.add(Calendar.DAY_OF_WEEK, 1);
            Date tomorrow = c.getTime();
            Integer to = getDayofTheWeek(tomorrow);
            for (Integer t :
                    daysoftheweek) {
                if (to.equals(t)) {
                    datebyint = tomorrow;
                    break outerloop;
                }
            }

        }

        return datebyint;
    }

    public Integer getDayofTheWeek(Date d) {
        // Determinar, a partir da data selecionada, qual é o dia da semana
        Calendar cal = Calendar.getInstance();
        cal.setTime(d);
        return cal.get(Calendar.DAY_OF_WEEK);
    }

    public Integer getDayofthYear(Date d){
        Calendar cee = Calendar.getInstance();
        cee.setTime(d);
        return cee.get(Calendar.DAY_OF_YEAR);

    }

    public String getLocal(Integer i, Date d) {
        //variáveis
        //vou contruir a aula aos poucos
        String local = "";
        boolean aula = false;

        //get data da aula
//        if (i == 0) {
//            currentdate = d;
//        } else {
//            currentdate = nextclasses.get(i - 1);
//        }
        //conversão a calendário
        long currentdate = toDateLong(d);


        //com a data vou buscar a rotação
        for (Rotacao r : rotacoes) {

            //para resolver o problema da sexta-feira
            //e das transições de rotacoes

            //conversão a calendários
            long rdatastart = toDateLong(r.datastart);
            long rdataend = toDateLong(r.dataend);
            if ((currentdate >= rdatastart && currentdate <= rdataend) ||
                    getDayofthYear(d).equals(getDayofthYear(r.datastart))||
                    getDayofthYear(d).equals(getDayofthYear(r.dataend))) {
                    aula = true;
                currentaula.rotacao = r.number;
            }
        }
        //com a rotação vou buscar o local
        if (aula) {
            Calendar ce = Calendar.getInstance();
            ce.setTime(d);
            currentaula.DayofTheWeek = ce.get(Calendar.DAY_OF_WEEK);
            //get local
            for (Aula a : types) {
                if (a.rotacao.equals(currentaula.rotacao) &&
                        currentaula.DayofTheWeek.equals(a.DayofTheWeek)) {
                    local = a.espaco;
                }
            }
        }
        return local;
    }

    public static Boolean checkforStop(Date d) {
        Boolean stop = false;
        long limit = (rotacoes.get(rotacoes.size() - 1).dataend).getTime();
        long de = d.getTime();

        if (de >= limit) {
            stop = true;
        }
        return stop;
    }

    public static long toDateLong(Date date) {
//        Calendar cal = Calendar.getInstance();
//        cal.setTime(date);
        return date.getTime();
    }

    @Override
    protected void onResume() {
        super.onResume();
//        Toast.makeText(context, "voltou para trás", Toast.LENGTH_SHORT).show();

        //reset spinner
        Object selected = spinner.getSelectedItem();
        Object first = spinner.getItemAtPosition(0);
        if (!selected.equals(first)) {
            //sempre que volta para trás, volta a colocar o "select turma"
            CustomAdapter adapter = new CustomAdapter(context,
                    R.layout.spinner_item,
                    xturmas, 0);
            spinner.setAdapter(adapter);

        }
    }

    private void LancaAtividade2(String turma) {
        Turma t = new Turma(turma);
//
//                //create types
        t.getTypesofAula();

        //resets
        AulasByTurma = types;
        c = Calendar.getInstance();
        currentaula = new Aula();

        //get amountofaulas
        int amountofaulas = t.amountofAulas();
        //what goes to the other activity
        ArrayList<String> finaldates = new ArrayList<String>();
        boolean[] stops = new boolean[amountofaulas];
        ArrayList<String> finalocal = new ArrayList<String>();
        ArrayList<String> finalbalneario = new ArrayList<String>();


        //mexer a partir daqui
        //add views
        for (int i = 0; i < amountofaulas; i++) {

            //dados da aula
            Date data = getData(i, amountofaulas);
//            String d = df.format(data);

            String l = getLocal(i, data);
            String d = df.format(data);

            stops[i]=checkforStop(data);

            finaldates.add(d);
            finalocal.add(l);

        }
        //preparar dados para enviar para o second_Screen
        Intent changeactivity = new Intent(context, second_screen.class);
        changeactivity.putExtra("finaldates", finaldates);
        changeactivity.putExtra("finalocal", finalocal);
        changeactivity.putExtra("finalbalneario", finalbalneario);
        changeactivity.putExtra("amountofaulas", amountofaulas);
        changeactivity.putExtra("stops",stops);

        startActivity(changeactivity);

        //show add
        mInterstitialAd.setAdListener((new AdListener(){
            public void onAdLoaded(){
                mInterstitialAd.show();
            }

        }));
    }
    public void info(View view){

        AlertDialog alert;

//        Toast.makeText(context, "botão_info", Toast.LENGTH_SHORT).show();
        LayoutInflater li = getLayoutInflater();
        View v = li.inflate(R.layout.alertdialog, null);

        AlertDialog.Builder builder = new AlertDialog.Builder(this);
//        builder.setTitle("Info");
//        builder.setCustomTitle()
        builder.setView(v);

        alert = builder.create();



        alert.show();
        //show add
        mInterstitialAd.setAdListener((new AdListener(){
            public void onAdLoaded(){
                mInterstitialAd.show();
            }

        }));


    }

    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        super.onConfigurationChanged(newConfig);
//        //o ecrã mudou de orientação
    }
}