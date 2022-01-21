using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField]
    GameObject lEsq, lDir;
    Rigidbody2D rigEsq, rigDir;
    float tqForce = 1000;

    void Start()
    {
        rigEsq = lEsq.GetComponent<Rigidbody2D>();
        rigDir = lDir.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            AddTorque(rigEsq, tqForce);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            AddTorque(rigDir, -tqForce);
        }

    }
    void AddTorque(Rigidbody2D rigid, float force)
    {
        rigid.AddTorque(force);
    }
}
