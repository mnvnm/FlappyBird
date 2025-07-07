using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpForce = 3f;         // 점프 힘
    [SerializeField] float rotateSpeed = 2f;       // 회전 속도
    private Rigidbody2D rd;              // Rigidbody2D 컴포넌트 참조
    private Animator animator;           // Animator 컴포넌트 참조
    private bool isDeadRotating = false; // 죽었을 때 회전 애니메이션 여부
    void Start()
    {
    }

    public void Init()
    {
        if (rd == null) rd = GetComponent<Rigidbody2D>();
        if (animator == null) animator = GetComponent<Animator>();
        isDeadRotating = false;
        transform.position = new Vector3(-12f, 0, 0);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        rd.linearVelocity = Vector2.zero;
        animator.SetBool("Dead", false);
    }

    void Update()
    {
        if (!GameManager.Instance.IsGameBegin())
        {
            if (isDeadRotating)
            {
                // 죽었을 때 아래로 회전
                transform.rotation = Quaternion.Lerp(
                    transform.rotation,
                    Quaternion.Euler(0, 0, -90f),
                    Time.deltaTime * rotateSpeed
                );
            }
            return;
        }
        Jump();
    }
    void Jump()
    {
        // 마우스 클릭 시 점프
        if (Input.GetMouseButtonDown(0))
        {
            rd.linearVelocity = Vector2.up * jumpForce;
        }

        // 속도에 따라 새의 회전 각도 조정
        float vy = rd.linearVelocity.y;
        float targetAngle = vy > 0.1f ? 45f : (vy < -0.1f ? -45f : 0f);// 속도에 따라 회전 각도 결정
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0, 0, targetAngle),
            Time.deltaTime * rotateSpeed
        );
    }

    public void Dead()
    {
        isDeadRotating = true; // 회전 시작
        Debug.Log("Game Over");
        animator.SetBool("Dead", true); // 죽음 애니메이션 실행
        GameManager.Instance.EndGame();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.Instance.IsGameBegin()) return;

        // 땅이나 파이프에 부딪히면 게임 오버 처리
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pipe"))
        {
            Dead();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            ScoreManager.Instance.CurScore += 50;
            GameManager.Instance.hudUI.SetScoreText();
        }
    }
}
