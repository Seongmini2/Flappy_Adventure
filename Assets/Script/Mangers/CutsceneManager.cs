using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public Sprite[] cutsceneImages;
    public Image displayImage;
    public AudioClip[] cutsceneSounds; // 컷씬별 효과음 배열
    private AudioSource audioSource;
    private int currentIndex = 0;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        displayImage.sprite = cutsceneImages[0];

        // 첫 컷씬 효과음 재생
        PlaySound(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentIndex++;

            if (currentIndex >= cutsceneImages.Length)
            {
                SceneManager.LoadScene("Stage1");
            }
            else
            {
                displayImage.sprite = cutsceneImages[currentIndex];
                PlaySound(currentIndex);
            }
        }
    }

    void PlaySound(int index)
    {
        // 해당 인덱스 효과음 없으면 그냥 넘어감
        if (cutsceneSounds.Length > index && cutsceneSounds[index] != null)
        {
            audioSource.PlayOneShot(cutsceneSounds[index]);
        }
    }
}