using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Nesse script esta o maior controle do UI no jogo.
    /// Do simples tutorial do menu inicial até a
    /// exibição da pontuação atual do player.
    /// </summary>
    public Text txtPontos, txtUser, lastScore;
    GameManager gameM;
    [SerializeField]
    GameObject codScoreList, codSLClone;
    public GameObject cvMenu, listScore;
    Button btPlay, btWorld, btCloseL;
    InputField inputName;
    [SerializeField]
    SalvarScore salvaPontos;

    void Awake()
    {
        //Quando o jogo é iniciado o tempo é congelado (Time.timeScale)
        Time.timeScale = 0;
        txtPontos = GameObject.Find("txtPontos").GetComponent<Text>();
        gameM = GameObject.Find("Gerenc").GetComponent<GameManager>();
        cvMenu = GameObject.Find("CanvasMenu");
        btPlay = GameObject.Find("btPlay").GetComponent<Button>();
        btWorld = GameObject.Find("BtWorld").GetComponent<Button>();
        btCloseL = GameObject.Find("BtClose").GetComponent<Button>();
        inputName = GameObject.Find("InputName").GetComponent<InputField>();
        txtUser = GameObject.Find("txtUser").GetComponent<Text>();
        lastScore = GameObject.Find("lastScore").GetComponent<Text>();
        salvaPontos = GameObject.Find("ScorePlayer").GetComponent<SalvarScore>();
        listScore = GameObject.Find("ListScore");
        listScore.SetActive(false);
        //Função que adiciona comando ao botão "Ao clicar"
        //Chamando o void Mencionado nos parenteses.
        btPlay.onClick.AddListener(IniciarGame);
        btWorld.onClick.AddListener(ListaOp);
        btCloseL.onClick.AddListener(ListaCl);
    }
    void Update()
    {
        //Aqui atualiza em todo o tempo a pontuação do jogador
        txtPontos.text = gameM.pontosPlayer.ToString();
        if(cvMenu.activeSelf)
        {
            lastScore.text = gameM.lastPontos.ToString();
        }
    }
    void SalvaRapido()
    {
        salvaPontos.saveScore();
    }
    void IniciarGame()
    {
        cvMenu.SetActive(false);
        gameM.gameIniciou = true;
        Destroy(codSLClone);
        Time.timeScale = 1;
    }
    void ListaOp()
    {
        listScore.SetActive(true);
        if(!codSLClone)
        {
            Instantiate(codScoreList, transform.position, Quaternion.identity);
        }
        codSLClone = GameObject.Find("HighScore(Clone)");
    }
    void ListaCl()
    {
        listScore.SetActive(false);
    }
}
