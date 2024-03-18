using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrenoInfinito : MonoBehaviour
{
    public const float distanciaMax = 300; // Distancia máxima a la que el espectador puede ver
    public Transform vistaEspectador;      // vista del espectador
    
    public static Vector2 posEspectador;   // posición del espectador

    int tamanioFragmento; // tamaño del fragmento a visualizar 
    int fragmentosVisiblesEnVista; // distancia máxima de visualización

    private void Start()
    {
        
    }
}
