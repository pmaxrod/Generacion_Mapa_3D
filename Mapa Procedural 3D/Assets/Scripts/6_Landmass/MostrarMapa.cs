using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// va a tomar el mapa de ruido y va aconvertirlo en una textura
// entonces va a aplicar esta textura a un plano en la escena


public class MostrarMapa : MonoBehaviour
{
    [SerializeField] public Renderer texturaRender;
    [SerializeField] public MeshFilter meshFilter;
    [SerializeField] public MeshRenderer meshRenderer;

    public void DibujarMapaRuido( Texture2D _textura)
    {      

        texturaRender.sharedMaterial.mainTexture = _textura;

        texturaRender.transform.localScale = new Vector3( _textura.width, 1, _textura.height);
    }

    public void DibujarMalla(DatosMalla _malla, Texture2D _textura)
    {
        meshFilter.sharedMesh = _malla.CrearMalla();
        meshRenderer.sharedMaterial.mainTexture = _textura;  // meshRenderer.sharedMaterial.SetTexture("_mapaBase", _textura);
    }
}
