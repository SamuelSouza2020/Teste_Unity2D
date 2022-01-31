using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Script que gerencia o controle, som, algumas colis�es,
    /// f�sica e a morte da bola.
    /// </summary>
    Rigidbody2D rig;
    AudioManager audM;
    GameManager gameManager;
    //Aqui � colocado um Prefab que aparecer� ap�s a morte da bola.
    [SerializeField]
    GameObject dead;
    //Cada vez que a bola estiver no ponto inicial, precisa esperar 1 segundo para lan�ar a bola novamente
    public bool libSpace = false;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        //Atrav�s dos GameObjetos s�o encontrados os scripts
        audM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        gameManager = GameObject.Find("Gerenc").GetComponent<GameManager>();
        libSpace = false;
    }
    void Update()
    {
        /*
         * A bola pode ser lan�ada com a tecla Espa�o ou Seta para Cima, somente quando
         * a boolean "libSpace" for verdareira. Ela fica verdareira depois de 1 segundo que
         * a bola estiver na posi��o inicial.
         */
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && libSpace)
        {
            audM.spinball.Play();
            Empurrao(0, 20);
            libSpace = false;
        }
        //Limitador de velocidade teste
        if(rig.velocity.magnitude > 20)
        {
            rig.velocity -= (rig.velocity / 2);
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
            //Verifica a velocidade da bola para tocar o efeito sonoro
            if(rig.velocity.magnitude > 1.5f)
            {
                audM.auBtd.Play();
            }
        }
        if (collision.gameObject.CompareTag("Csom"))
        {
            /*
             * Aqui acrescenta 2 pontos para o jogador cada vez que
             * encostar em um GameObjeto com essa Tag "Csom"
            */
            gameManager.pontosPlayer += 33;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Csom"))
        {
            gameManager.pontosPlayer += 33;
        }
        /*
         * Collider Is Trigger com Tag Speed dar mais velocidade
         * e 1 ponto a mais para o jogador.
         */
        if (collision.gameObject.CompareTag("BtAtivos"))
        {
            gameManager.pontosPlayer+= 13;
        }
        if (collision.gameObject.CompareTag("SaidaBall"))
        {
            audM.audPas.Play();
        }
        if (collision.gameObject.CompareTag("Dead"))
        {
            //Aqui � Destruida a bola e chamado o Prefab "Dead"
            Instantiate(dead, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gameManager.mort = true;
        }
    }
}
