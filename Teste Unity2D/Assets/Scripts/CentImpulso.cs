using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentImpulso : MonoBehaviour
{
    Rigidbody2D rigPlayer;
    bool dentro = false, disp = false;
    private void Update()
    {
        if (dentro)
        {
            rigPlayer.transform.position = Vector3.Lerp(rigPlayer.transform.position, new Vector3(-1.977f, 4.026f, 0), 5 * Time.deltaTime);
            if (disp)
            {
                StartCoroutine(Boom());
                disp = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            rigPlayer = col.GetComponent<Rigidbody2D>();
            rigPlayer.velocity = Vector3.zero;
            rigPlayer.simulated = false;
            dentro = true;
            disp = true;
            //col.transform.position = Vector3.Lerp(col.transform.position, new Vector3(-2.203f, 1.055f, 0), Time.deltaTime);
        }
    }
    IEnumerator Boom()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Collider2D>().enabled = false;
        rigPlayer.simulated = true;
        rigPlayer.AddForce(new Vector2(10, Random.Range(-15, 15) ), ForceMode2D.Impulse);
        dentro = false;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
