using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

 [SerializeField] private Rigidbody2D rb;
 [SerializeField] private float moveSpeed=5f;
 public float ResourceSpeed;
 public string currentResourceInRange;
 Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
