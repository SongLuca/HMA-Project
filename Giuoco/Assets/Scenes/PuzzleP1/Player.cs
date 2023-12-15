using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.5f;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float h = 0.0f;
        float v = 0.0f;

        if (Input.GetKey("w")) { v = 1.0f; }
        if (Input.GetKey("s")) { v = -1.0f; }
        if (Input.GetKey("a")) { h = -1.0f; }
        if (Input.GetKey("d")) { h = 1.0f; }

        rigidBody.AddForce(new Vector2(h, v) * speed);
    }
}
