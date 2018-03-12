package com.serralheiro.indica.app;

import android.content.res.AssetManager;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.io.InputStream;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

/**
 * Created by estagiario on 17/03/2017.
 */

public class XMLParser {

    static List<String> xturmas = new ArrayList<>();
    static List<Aula> rawAulas = new ArrayList<>();
    static List<Rotacao> rotacoes = new ArrayList<>();
    static ArrayList<Balneario> balnearios = new ArrayList<>();

    void readXMLFiles(AssetManager assets) {

        // Criar lista de objetos "Person" a preencher com o conteúdo do
        // ficheiro XML, para devolver no final
        InputStream is = null;

        //aulas
        try {
            is = assets.open("aulas.xml");
            DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(is);

            Element element = doc.getDocumentElement();
            element.normalize();

            NodeList nList = doc.getElementsByTagName("record");


            for (int i = 0; i < nList.getLength(); i++) {

                Node node = nList.item(i);
                if (node.getNodeType() == Node.ELEMENT_NODE) {
                    Element e = (Element) node;
                    //get aula parameteros
                    String xmlTurma = getValue("turma", e);
                    Integer rotc = Integer.parseInt(getValue("rotacao", e));
                    Integer day = Integer.parseInt(getValue("dia", e));
                    String local = getValue("local", e);
                    //make aula
                    Aula a = new Aula(xmlTurma, rotc, day, local);
                    if (!xturmas.contains(xmlTurma)) {
//                        a.turma = xmlTurma;
                        xturmas.add(xmlTurma);
                    }
                    //add aula
                    rawAulas.add(a);
                }
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

        //rotacoes
        try {
            is = assets.open("rotacao.xml");
            DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(is);

            Element element = doc.getDocumentElement();
            element.normalize();
            //datas, para o formato que está no XML
            DateFormat df = new SimpleDateFormat("dd/MM/yyyy");
            NodeList nList = doc.getElementsByTagName("record");

            for (int i = 0; i < nList.getLength(); i++) {
                Node node = nList.item(i);
                if (node.getNodeType() == Node.ELEMENT_NODE) {
                    Element e = (Element) node;
                    Date dstr = df.parse(getValue("datastart", e));
                    Date dend = df.parse(getValue("dataend", e));
                    int n = Integer.parseInt(getValue("number", e));
                    Rotacao r = new Rotacao(dstr, dend, n);
                    rotacoes.add(r);
                }

            }
        } catch (Exception e) {
            e.printStackTrace();
        }

        //balnearios
        try {
            is = assets.open("balnearios.xml");
            DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(is);

            Element element = doc.getDocumentElement();
            element.normalize();

            NodeList nList = doc.getElementsByTagName("record");

            for (int i = 0; i < nList.getLength(); i++) {
                Node node = nList.item(i);
                Element e = (Element) node;
                String m = getValue("masculino", e);
                String f = getValue("feminino", e);
                String l = getValue("local", e);
                Balneario b = new Balneario(m, f, l);
                balnearios.add(b);

            }

        } catch (Exception e) {
            e.printStackTrace();
        }

    }


    private static String getValue(String tag, Element element) {
        NodeList nodeList = element.getElementsByTagName(tag).item(0).getChildNodes();
        Node node = nodeList.item(0);
        return node.getNodeValue();
    }
}
