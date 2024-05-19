using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localization : MonoBehaviour {

    static Localization mInstance = null;

    public static Localization Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject obj = new GameObject();
                obj.name = "InterfaceHandler";
                DontDestroyOnLoad(obj);
                //#if UNITY_EDITOR
                mInstance = obj.AddComponent<Localization>();
                //#elif UNITY_IPHONE
                //mInstance 	= obj.AddComponent<IosInterfaceHandler>();
                //#elif UNITY_ANDROID
                //mInstance 	= obj.AddComponent<AndroidinterfaceHandler>();
                //#endif
            }
            return mInstance;
        }
    }

    public SystemLanguage Language;


    public Dictionary<string, Dictionary<int, string>> Texts = new Dictionary<string, Dictionary<int, string>>();

   


    // Use this for initialization
    void Awake()
    {

        Language = Application.systemLanguage;

        //ESPAÑOL

        Dictionary<int, string> spanishValues = new Dictionary<int, string>();

        spanishValues.Add(0, "El Arquero Legendario");
        spanishValues.Add(1, "reporte");
        spanishValues.Add(2, "Puntos:");
        spanishValues.Add(3, "Toca y Arrastra para disparar");
        spanishValues.Add(4, "Nivel");
        spanishValues.Add(5, "Nivel completado");
        spanishValues.Add(6, "Mejor");
        spanishValues.Add(7, "Nivel fallido");


        Texts.Add("ESP", spanishValues);


        //INGLES

        Dictionary<int, string> englishValues = new Dictionary<int, string>();

        englishValues.Add(0, "The Epic Archer");
        englishValues.Add(1, "feedback");
        englishValues.Add(2, "Score:");
        englishValues.Add(3, "Touch and Drag to fire");
        englishValues.Add(4, "Level");
        englishValues.Add(5, "Level Complete");
        englishValues.Add(6, "Best");
        englishValues.Add(7, "Level fail");


        Texts.Add("ING", englishValues);


        //FRANCES

        Dictionary<int, string> frenchValues = new Dictionary<int, string>();

        frenchValues.Add(0, "L'archer épique");
        frenchValues.Add(1, "retour d'information");
        frenchValues.Add(2, "But:");
        frenchValues.Add(3, "Touchez et faites glisser pour tirer");
        frenchValues.Add(4, "Niveau");
        frenchValues.Add(5, "niveau complet");
        frenchValues.Add(6, "Meilleur");
        frenchValues.Add(7, "niveau échec");


        Texts.Add("FRA", frenchValues);


        //ITALIANO

        Dictionary<int, string> italianValues = new Dictionary<int, string>();

        italianValues.Add(0, "The Epic Archer");
        italianValues.Add(1, "riposta");
        italianValues.Add(2, "Punto:");
        italianValues.Add(3, "Tocca e trascina per sparare");
        italianValues.Add(4, "Livello");
        italianValues.Add(5, "livello completato");
        italianValues.Add(6, "Migliore");
        italianValues.Add(7, "livello fallito");

        Texts.Add("ITA", italianValues);


        //ALEMAN

        Dictionary<int, string> germanValues = new Dictionary<int, string>();

        germanValues.Add(0, "Der epische Bogenschütze");
        germanValues.Add(1, "feedback");
        germanValues.Add(2, "Ergebnis:");
        germanValues.Add(3, "Zum Feuern berühren und ziehen");
        germanValues.Add(4, "Niveau");
        germanValues.Add(5, "Level geschafft");
        germanValues.Add(6, "Beste");
        germanValues.Add(7, "Level scheitern");

        Texts.Add("ALE", germanValues);



        //PORTUGUES

        Dictionary<int, string> portugueseValues = new Dictionary<int, string>();



        portugueseValues.Add(0, "O Arqueiro Épico");
        portugueseValues.Add(1, "comentários");
        portugueseValues.Add(2, "Ponto:");
        portugueseValues.Add(3, "Toque e arraste para disparar");
        portugueseValues.Add(4, "Nível");
        portugueseValues.Add(5, "nível completo");
        portugueseValues.Add(6, "Melhor");
        portugueseValues.Add(7, "falha no nível");

        Texts.Add("POR", portugueseValues);


    }

    public string GetValue(int valueId)
    {
       

        Debug.Log("LLEGA VALUE " + valueId.ToString());
      
        switch(Application.systemLanguage)
        {
            case SystemLanguage.Spanish:
                return Texts["ESP"][valueId].ToString();
            case SystemLanguage.English:
                return Texts["ING"][valueId].ToString();
            case SystemLanguage.French:
                return Texts["FRA"][valueId].ToString();
            case SystemLanguage.Italian:
                return Texts["ITA"][valueId].ToString();
            case SystemLanguage.German:
                return Texts["ALE"][valueId].ToString();
            case SystemLanguage.Portuguese:
                return Texts["POR"][valueId].ToString();
            default:
                return Texts["ING"][valueId].ToString();
        }
    }


}
