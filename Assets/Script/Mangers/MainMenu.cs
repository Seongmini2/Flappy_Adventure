using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneManager.LoadScene("Cutscene"); // 컷씬으로 이동
    }
}
