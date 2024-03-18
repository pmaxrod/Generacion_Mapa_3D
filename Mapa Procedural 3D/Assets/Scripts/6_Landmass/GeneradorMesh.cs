using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneradorMesh 
{
    public static DatosMalla GeneradorMallaTerreno( float[,] _mapaAltura, float _multiplicadorAltura, 
                                                     AnimationCurve _curvaAlturamalla, int _nivelDetalle)
    {
        int ancho = _mapaAltura.GetLength(0);
        int alto  = _mapaAltura.GetLength(1);
        float arribaIzqX = (ancho - 1) / -2f;
        float arribaIzqZ = (alto - 1) / 2f;

        int incSimplificadorMalla = (_nivelDetalle == 0)? 1 : _nivelDetalle * 2;
        int verticesPorLinea = (ancho - 1) / incSimplificadorMalla + 1;

        DatosMalla datoMalla = new DatosMalla( verticesPorLinea, verticesPorLinea);
        int indiceVertice = 0;

        for( int y = 0; y < alto; y += incSimplificadorMalla)
        {
            for( int x = 0; x < ancho; x += incSimplificadorMalla)
            {
                datoMalla.vertices[indiceVertice] = new Vector3( arribaIzqX + x, _curvaAlturamalla.Evaluate( _mapaAltura[x, y]) * _multiplicadorAltura, arribaIzqZ - y);
                datoMalla.uvs[indiceVertice] = new Vector2(x / (float)ancho, y / (float) alto);

                if( x < ancho -1 && y < alto -1)
                {
                    // añadir triangulos a la malla
                    datoMalla.AddTriangulo( indiceVertice,             indiceVertice + verticesPorLinea + 1, indiceVertice + verticesPorLinea);
                    datoMalla.AddTriangulo( indiceVertice + verticesPorLinea + 1, indiceVertice ,            indiceVertice + 1);
                }

                indiceVertice++;
            }
        }

        return datoMalla;
    }
}

public class DatosMalla
{
    public Vector3[] vertices;
    public int[] triangulos;
    public Vector2[] uvs; // uno pro cada vertice del triangulo

    int indiceTriangulos;
    public DatosMalla( int _anchoMalla, int _altoMalla)
    {
        vertices = new Vector3[_anchoMalla * _altoMalla];
        uvs = new Vector2[ _anchoMalla * _altoMalla];
        triangulos = new int[ ( _anchoMalla - 1) * ( _altoMalla - 1) * 6];

        Debug.Log("Dimensiones triangulos: " + _anchoMalla + ", " + _altoMalla);
        Debug.Log((_anchoMalla - 1) * (_altoMalla - 1) * 6);
    }

    public void AddTriangulo( int _a, int _b, int _c )
    {
        triangulos[ indiceTriangulos] = _a;
        triangulos[ indiceTriangulos+1] = _b;
        triangulos[ indiceTriangulos+2] = _c;

        indiceTriangulos += 3;
    }

    public Mesh CrearMalla()
    {
        Mesh malla = new Mesh();

        malla.vertices = vertices;
        malla.triangles = triangulos;
        malla.uv = uvs;
        malla.RecalculateNormals(); // para que la iluminación funcione bien

        return malla;
    }
}
