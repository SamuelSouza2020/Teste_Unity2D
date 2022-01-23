using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassAud : MonoBehaviour
{

    AudioManager audM;

    void Start()
    {
        audM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            audM.audPas.Play();
    }
}
