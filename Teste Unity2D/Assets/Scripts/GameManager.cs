using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Este script é responsável por todo o jogo.
    /// Atraves dele que o jogo reinicia e
    /// coloca a pontuação do jogador
    /// </summary>
    public int pontosPlayer, lastPontos, contCaracteres = 0;
    public bool mort = false, gameIniciou = false, newPontos = true,
        verif = true, btComec = false, atLista = true;
    //ScoreManager sm;
    SalvarScore ss;

    UIManager ui;

    //singleton
    public static GameManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += Carrega;
    }
    //singleton

    void Carrega(Scene cena, LoadSceneMode mode)
    {
        ss = GameObject.Find("ScorePlayer").GetComponent<SalvarScore>();
        ui = GameObject.Find("UIManager").GetComponent<UIManager>();
        atLista = true;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && gameIniciou)
        {
            SceneManager.LoadScene(0);
        }
        if(mort)
        {
            StartCoroutine(Reiniciar());
            if(newPontos)
            {
                contCaracteres += ui.txtUser.text.Length + ui.txtPontos.text.Length;
                lastPontos = pontosPlayer;
                ss.saveScore();
                newPontos = false;
            }
        }
    }
    IEnumerator Reiniciar()
    {
        //sm.SalvarScore();
        yield return new WaitForSeconds(1);
        pontosPlayer = 0;
        SceneManager.LoadScene(0);
    }
}
