using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentGenerator : MonoBehaviour
{
    public GameObject platformPrefab; // ̨�׵�Ԥ����
    public GameObject Player;
    public int numberOfPlatforms = 2; // ��Ҫ���ɵ�̨������
    public Vector2 spawnAreaSize = new Vector2(1f, 3f); // ����̨�׵������С
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

        // ����ٶȵĴ�С������ֵ��
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
        //    platform.transform.parent = transform; // �����ɵ�̨������Ϊ��ǰ�ű������ӵĶ�����Ӷ���

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
            platform.transform.parent = transform; // �����ɵ�̨������Ϊ��ǰ�ű������ӵĶ�����Ӷ���
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(-spawnAreaSize.x, spawnAreaSize.x);
        float y = Random.Range(0, spawnAreaSize.y);
        return new Vector3(Player.transform.position.x + x, Player.transform.position.y + 5f + y, 5f);
    }
}

