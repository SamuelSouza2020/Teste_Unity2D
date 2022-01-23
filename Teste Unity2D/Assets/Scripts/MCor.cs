using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCor : MonoBehaviour
{
    SpriteRenderer sr;
    ParticleSystem ps;
    Transform gm;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ps = transform.GetChild(0).GetComponent<ParticleSystem>();
        gm = GetComponent<Transform>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Mudanc());
        }
    }
    IEnumerator Mudanc()
    {
        yield return new WaitForSeconds(0.1f);
        sr.color = new Color(1, 0, 0, 1);
        ps.Play();
        gm.localScale = new Vector2(0.8f, 0.8f);
        gm.localScale = Vector3.Lerp(gm.localScale, new Vector2(0.8f, 0.8f), Time.deltaTime);
        yield return new WaitForSeconds(0.3f);
        sr.color = new Color(1, 1, 1, 1);
        gm.localScale = new Vector2(1, 1);
    }
}
