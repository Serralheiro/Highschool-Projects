package com.serralheiro.indica.app;

import java.util.ArrayList;
import java.util.List;

import static com.serralheiro.indica.app.XMLParser.rawAulas;
import static com.serralheiro.indica.app.XMLParser.rotacoes;

/**
 * Created by estagiario on 28/03/2017.
 */

class Turma {
    private String turma;
    static List<Aula> types;

    //    Aula aula;
    Turma(String t) {

        turma = t;
    }

    void getTypesofAula() {
        List<Aula> TypesofAulasbyTurma = new ArrayList<>();

        for (Aula a : rawAulas) {
            if (a.turma.equals(turma)) {
                TypesofAulasbyTurma.add(a);
            }
        }
        types = TypesofAulasbyTurma;
    }

    Integer amountofAulas() {
        int amount = 0;
        List<Aula> fullaulas = new ArrayList<>();
        for (Aula a : types) {
            for (Rotacao r : rotacoes) {
                if (a.rotacao.equals(r.number)) {
                    Aula reala = new Aula(turma, r.number, a.DayofTheWeek, a.espaco);
                    fullaulas.add(reala);
                }
            }
        }
        amount = fullaulas.size();
        return amount;
    }


}
