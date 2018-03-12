package com.serralheiro.indica.app;

/**
 * Created by estagiario on 17/03/2017.
 */

//public class Aula {
    class Aula{
        String turma;
        Integer rotacao;
        Integer DayofTheWeek;
        String espaco;

    Aula(){}
    Aula(String t, Integer r, Integer d, String e){
        turma = t;
        rotacao = r;
//        d = new SimpleDateFormat("EEEEE");
//        DayofTheWeek = d.format(new Date());
        DayofTheWeek = d;
        espaco = e;
    }
}
