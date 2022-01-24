using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;
    AudioManager audM;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        audM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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
        if(collision.gameObject.CompareTag("Untagged"))
        {
            audM.auBtd.Play();
        }
    }
}
