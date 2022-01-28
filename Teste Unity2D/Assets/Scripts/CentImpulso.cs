using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentImpulso : MonoBehaviour
{
    /// <summary>
    /// Script que centraliza a bola e a dispara aleatoriamente.
    /// </summary>
    Rigidbody2D rigPlayer;
    bool dentro = false, disp = false;
    AudioManager audM;
    private void Start()
    {
        audM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    private void Update()
    {
        //Leva a bola até a posição do Vector3 e depois chama o numaretor que vai disparar a bola.
        if (dentro)
        {
            rigPlayer.transform.position = Vector3.Lerp(rigPlayer.transform.position, new Vector3(-1.977f, 4.026f, 0), 5 * Time.deltaTime);
            if (disp)
            {
                StartCoroutine(Boom());
                disp = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            rigPlayer = col.GetComponent<Rigidbody2D>();
            rigPlayer.velocity = Vector3.zero;
            rigPlayer.simulated = false;
            dentro = true;
            disp = true;
            audM.auTiro.Play();
        }
    }
    IEnumerator Boom()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Collider2D>().enabled = false;
        rigPlayer.simulated = true;
        audM.auAlien.Play();
        rigPlayer.AddForce(new Vector2(10, Random.Range(-15, 15)), ForceMode2D.Impulse);
        dentro = false;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
