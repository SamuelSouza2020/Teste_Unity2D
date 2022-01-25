using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text txtPontos;
    GameManager gameM;
    GameObject cvMenu;
    Button btPlay;
    void Start()
    {
        Time.timeScale = 0;
        txtPontos = GameObject.Find("txtPontos").GetComponent<Text>();
        gameM = GameObject.Find("Gerenc").GetComponent<GameManager>();
        cvMenu = GameObject.Find("CanvasMenu");
        btPlay = GameObject.Find("btPlay").GetComponent<Button>();
        btPlay.onClick.AddListener(IniciarGame);
    }
    void Update()
    {
        txtPontos.text = gameM.pontosPlayer.ToString();
    }
    void IniciarGame()
    {
        cvMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
