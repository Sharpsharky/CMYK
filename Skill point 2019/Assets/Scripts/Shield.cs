using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {

        if(col.tag == "Attack P1" || col.tag == "Attack P2")
        {
            col.gameObject.SetActive(false);
        }


    }
}
