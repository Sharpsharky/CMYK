using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndLife());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-2, -1, 0) * Time.deltaTime * speed);
    }

    IEnumerator EndLife()
    {

        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
        yield return null;
    }
}
