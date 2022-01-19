using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField]
    GameObject lEsq, lDir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            lEsq.transform.eulerAngles += (lEsq.transform.eulerAngles.z <= 50 || lEsq.transform.eulerAngles.z > 340) ? (new Vector3(0, 0, 10)) : (new Vector3(0, 0, 0));
        }
        else
        {
            lEsq.transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0, 0), 0.05f * Time.deltaTime);
        }
        
    }
}
