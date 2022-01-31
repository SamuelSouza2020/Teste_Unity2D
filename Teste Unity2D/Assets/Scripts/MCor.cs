using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCor : MonoBehaviour
{
    /// <summary>
    /// Script utilizado para mudar a cor, tamanho e
    /// tocar um efeito sonoro quando encosta na bola
    /// </summary>
    SpriteRenderer sr;
    ParticleSystem ps;
    Transform gm;
    AudioManager audM;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ps = transform.GetChild(0).GetComponent<ParticleSystem>();
        gm = GetComponent<Transform>();
        audM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
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
        ps.Play();
        gm.localScale = new Vector2(0.6f, 0.6f);
        gm.localScale = Vector3.Lerp(gm.localScale, new Vector2(0.8f, 0.8f), Time.deltaTime);
        yield return new WaitForSeconds(0.3f);
        sr.color = new Color(1, 1, 1, 1);
        gm.localScale = new Vector2(0.8f, 0.8f);
    }
}
