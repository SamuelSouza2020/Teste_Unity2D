using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivPlacas : MonoBehaviour
{
    public int asCores;
    // Update is called once per frame
    void Update()
    {
        if(asCores > 2)
        {
            asCores = 0;
        }
    }
}
