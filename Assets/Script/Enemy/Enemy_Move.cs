using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    [Header("상하 이동 (Y축)")]
    public float UpMax = 5f; 
    public float DownMax = -5f;
    public float verticalSpeed = 2.0f;
    private float verticalDirection = 1.0f;
    private float currentY; // Y축 위치만 저장

    [Header("왼쪽 이동 (X축)")]
    public float scrollSpeed = 2.0f;

    void Start()
    {
        // 시작할 때의 현재 Y 위치를 기준으로 잡습니다.
        currentY = transform.position.y;
    }

    void Update()
    {
        // 1. 왼쪽으로 계속 이동 (X축 계산)
        // 현재 내 X위치에서 scrollSpeed만큼 왼쪽으로 뺍니다.
        float nextX = transform.position.x - (scrollSpeed * Time.deltaTime);

        // 2. 위아래로 왔다갔다 (Y축 계산)
        currentY += Time.deltaTime * verticalDirection * verticalSpeed;

        if (currentY >= UpMax) 
        {
            currentY = UpMax;
            verticalDirection = -1f; // 아래로 턴
        }
        else if (currentY <= DownMax)
        {
            currentY = DownMax;
            verticalDirection = 1f;  // 위로 턴
        }

        // 3. 최종 적용: 계산된 X와 계산된 Y를 합쳐서 위치 변경
        transform.position = new Vector2(nextX, currentY);
    }
}
