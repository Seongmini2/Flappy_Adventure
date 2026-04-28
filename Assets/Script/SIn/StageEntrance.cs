using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageEntrance : MonoBehaviour
{
    public string sceneName;
    public GameObject promptUI; // "스페이스바를 눌러 시작!" 오브젝트
    private bool playerInside = false;

    void Start()
    {
        promptUI.SetActive(false); // 시작할 때 숨기기
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            promptUI.SetActive(true); // 문구 표시
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            promptUI.SetActive(false); // 문구 숨기기
        }
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}