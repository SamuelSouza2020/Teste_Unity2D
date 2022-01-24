using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBall : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = GameObject.Find("Ball").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(2.67f, -2.7f, 0);
            StartCoroutine(Lancar());
        }
    }
    IEnumerator Lancar()
    {
        yield return new WaitForSeconds(1);
        player.libSpace = true;
    }
}
