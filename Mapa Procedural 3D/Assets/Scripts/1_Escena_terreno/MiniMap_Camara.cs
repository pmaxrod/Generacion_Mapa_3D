using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap_Camara : MonoBehaviour
{
    [SerializeField] private Transform personaje;


    /// <summary>
    /// Es el �ltimo Update al cual llama Unity.
    /// Se suele utilizar para la actulizaci�n de la c�mara.
    /// Ya que la c�mara siguen normalmente al Personaje
    /// </summary>
    private void LateUpdate()
    {
        Vector3 nuevaPosicion = personaje.position;

        nuevaPosicion.y = transform.position.y;

        transform.position = nuevaPosicion;
        
    }
}
