using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Algoritmo
{
    PelinNoise_1,
    PelinNoise_2
}

public enum ModoDibujo { MapaRuido, MapaColor, Malla };
 
[System.Serializable]
public struct TerrainType
{
    public string nombre;
    public float altura;
    public Color color; 
}

public class Generador : MonoBehaviour
{
    public const int tamanioMapa = 241; // para que tenga acceso desde la clase TerrenoInfinito

    [Header("Caracteristicas del mapa")]    
    [Range(0,6)]
    [SerializeField] private int nivelDetalle;
    [SerializeField] private float escalaRuido;
    [SerializeField] private ModoDibujo modoDibujo;
    [SerializeField] private float multiplicadorAlturaMalla;
    [SerializeField] private AnimationCurve curvaAlturaMalla;


    [Header("Caracteristicas PersinNoise 2")]
    [SerializeField] private int octavas;
    [Range(0,1)]
    [SerializeField] private float persistencia;
    [SerializeField] private float laguna;
    [SerializeField] private int semilla;
    [SerializeField] private Vector2 desplazamiento;



    [Header("Algoritmo ")]
    [SerializeField] private Algoritmo tipoAlgoritmo = Algoritmo.PelinNoise_1 ;


    public bool autoActualizar = false;

    [Header("Caracteristicas del terreno")]
    public TerrainType[] regiones;
    


    public void GenerarMapa()
    {
        

        bool encontrado = false;

        float[,] mapaRuido = null;
        MostrarMapa mostrar = FindObjectOfType<MostrarMapa>();

       

        switch (tipoAlgoritmo)
        {
            case Algoritmo.PelinNoise_1:
                mapaRuido = PerlinNoise.GenerarMapaRuido( tamanioMapa,  tamanioMapa, escalaRuido);
                break;

            case Algoritmo.PelinNoise_2:
                mapaRuido = PerlinNoise.GenerarMapaRuido( tamanioMapa,  tamanioMapa, semilla, escalaRuido, octavas, persistencia, laguna, desplazamiento);
                break;

        }


        Color[] colorMapa = new Color[ tamanioMapa *  tamanioMapa];

        for (int y = 0; y <  tamanioMapa; y++)
        {
            for (int x = 0; x <  tamanioMapa; x++)
            {
                encontrado = false;
                float alturaActual = mapaRuido[x, y];
                
                for( int i = 0; i < regiones.Length && !encontrado; i++ )
                {
                    if( alturaActual <= regiones[i].altura )
                    {
                        colorMapa[y *  tamanioMapa + x] = regiones[i].color;
                        encontrado = true ;
                    }

                }

            }
        }


        switch( modoDibujo)
        { 

        case ModoDibujo.MapaRuido:
                mostrar.DibujarMapaRuido(GeneradorTexturas.Textura_MapaAltura( mapaRuido));
                break;

        case ModoDibujo.MapaColor:
                mostrar.DibujarMapaRuido(GeneradorTexturas.Textura_MapaColor(colorMapa,  tamanioMapa,  tamanioMapa));
                break;

        case ModoDibujo.Malla:
                mostrar.DibujarMalla(GeneradorMesh.GeneradorMallaTerreno(mapaRuido, multiplicadorAlturaMalla, curvaAlturaMalla, nivelDetalle), GeneradorTexturas.Textura_MapaColor(colorMapa,  tamanioMapa,  tamanioMapa));
                break;
        }        
    }


    /// <summary>
    /// Validar los datos
    /// </summary>
    private void OnValidate()
    {

        if (laguna < 1)
            laguna = 1 ;

        if (octavas < 0)
            octavas = 0 ;
    }

}
