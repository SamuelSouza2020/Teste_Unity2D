using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position += (Random.value >= 0.5f) ? (new Vector3(1f, 0)) : (new Vector3(-1f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
