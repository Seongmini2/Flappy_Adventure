using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
    public GameObject gameFinishUI;
    private Rigidbody2D rb;
    public float jumpForce = 5f;
    public bool isDead;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;
        Player_jump();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            isDead = true;
            GameManager.instance.GameOver(); // GameManager한테 넘기기
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finishpipe"))
        {
            StartCoroutine(DelayTime());
        }
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(1.0f);
        gameFinishUI.SetActive(true);
    }

    void Player_jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}