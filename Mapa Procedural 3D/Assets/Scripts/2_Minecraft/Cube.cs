using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if( Physics.Raycast( transform.position, transform.up))
            GetComponent<MeshRenderer>().enabled = false;
    }


}
