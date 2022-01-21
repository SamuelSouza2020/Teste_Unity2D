using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBall : MonoBehaviour
{
    GameObject player;
    PointEffector2D pontB;

    void Start()
    {
        player = GameObject.Find("Ball");
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
            StartCoroutine(Lancar());
        }
    }
    IEnumerator Lancar()
    {
        yield return new WaitForSeconds(1);
        pontB.enabled = false;
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0,-3), 0), ForceMode2D.Impulse);
    }
}
