using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrenoInfinito : MonoBehaviour
{
    public const float distanciaMax = 300; // Distancia m�xima a la que el espectador puede ver
    public Transform vistaEspectador;      // vista del espectador
    
    public static Vector2 posEspectador;   // posici�n del espectador

    int tamanioFragmento; // tama�o del fragmento a visualizar 
    int fragmentosVisiblesEnVista; // distancia m�xima de visualizaci�n

    private void Start()
    {
        
    }
}
