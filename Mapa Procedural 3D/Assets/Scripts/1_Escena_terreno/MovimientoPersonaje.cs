using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float velocidad = 10f ;
    [SerializeField] private float gravedad = -9.8f;

    Vector3 vVelocidad; 
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * x + transform.forward * z;

        characterController.Move( movimiento * velocidad * Time.deltaTime);

        vVelocidad.y += gravedad * Time.deltaTime;

        characterController.Move(vVelocidad * Time.deltaTime);
    }
}
