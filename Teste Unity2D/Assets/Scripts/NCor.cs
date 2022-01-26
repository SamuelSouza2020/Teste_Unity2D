using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCor : MonoBehaviour
{
    /// <summary>
    /// Script utilizado para mudar a cor e tocar
    /// um efeito sonoro quando encosta na bola
    /// </summary>
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
            //Aqui é chamado a função IEnumerator
            StartCoroutine(Mudanc());
        }
    }
    IEnumerator Mudanc()
    {
        //O comando só é chamado depois de passar o tempo dentro do parenteses ()
        yield return new WaitForSeconds(0.1f);
        sr.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.3f);
        sr.color = new Color(1, 1, 1, 1);
    }
}
