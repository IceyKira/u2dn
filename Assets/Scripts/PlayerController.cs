using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    private bool canJump = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // 确保Y轴速度为0，防止连续跳跃叠加
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; // 落地后可以再次跳跃
        }
    }
}

