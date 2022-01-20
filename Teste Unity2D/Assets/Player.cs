using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        transform.position += (Random.value >= 0.5f) ? (new Vector3(1f, 0)) : (new Vector3(-1f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Empurrao(10, 5);
    }
    void Empurrao(float x, float y)
    {
        rig.AddForce(new Vector2(x,y), ForceMode2D.Impulse);
    }

}
