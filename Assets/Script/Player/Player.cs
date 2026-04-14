using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject GameOverUI;
    private Rigidbody2D rb;
    public float jumpForce = 5f; // jumpForce = 점프 세기를 조절하기 위한 이름
    private bool isDead; // isDead = 이미 죽었는지 막기 위한 이름

    public GameObject BulletPrefab;
    public float BulletSpeed = 30f;

    private float lifetime = 5f;
    private float spawnTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;

        Player_jump();
        BulletControl();
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


    void Player_jump() /// 점프 담당 함수
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void BulletControl() /// 총알 담당 함수
    {
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                Input.mousePosition.y, -Camera.main.transform.position.z)); //마우스 좌표

                GameObject Bullet = Instantiate(BulletPrefab,transform.position,transform.rotation);
                

                Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();

                Vector3 speed = (point - transform.position).normalized; // 총알 속도 normalized

                rb.AddForce(speed * BulletSpeed , ForceMode2D.Impulse);        
            }
        }     
    }
    
}