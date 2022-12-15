using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segredo : MonoBehaviour
{
    public Transform Teleporte;

    void OnCollisionEnter2D(Collision2D colide) 
    {
        if(colide.gameObject.tag=="Player")
        {
            colide.gameObject.transform.position = Teleporte.position;
        }
    }
}
