using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivBar : MonoBehaviour
{
    [SerializeField]
    GameObject btAtivo, btDesat, bar1, bar2;
    bool passou = false;
    void Start()
    {
        //btAtivo = GameObject.Find("ButtonAtv");
        btAtivo = transform.GetChild(0).gameObject;
        btDesat = transform.GetChild(1).gameObject;
        bar1 = transform.GetChild(2).gameObject;
        bar2 = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.GetChild(0));
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            passou = !passou;
            if (passou)
            {
                btAtivo.SetActive(false);
                btDesat.SetActive(true);
                bar1.SetActive(true);
                bar2.SetActive(true);
            }
            else
            {
                btAtivo.SetActive(true);
                btDesat.SetActive(false);
                bar1.SetActive(false);
                bar2.SetActive(false);
            }
        }
    }
}
