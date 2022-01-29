using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacasSon : MonoBehaviour
{
    //Script nos objetos filhos do GameObjeto "base"
    //Usado para mudar a cor quando a bola encostar.

    AtivPlacas atP;
    AudioManager audM;
    void Start()
    {
        //Está variável está ligada ao script do GameObjeto pai "base".
        atP = transform.GetComponentInParent<AtivPlacas>();
        audM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    void Update()
    {
        //Quando o int for igual a 0, volta para cor vermelha e o collider é ativado
        if(atP.asCores == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Quando o player encostar, a cor fica branca, collider é desativado e acrescenta 1 valor na variavel int da 'base'
            //"base" = GameObjeto pai
            audM.auButRed.Play();
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            gameObject.GetComponent<Collider2D>().enabled = false;
            atP.asCores++;
        }
    }
}
