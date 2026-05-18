using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    float speed = 3;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update 메서드 내부의 구형 Input 로직 삭제
    void Update()
    {
        // 불필요한 Input.GetAxisRaw() 제거
    }

    private void FixedUpdate()
    {
        Vector2 nextVec2 = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec2);
    }

    // 새로운 Input System을 통한 입력 처리 (정상 작동)
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            sprite.flipX = inputVec.x < 0;
        }
    }
}