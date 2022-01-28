using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour
{
    /// <summary>
    /// Script que puxa a bola e a dispara
    /// </summary>
    Rigidbody2D rigPlayer;
    bool dentro = false, disp = false;
    [SerializeField]
    Vector2 pos, forc;
    AudioManager audM;
    private void Start()
    {
        audM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if(dentro)
        {
            rigPlayer.transform.position = Vector3.Lerp(rigPlayer.transform.position, pos, 5 * Time.deltaTime);
            if(disp)
            {
                StartCoroutine(Boom());
                disp = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            //Aqui pega o rigidbody da bola e tira a velocidade e desativa o simulated
            rigPlayer = col.GetComponent<Rigidbody2D>();
            rigPlayer.velocity = Vector3.zero;
            rigPlayer.simulated = false;
            dentro = true;
            disp = true;
            audM.auAlien.Play();
        }
    }
    IEnumerator Boom()
    {
        //Após passar o tempo que está no parenteses ele ativa o simulated do player
        //desativa o collider para nao bugar e dispara a bola
        yield return new WaitForSeconds(1);
        audM.auTiro.Play();
        gameObject.GetComponent<Collider2D>().enabled = false;
        rigPlayer.simulated = true;
        rigPlayer.AddForce(forc, ForceMode2D.Impulse);
        dentro = false;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
