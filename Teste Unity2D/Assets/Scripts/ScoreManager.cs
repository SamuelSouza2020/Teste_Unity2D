using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// Script usado para salvar a pontua��o do jogador
    /// PlayerPrefs, quando o jogo for finalizado e aberto
    /// novamente a pontua��o continuar� l�.
    /// </summary>
    public int score;
    GameManager gm;
    void Start()
    {
        //Esse comando abaixo � usado para apagar tudo salva, pode ser colocado em um bot�o ou etc.
        //PlayerPrefs.DeleteAll();
        gm = GameObject.Find("Gerenc").GetComponent<GameManager>();
        GameStartScore();
    }
    void Update()
    {
        /*
         * Aqui atualiza sem parar o seu recorde.
         * Caso o record n�o fique ativo o tempo inteiro,
         * n�o � necess�rio esse comando.
         */
        UpdateScore();
    }
    public void GameStartScore()
    {
        //Haskey verifica se a chave existe.
        if(PlayerPrefs.HasKey("YourScore"))
        {
            score = PlayerPrefs.GetInt("YourScore");
        }
        //caso n�o exista ela cria uma nova.
        else
        {
            score = 0;
            PlayerPrefs.SetInt("YourScore", score);
        }
    }
    public void UpdateScore()
    {
        score = PlayerPrefs.GetInt("YourScore");
    }
    public void SalvarScore()
    {
        //Se a pontua��o do jogador for maior que o record, ele salva
        if(gm.pontosPlayer > score)
        {
            score = gm.pontosPlayer;
        }
        PlayerPrefs.SetInt("YourScore", score);
    }
}
