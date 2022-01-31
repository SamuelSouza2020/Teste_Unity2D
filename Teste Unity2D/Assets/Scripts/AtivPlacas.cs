using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivPlacas : MonoBehaviour
{
    /// <summary>
    /// Script Manager do GameObjeto que dar pontos extra.
    /// Caso o jogador acerte os 3 GameObjetos filho deste GameObjeto,
    /// é adicionado pontos extra para o jogador.
    /// </summary>

    public int asCores;
    float tempoCor = 0;
    GameManager gaM;
    private void Start()
    {
        gaM = GameObject.Find("Gerenc").GetComponent<GameManager>();
    }
    void Update()
    {
        if(asCores > 2)
        {
            /*
             * Após acertar os 3 GameObjetos filhos, espera 1
             * segundo para reiniciar a função do GameObjeto
             */
            tempoCor += Time.deltaTime;
            if(tempoCor > 1)
            {
                tempoCor = 0;
                asCores = 0;
                gaM.pontosPlayer += 750;
            }
        }
    }
}
