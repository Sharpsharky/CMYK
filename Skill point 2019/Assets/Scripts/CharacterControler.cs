using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public bool isPlayer1;
    public float velocity = 1f;
    float horizontal;
    float vertical;
    Rigidbody2D rb;
    float externalVelocity = 1f; //velocity changed by some external event

    public float ExternalVelocity { get => externalVelocity; set => externalVelocity = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1 == true)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if (Input.GetButtonDown("f"))
            {

            }
            if (Input.GetButtonDown("g"))
            {

            }
            if (Input.GetButtonDown("h"))
            {

            }


        }
        else
        {
            horizontal = Input.GetAxisRaw("Horizontal2");
            vertical = Input.GetAxisRaw("Vertical2");
            if (Input.GetButtonDown("p"))
            {

            }
            if (Input.GetButtonDown("o"))
            {

            }
            if (Input.GetButtonDown("i"))
            {

            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * velocity, vertical * velocity);
    }
}
