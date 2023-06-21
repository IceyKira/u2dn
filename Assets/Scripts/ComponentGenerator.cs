using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentGenerator : MonoBehaviour
{
    public GameObject platformPrefab; // ̨�׵�Ԥ����
    public Vector2 spawnAreaSize = new Vector2(1.5f, 3f); // ����̨�׵������С

    private float generateRange = 6; // �������������Ҫ����̨�׵ĸ߶ȷ�Χ ��ȡ����Ұ��С
    private float maxHeight;
    private float maxHighPlatform = -5; //�����ƽ̨��y����ֵ
    
    void Start(){
        maxHeight = PlayerController.PlayerPosition.y;
    }

    void FixedUpdate(){ 
        // Debug.Log("PlayerPosition: " + PlayerController.PlayerPosition.y);
        
        maxHeight = maxHeight > PlayerController.PlayerPosition.y ? maxHeight : PlayerController.PlayerPosition.y;
        
        while(maxHeight + generateRange > maxHighPlatform){
            GeneratePlatforms();
        }
    }

    void GeneratePlatforms()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        maxHighPlatform = spawnPosition.y;
        Debug.Log("spawnPosition: " + spawnPosition.x + " " + spawnPosition.y);
        // Collider2D[] colliders = Physics2D.OverlapBoxAll(spawnPosition, platformPrefab.transform.localScale, 0f);
        // bool hasCollision = false;
        // foreach (Collider2D collider in colliders)
        // {
        //     if (collider.CompareTag("Ground"))
        //     {
        //         hasCollision = true;
        //         break;
        //     }
        // }

        // if (!hasCollision)
        // {
            
        //     GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        //     platform.transform.parent = transform; // �����ɵ�̨������Ϊ��ǰ�ű������ӵĶ�����Ӷ���
        // }
        GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        platform.transform.parent = transform; // �����ɵ�̨������Ϊ��ǰ�ű������ӵĶ�����Ӷ���
    }

    Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(-2f, 2f);
        float y = Random.Range(4f, 7f);
        Debug.Log("x: " + x + " y: " + y);
        return new Vector3( x, maxHighPlatform + y, 5f);
    }
}

