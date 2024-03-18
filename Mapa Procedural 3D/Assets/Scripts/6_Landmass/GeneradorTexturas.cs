using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneradorTexturas
{ 
    public static Texture2D Textura_MapaColor( Color[] _mapaColor, int _ancho, int _alto)
    {
        Texture2D textura = new Texture2D(_ancho, _alto);

        textura.filterMode = FilterMode.Point;
        textura.wrapMode = TextureWrapMode.Clamp;
        textura.SetPixels(_mapaColor);
        textura.Apply();

        return textura;

    }

    public static Texture2D Textura_MapaAltura( float[,] _mapaAltura)
    {
        int ancho = _mapaAltura.GetLength(0);
        int alto = _mapaAltura.GetLength(1);

        
        Color[] colorMapa = new Color[ancho * alto];

        for (int y = 0; y < alto; y++)
        {
            for (int x = 0; x < ancho; x++)
            {
                colorMapa[y * ancho + x] = Color.Lerp(Color.black, Color.white, _mapaAltura[x, y]);
            }
        }

        
        return Textura_MapaColor( colorMapa, ancho, alto) ;
    }
}
