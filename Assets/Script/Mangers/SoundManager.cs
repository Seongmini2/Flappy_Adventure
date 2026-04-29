using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource bgmSource;   // 배경음악
    public AudioSource sfxSource;   // 효과음

    public Slider bgmSlider;
    public Slider sfxSlider;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // 슬라이더 초기값 설정
        bgmSlider.value = bgmSource.volume;
        sfxSlider.value = sfxSource.volume;

        // 슬라이더 변경 시 함수 연결
        bgmSlider.onValueChanged.AddListener(SetBGM);
        sfxSlider.onValueChanged.AddListener(SetSFX);
    }

    public void SetBGM(float value)
    {
        bgmSource.volume = value;
    }

    public void SetSFX(float value)
    {
        sfxSource.volume = value;
    }
}
