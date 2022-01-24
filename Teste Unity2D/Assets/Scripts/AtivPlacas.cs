using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivPlacas : MonoBehaviour
{
    public int asCores;
    float tempoCor = 0;
    GameManager gaM;
    private void Start()
    {
        gaM = GameObject.Find("Gerenc").GetComponent<GameManager>();
    }
    void Update()
    {
        if(asCores > 2)
        {
            tempoCor += Time.deltaTime;
            if(tempoCor > 1)
            {
                tempoCor = 0;
                asCores = 0;
                gaM.pontosPlayer += 100;
            }
        }
    }
}
