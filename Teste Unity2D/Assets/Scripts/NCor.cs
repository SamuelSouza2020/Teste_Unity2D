using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCor : MonoBehaviour
{
    SpriteRenderer sr;
    AudioManager audM;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        audM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            audM.auBumf.Play();
            StartCoroutine(Mudanc());
        }
    }
    IEnumerator Mudanc()
    {
        yield return new WaitForSeconds(0.1f);
        sr.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.3f);
        sr.color = new Color(1, 1, 1, 1);
    }
}
