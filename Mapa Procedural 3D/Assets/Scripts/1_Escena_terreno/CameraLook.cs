using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float sensibilidadRaton = 80f;
    [SerializeField] private Transform personaje;

    private float xRotacion = -90f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float ratonX = Input.GetAxis("Mouse X") * sensibilidadRaton * Time.deltaTime ;
        float ratonY = Input.GetAxis("Mouse Y") * sensibilidadRaton * Time.deltaTime;

        xRotacion += ratonY;
        xRotacion = Mathf.Clamp(xRotacion, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotacion, 0f, 0f);

        personaje.Rotate(Vector2.up * ratonX);
    }
}
