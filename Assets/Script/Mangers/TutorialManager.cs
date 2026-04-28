using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialImage; // 튜토리얼 이미지 오브젝트
    public GameObject BackImage; 

    void Start()
    {
        Time.timeScale = 0f;       
        tutorialImage.SetActive(true);
        BackImage.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;            // 게임 재개
            tutorialImage.SetActive(false); // 이미지 숨기기
            BackImage.SetActive(false);
            enabled = false;                // 이 스크립트 비활성화
        }
    }
}
