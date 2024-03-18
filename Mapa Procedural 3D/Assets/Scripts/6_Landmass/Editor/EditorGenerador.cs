using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (Generador))]
public class EditorGenerador : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        Generador mapaGenerador = (Generador)target;
       
        if( DrawDefaultInspector())
        {
            if( mapaGenerador.autoActualizar)
            {
                mapaGenerador.GenerarMapa();
            }
        }

        if( GUILayout.Button ("Generar mapa"))
        {
            mapaGenerador.GenerarMapa();
        }
    }
}
