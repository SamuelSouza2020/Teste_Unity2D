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
    public int pontosPlayer;
    public bool mort = false;
    ScoreManager sm;
    private void Start()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if(mort)
        {
            StartCoroutine(Reiniciar());
        }
    }
    IEnumerator Reiniciar()
    {
        sm.SalvarScore();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
