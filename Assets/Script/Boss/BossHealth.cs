using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHp = 3;
    private int currentHp;
    public Slider hpSlider;

    void Start()
    {
        currentHp = maxHp;
        hpSlider.maxValue = maxHp;
        hpSlider.value = maxHp;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            currentHp--;
            Destroy(other.gameObject);
            hpSlider.value = currentHp;

            if (currentHp <= 0)
            {
                hpSlider.gameObject.SetActive(false);
                StartCoroutine(GameClearDelay()); // 2초 후 클리어
            }
        }
    }

    IEnumerator GameClearDelay()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);           // 2초 기다린 후에 보스 삭제
        GameManager.instance.GameClear();
    }
}