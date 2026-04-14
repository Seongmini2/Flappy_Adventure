using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] private float moveSpeed = 5f; // 플레이어 이동 속도

    private Rigidbody2D rb;
    private Vector2 moveInput; // 현재 입력값 저장

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// 플레이어 입력 처리
    private void GetInput()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize(); // 대각선 이동 속도 보정
    }

    
    /// 플레이어 이동 적용
    private void Move()
    {
        rb.velocity = moveInput * moveSpeed;
    }
}