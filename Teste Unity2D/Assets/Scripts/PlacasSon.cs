using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacasSon : MonoBehaviour
{
    AtivPlacas atP;
    void Start()
    {
        atP = GameObject.Find("testBall").GetComponent<AtivPlacas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(atP.asCores == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            gameObject.GetComponent<Collider2D>().enabled = true;
            atP.asCores++;
        }
    }
}
