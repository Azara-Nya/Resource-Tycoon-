using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

 [SerializeField] private float moveSpeed=5f;
 [SerializeField] private Rigidbody2D rb;
 Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
