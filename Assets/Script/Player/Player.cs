using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject GameOverUI;
    private Rigidbody2D rb;
    public float jumpForce = 5f; // jumpForce = 점프 세기를 조절하기 위한 이름
    private bool isDead; // isDead = 이미 죽었는지 막기 위한 이름

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    void GameOver()
    {
        isDead = true;
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
    }
}