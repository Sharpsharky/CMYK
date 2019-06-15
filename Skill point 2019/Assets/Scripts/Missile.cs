using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    float speed = 400f;
    int direction = 1;
    Rigidbody2D rb;

    public int Direction { get => direction; set => direction = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MissileLife());
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * Time.deltaTime * direction, 0);
    }

    IEnumerator MissileLife()
    {

        yield return new WaitForSeconds(4);
        Destroy(gameObject);
            yield return null;
    }
}
