using System.Collections;

using System.Collections.Generic;

using JetBrains.Annotations;

using UnityEngine;



public class BossMove : MonoBehaviour

{

   private float UpMax = 1;
   private float DownMax = -3;
   private float currentPosstion;
    private float direction = 1.0f;
    public float  Speed = 2.0f;
    void Start()

    {
        currentPosstion = transform.position.x; //현재 x포지션 입력
    }



    void Update()

    {

        currentPosstion += Time.deltaTime * direction * Speed; // 현재을 포지션을 속도에 따라 변화시킴

        if (currentPosstion >=UpMax)
        {
            currentPosstion = UpMax; //UpMax까지 Posstion이 올라왔다면 Down Turn으로 감

            DownTurn();
        }



        else if (currentPosstion <= DownMax)  // Posstion이 DownMax 까지 왔다면 Up Turn으로감

        {
            UpTurn();
        }
        transform.position = new Vector2(8, currentPosstion);

    }
    private void DownTurn()

    {
        direction = -1f; //방향 전
    }



    private void UpTurn()

    {
        direction = 1f; //방향 전환
    }

}