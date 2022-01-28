using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtivBar : MonoBehaviour
{
    /// <summary>
    /// Script para ativar parede e mudar cor do "Botão" central
    /// </summary>
    GameObject btAtivo, bar1, bar2;
    Text pontos;
    bool passou = false;
    void Start()
    {
        pontos = GameObject.Find("txtPontos").GetComponent<Text>();
        //GetChild busca o filho do GameObjeto
        btAtivo = transform.GetChild(0).gameObject;
        bar1 = transform.GetChild(1).gameObject;
        bar2 = transform.GetChild(2).gameObject;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            passou = !passou;
            if (passou)
            {
                btAtivo.GetComponent<SpriteRenderer>().color = Color.red;
                pontos.color = Color.red;
                bar1.SetActive(true);
                bar2.SetActive(true);
            }
            else
            {
                btAtivo.GetComponent<SpriteRenderer>().color = Color.white;
                pontos.color = Color.white;
                bar1.SetActive(false);
                bar2.SetActive(false);
            }
        }
    }
}
