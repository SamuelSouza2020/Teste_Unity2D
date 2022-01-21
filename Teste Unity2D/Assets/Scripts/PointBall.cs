using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBall : MonoBehaviour
{

    PointEffector2D pontB;

    void Start()
    {
        pontB = GetComponent<PointEffector2D>();
        pontB.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            pontB.enabled = true;
            StartCoroutine(Voo());
        }
    }
    IEnumerator Voo()
    {
        yield return new WaitForSeconds(0.5f);
        pontB.enabled = false;
    }
}
