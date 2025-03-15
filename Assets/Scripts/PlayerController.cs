using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    public bool isOnGround = false;
    private float heath = 100f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        HandleMove();
        HandleJump();
        HandleAttack();
    }
    private void HandleAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("attack");
        }
    }
    private void HandleMove()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        rigidbody2D.linearVelocity = new Vector2(moveSpeed * moveDirection, rigidbody2D.linearVelocity.y);
       

        if(moveDirection > 0) transform.localScale = new Vector3(0.25f, 0.25f, 0.25f); 
        else if(moveDirection < 0) transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);

        animator.SetFloat("speed", Mathf.Abs(moveDirection));
    }
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        { 
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, jumpSpeed);
            isOnGround = false;
            animator.SetTrigger("jump");
            SoundManager.Instance.PlayAudio(SoundManager.Instance.jumpSound);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground") isOnGround = true;
    }

    public void TakeDamage(float damage)
    {
        heath -= damage;
        UIManager.Instance.SetHeathText(heath.ToString());
    }
}
