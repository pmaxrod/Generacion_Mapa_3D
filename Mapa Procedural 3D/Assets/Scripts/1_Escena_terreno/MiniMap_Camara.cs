using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap_Camara : MonoBehaviour
{
    [SerializeField] private Transform personaje;


    /// <summary>
    /// Es el último Update al cual llama Unity.
    /// Se suele utilizar para la actulización de la cámara.
    /// Ya que la cámara siguen normalmente al Personaje
    /// </summary>
    private void LateUpdate()
    {
        Vector3 nuevaPosicion = personaje.position;

        nuevaPosicion.y = transform.position.y;

        transform.position = nuevaPosicion;
        
    }
}
