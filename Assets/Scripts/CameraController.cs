using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static Vector2 CameraPosition;
    private Vector2 offset = new Vector2(0, 2.82f);

    void Start()
    {
        
    }

   private void FixedUpdate()
    {
        // Debug.Log("PlayerPosition: " + PlayerController.PlayerPosition.y);
        transform.position = new Vector2(transform.position.x, PlayerController.PlayerPosition.y + offset.y);
        CameraPosition = transform.position;
    }
}
