using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulsoMag : MonoBehaviour
{
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
                player.GetComponent<Rigidbody2D>().simulated = true;
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,-12), ForceMode2D.Impulse);
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
            dentro=true;
            col.enabled = false;
            tempSaida = 0;
            audM.auAlien.Play();
        }
    }
}
