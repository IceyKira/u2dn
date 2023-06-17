using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
   void Update()
    {
        OnMouseDrag();
    }

    private void OnMouseDrag()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z);
        transform.position = Camera.main.ScreenToWorldPoint(MousePos);
    }
}
