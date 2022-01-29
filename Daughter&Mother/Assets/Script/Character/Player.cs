using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    [SerializeField] float speed;
    float moveX;
    Rigidbody2D rb;

    void Start() 
        {
            rb = GetComponent<Rigidbody2D>();
        }

    void Update() 
    {
        moveX = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(moveX, rb.velocity.y);
    }
}
