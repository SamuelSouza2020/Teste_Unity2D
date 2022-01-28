using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Script que gerencia o controle, som, algumas colisões,
    /// física e a morte da bola.
    /// </summary>
    Rigidbody2D rig;
    AudioManager audM;
    GameManager gameManager;
    //Aqui é colocado um Prefab que aparecerá após a morte da bola.
    [SerializeField]
    GameObject dead;

    //Cada vez que a bola estiver no ponto inicial, precisa esperar 1 segundo para lançar a bola novamente
    public bool libSpace = false;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        //Através dos GameObjetos são encontrados os scripts
        audM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        gameManager = GameObject.Find("Gerenc").GetComponent<GameManager>();
        libSpace = false;
    }
    void Update()
    {
        /*
         * A bola pode ser lançada com a tecla Espaço ou Seta para Cima, somente quando
         * a boolean "libSpace" for verdareira. Ela fica verdareira depois de 1 segundo que
         * a bola estiver na posição inicial.
         */
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && libSpace)
        {
            audM.spinball.Play();
            Empurrao(0, 20);
            libSpace = false;
        }
    }
    void Empurrao(float x, float y)
    {
        //Metodo utilizado para impulsionar a bola no inicio
        rig.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Untagged"))
        {
            //Toca um audio através do script AudioManager
            audM.auBtd.Play();
        }
        if (collision.gameObject.CompareTag("Csom"))
        {
            /*
             * Aqui acrescenta 2 pontos para o jogador cada vez que
             * encostar em um GameObjeto com essa Tag "Csom"
            */
            gameManager.pontosPlayer += 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Csom"))
        {
            gameManager.pontosPlayer += 2;
        }
        /*
         * Collider Is Trigger com Tag Speed dar mais velocidade
         * e 1 ponto a mais para o jogador.
         */
        if (collision.gameObject.CompareTag("speed"))
        {
            gameManager.pontosPlayer++;
            audM.auSpe.Play();
        }
        if (collision.gameObject.CompareTag("SaidaBall"))
        {
            audM.audPas.Play();
        }
        if (collision.gameObject.CompareTag("Dead"))
        {
            //Aqui é Destruida a bola e chamado o Prefab "Dead"
            Instantiate(dead, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gameManager.mort = true;
        }
    }
}
