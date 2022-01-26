using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulsoMag : MonoBehaviour
{
    /// <summary>
    /// Script usado no cano, onde se a bola
    /// encostar, ela é puxada e atirada com uma
    /// força aleatória (Random)
    /// </summary>
    [SerializeField]
    bool dentro = false;
    GameObject player;
    float tempoBall = 0, tempSaida = 0;
    Collider2D col;
    AudioManager audM;

    void Start()
    {
        dentro = false;
        player = GameObject.Find("Ball");
        col = GetComponent<Collider2D>();
        audM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    void Update()
    {
        tempSaida += Time.deltaTime;
        if(tempSaida > 6)
        {
            col.enabled = true;
        }
        if(dentro)
        {
            player.transform.position = Vector3.Lerp(player.transform.position, new Vector2(-1.88f, 4.51f), 2 * Time.deltaTime);
            player.GetComponent<Rigidbody2D>().simulated = false;
            tempoBall += Time.deltaTime;
            if(tempoBall > 2.2)
            {
                //Aqui é adicionado o Random.Range que deixa o valor aleatório.
                player.GetComponent<Rigidbody2D>().simulated = true;
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Random.Range(-28,-42)), ForceMode2D.Impulse);
                audM.auTiro.Play();
                tempoBall = 0;
                dentro = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Para não ficar em loop de jogar a bola e puxar
            //Assim que atira a bola o collider é desativado por 6 segundos.
            dentro=true;
            col.enabled = false;
            tempSaida = 0;
            audM.auAlien.Play();
        }
    }
}
