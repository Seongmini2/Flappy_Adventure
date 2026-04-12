using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float scrollSpeed = 2f;

    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
    }
}
