using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
    public GameObject GameOverUI;

    public GameObject GameFinish;   
    private Rigidbody2D rb;
    public float jumpForce = 5f; // jumpForce = 점프 세기를 조절하기 위한 이름
    public bool isDead; // isDead = 이미 죽었는지 막기 위한 이름

    public GameObject BulletPrefab;
    public float BulletSpeed = 30f;

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
        if (collision.gameObject.CompareTag("Finishpipe"))
        {
            GameClear(collision);
        }
        else { GameOver(); }
    }

    // 2. 그냥 통과했을 때 (isTrigger 켜짐)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finishpipe"))
        {
            // 굳이 GameClear(collision) 안 거치고 바로 실행해도 됩니다.
            StartCoroutine(DelayTime());
        }
    }
    
    void GameClear(Collision2D other)
    {
        StartCoroutine(DelayTime());
    }

    IEnumerator DelayTime() //UI를 1초후 키기 위한 코딩
        {
            yield return new WaitForSeconds(1.0f);
            GameFinish.SetActive(true);
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