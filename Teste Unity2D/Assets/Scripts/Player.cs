using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;
    AudioManager audM;
    GameManager gameManager;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        audM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        gameManager = GameObject.Find("Gerenc").GetComponent<GameManager>();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            Empurrao(0, 20);
    }
    void Empurrao(float x, float y)
    {
        rig.AddForce(new Vector2(x,y), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.pontosPlayer++;
        if(collision.gameObject.CompareTag("Untagged"))
        {
            audM.auBtd.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.pontosPlayer++;
    }
}
