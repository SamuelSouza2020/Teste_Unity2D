using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Nesse script esta o maior controle do UI no jogo.
    /// Do simples tutorial do menu inicial at� a
    /// exibi��o da pontua��o atual do player.
    /// </summary>
    public Text txtPontos;
    GameManager gameM;
    GameObject cvMenu;
    Button btPlay;
    void Start()
    {
        //Quando o jogo � iniciado o tempo � congelado (Time.timeScale)
        Time.timeScale = 0;
        txtPontos = GameObject.Find("txtPontos").GetComponent<Text>();
        gameM = GameObject.Find("Gerenc").GetComponent<GameManager>();
        cvMenu = GameObject.Find("CanvasMenu");
        btPlay = GameObject.Find("btPlay").GetComponent<Button>();
        //Fun��o que adiciona comando ao bot�o "Ao clicar"
        //Chamando o void Mencionado nos parenteses.
        btPlay.onClick.AddListener(IniciarGame);
    }
    void Update()
    {
        //Aqui atualiza em todo o tempo a pontua��o do jogador
        txtPontos.text = gameM.pontosPlayer.ToString();
    }
    void IniciarGame()
    {
        /*
         * Assim que o jogador inicia a partida o tempo volta 
         * ao normal e o menu � desativado.
         */
        cvMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
