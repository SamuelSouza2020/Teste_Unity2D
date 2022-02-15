using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// Script usado para salvar a pontuação do jogador
    /// PlayerPrefs, quando o jogo for finalizado e aberto
    /// novamente a pontuação continuará lá.
    /// </summary>
    public int score;
    GameManager gm;
    [SerializeField]
    //Text txtRecord;
    void Start()
    {
        //Esse comando abaixo é usado para apagar tudo salva, pode ser colocado em um botão ou etc.
        //PlayerPrefs.DeleteAll();
        gm = GameObject.Find("Gerenc").GetComponent<GameManager>();
        //txtRecord = GameObject.Find("BestRecord").GetComponent<Text>();
        GameStartScore();
    }
    void Update()
    {
        /*
         * Aqui atualiza sem parar o seu recorde.
         * Caso o record não fique ativo o tempo inteiro,
         * não é necessário esse comando.
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
        //caso não exista ela cria uma nova.
        else
        {
            score = 0;
            PlayerPrefs.SetInt("YourScore", score);
        }
        //txtRecord.text = score.ToString();
    }
    public void UpdateScore()
    {
        score = PlayerPrefs.GetInt("YourScore");
    }
    public void SalvarScore()
    {
        //Se a pontuação do jogador for maior que o record, ele salva
        if(gm.pontosPlayer > score)
        {
            score = gm.pontosPlayer;
        }
       // txtRecord.text = score.ToString();
        PlayerPrefs.SetInt("YourScore", score);
    }
}
