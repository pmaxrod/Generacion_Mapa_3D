using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject cubo; // las piezas para generar el mapa
    public int ancho, altura, largo; // medidas del mapa 
    
    public float detalle; // frecuencia - detalle
    public int semilla; // semilla

    // Start is called before the first frame update
    void Start()
    {
        
        GenerarMapa();
    }

    // Update is called once per frame
    void Update()
    {
        //semilla = Random.Range(100000, 900000);
    }

    /// <summary>
    ///  Método que genera el mapa según las medidas
    /// </summary>
    public void GenerarMapa()
    {
        // versión 1 - generar mapa de ruido 

        //for (int i = 0; i < ancho; i++)  // eje x
        //{
        //    for (int j = 0; j < altura; j++)  // eje y
        //    {
        //        for (int k = 0; k < largo; k++)  // eje z
        //        {
        //            Instantiate(cubo, new Vector3(i, j, k), Quaternion.identity);
        //        }
        //    }
        //}


        //versión 2 - cambiar la altura en función de la anchura y el largo(x , z)
        for (int x = 0; x < ancho; x++)  // eje x
        {
            for (int z = 0; z < largo; z++)  // eje z
            {
                altura = (int)(Mathf.PerlinNoise((x / 2 + semilla) / detalle, (z / 2 + semilla) / detalle) * detalle);
                for (int y = 0; y < altura; y++)  // eje y
                {
                    Instantiate(cubo, new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }

    }
}
