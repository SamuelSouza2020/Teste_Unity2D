using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBall : MonoBehaviour
{
    //Script para posicionar a bola no inicio e liberar o disparo
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
            //Chama o metodo IEnumerator
            StartCoroutine(Lancar());
        }
    }
    IEnumerator Lancar()
    {
        //Função em pausa até passar os segundos "WaitForSeconds(1)"
        yield return new WaitForSeconds(1);
        player.libSpace = true;
    }
}
