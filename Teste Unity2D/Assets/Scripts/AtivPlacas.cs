using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivPlacas : MonoBehaviour
{
    public int asCores;
    float tempoCor = 0;
    // Update is called once per frame
    void Update()
    {
        if(asCores > 2)
        {
            tempoCor += Time.deltaTime;
            if(tempoCor > 1)
            {
                tempoCor = 0;
                asCores = 0;
            }
        }
    }
}
