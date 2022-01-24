using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text txtPontos;
    GameManager gameM;
    void Start()
    {
        txtPontos = GameObject.Find("txtPontos").GetComponent<Text>();
        gameM = GameObject.Find("Gerenc").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        txtPontos.text = gameM.pontosPlayer.ToString();
    }
}
