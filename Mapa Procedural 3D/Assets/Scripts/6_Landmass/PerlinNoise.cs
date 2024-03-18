using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PerlinNoise 
{
    //-------------------------------------------------------------------------------------------------------------
    public static float[,] GenerarMapaRuido( int _ancho, int _alto, float _escala )
    {
        float[,] mapaRuido = new float[ _ancho, _alto];

        if( _escala <= 0)
        {
            _escala = 0.0001f;
        }

        for( int y = 0; y < _alto; y++)
        {
            for( int x = 0; x < _ancho; x++)
            {
                float muestreoX = x / _escala;
                float muestreoY = y / _escala;

                float perlinValor = Mathf.PerlinNoise(muestreoX, muestreoY);
                mapaRuido[x, y] = perlinValor;
            }
        }

        return mapaRuido;
    }

    //-------------------------------------------------------------------------------------------------------------
    public static float[,] GenerarMapaRuido(int _ancho, int _alto, int _semilla, float _escala, int _octavas, float _persistencia, float _laguna, Vector2 offset)
    {
        float[,] mapaRuido = new float[_ancho, _alto];

        System.Random prng = new System.Random( _semilla);
        Vector2[] octavasOffsets = new Vector2 [_octavas];

        for( int i = 0; i < _octavas; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octavasOffsets[i] = new Vector2(offsetX, offsetY);

        }


        if (_escala <= 0)
        {
            _escala = 0.0001f;
        }

        float alturaMaxRuido = float.MinValue;
        float alturaMinRuido = float.MaxValue;
        float mitadAncho = _ancho / 2;
        float mitadAlto = _alto / 2;

        for (int y = 0; y < _alto; y++)
        {
            for (int x = 0; x < _ancho; x++)
            {
                float amplitud = 1;
                float frecuencia = 1;
                float ruidoAltura = 0;

                for( int i = 0; i < _octavas; i++)
                {
                    float muestreoX = (x - mitadAncho) / _escala * frecuencia + octavasOffsets[i].x;
                    float muestreoY = (y - mitadAlto) / _escala * frecuencia + octavasOffsets[i].y;

                    float perlinValor = Mathf.PerlinNoise(muestreoX, muestreoY) * 2 - 1;
                    ruidoAltura += perlinValor * amplitud;

                    amplitud *= _persistencia;
                    frecuencia *= _laguna;

                    
                }

                if (ruidoAltura > alturaMaxRuido)
                    alturaMaxRuido = ruidoAltura;
                
                else if (ruidoAltura < alturaMinRuido)
                    alturaMinRuido = ruidoAltura;

                mapaRuido[x, y] = ruidoAltura;

            }
        }


        // normalizado el mapa de ruido
        for (int y = 0; y < _alto; y++)
        {
            for (int x = 0; x < _ancho; x++)
            {
                mapaRuido[x, y] = Mathf.InverseLerp(alturaMinRuido, alturaMaxRuido, mapaRuido[x, y]);
            }
        }


        return mapaRuido;
    }
}
