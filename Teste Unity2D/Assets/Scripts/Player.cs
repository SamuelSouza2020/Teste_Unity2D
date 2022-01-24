using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;
    AudioManager audM;
    GameManager gameManager;

    public bool libSpace = false;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        audM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        gameManager = GameObject.Find("Gerenc").GetComponent<GameManager>();
        libSpace = false;
    }
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && libSpace)
        {
            Empurrao(0, 20);
            libSpace = false;
        }
    }
    void Empurrao(float x, float y)
    {
        rig.AddForce(new Vector2(x,y), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Untagged"))
        {
            audM.auBtd.Play();
        }
        if(collision.gameObject.CompareTag("Csom"))
        {
            gameManager.pontosPlayer+=2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Csom"))
        {
            gameManager.pontosPlayer+=2;
        }
        if(collision.gameObject.CompareTag("speed"))
        {
            gameManager.pontosPlayer++;
            audM.auSpe.Play();
        }
    }
}
