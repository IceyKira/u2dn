using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    public static Vector3 PlayerPosition;
    public static bool canJump = true;
    private Rigidbody2D rb;

    private float maxJumpForce = 10f;
    private float maxTouchTime = 5f;
    private float TouchStartTime;
    private float TouchDurationTime;

    public AudioSource music;
    public AudioClip jump;//添加跳跃音效
    public bool canPlay;

    private void Start(){
        PlayerPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        PlayerPosition = transform.position;
        if (Input.GetMouseButtonUp(0) && canJump && canPlay)
        {
            TouchDurationTime = Time.time - TouchStartTime;
            TouchDurationTime = TouchDurationTime > maxTouchTime ? maxTouchTime : TouchDurationTime;
            Jump();
            //把音源music的音效设置为jump
            music.clip = jump;
            //播放音效
            music.Play();
            canPlay = false;
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
            rb.velocity = new Vector2(rb.velocity.x, 0f); // ȷ��Y���ٶ�Ϊ0����ֹ������Ծ����
            rb.AddForce(direction * force, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; // ��غ�����ٴ���Ծ
            canPlay = true;
        }
    }
}

