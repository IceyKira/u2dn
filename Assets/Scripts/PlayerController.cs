using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    public static Vector3 PlayerPosition = new Vector3(0, -2.82f, 0);
    private Rigidbody2D rb;
    private bool canJump = true;

    private float maxJumpForce = 10f;
    private float maxTouchTime = 5f;
    private float TouchStartTime;
    private float TouchDurationTime;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        PlayerPosition = transform.position;
        if (Input.GetMouseButtonUp(0) && canJump)
        {
            TouchDurationTime = Time.time - TouchStartTime;
            TouchDurationTime = TouchDurationTime > maxTouchTime ? maxTouchTime : TouchDurationTime;
            Jump();
        }

        if (Input.GetMouseButtonDown(0) && canJump) {
            TouchStartTime = Time.time;
        }
    }

    private void Jump(){

        if (rb != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = new Vector2(transform.position.x - mousePosition.x, transform.position.y - mousePosition.y);
            float force = maxJumpForce * TouchDurationTime / maxTouchTime;
            rb.velocity = new Vector2(rb.velocity.x, 0f); // 确保Y轴速度为0，防止连续跳跃叠加
            rb.AddForce(direction * force, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; // 落地后可以再次跳跃
        }
    }
}

