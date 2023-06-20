using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentGenerator : MonoBehaviour
{
    public GameObject platformPrefab; // 台阶的预制体
    public GameObject Player;
    public int numberOfPlatforms = 2; // 需要生成的台阶数量
    public Vector2 spawnAreaSize = new Vector2(1f, 3f); // 生成台阶的区域大小
    private Vector3 previousPosition;
    private Rigidbody2D rb;



    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
        previousPosition = Player.transform.position;
    }

    void Update()
    {
        Vector3 velocity = rb.velocity;

        // 检查速度的大小（标量值）
        float speed = velocity.magnitude;
        if (speed == 0  && (Player.transform.position.x > 0.01f || Player.transform.position.x < -0.01f))
        {
            Debug.Log("111");
            GeneratePlatforms();
        }
        previousPosition = Player.transform.position;
    }

    void GeneratePlatforms()
    {
        //for (int i = 0; i < numberOfPlatforms; i++)
        //  {
        //    Vector3 spawnPosition = GetRandomSpawnPosition();
        //    GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        //    platform.transform.parent = transform; // 将生成的台阶设置为当前脚本所附加的对象的子对象

        // }
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Collider2D[] colliders = Physics2D.OverlapBoxAll(spawnPosition, platformPrefab.transform.localScale, 0f);
        bool hasCollision = false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Ground"))
            {
                hasCollision = true;
                break;
            }
        }

        if (!hasCollision)
        {
            
            GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            platform.transform.parent = transform; // 将生成的台阶设置为当前脚本所附加的对象的子对象
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(-spawnAreaSize.x, spawnAreaSize.x);
        float y = Random.Range(0, spawnAreaSize.y);
        return new Vector3(Player.transform.position.x + x, Player.transform.position.y + 5f + y, 5f);
    }
}

