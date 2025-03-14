using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float moveSpeed = 5f;
    bool moveToRight = true;
    Animator animator;
    public LayerMask layerMask;
    public LayerMask playerLayerMask;
    private bool isAttacking = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMove();
        HandleAttack();
    }
    void HandleMove()
    {
        
        float moveDirection = moveToRight ? 1 : -1;
        Vector2 raycastDirection = moveToRight ? Vector2.right : Vector2.left;
        rigidbody.linearVelocity = new Vector2(moveSpeed * moveDirection, rigidbody.linearVelocity.y);
        animator.SetBool("isRun", true);
        if (moveDirection > 0) transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        else if (moveDirection < 0) transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, raycastDirection, 1f, layerMask);
        if (hit)
        {
            moveToRight = !moveToRight;
        }
    }
    private void HandleAttack()
    { 
            Vector2 raycastDirection = moveToRight ? Vector2.right : Vector2.left;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, raycastDirection, 1f, playerLayerMask);
            if (hit && !isAttacking)
            {
                Debug.Log("Chém");
                animator.SetTrigger("attack");
                isAttacking = true;
                StartCoroutine(Attacking(2));
            } 
    }

    public void OnAttackComplete()
    {
        Debug.Log("Kết thúc Chém");
        isAttacking = false;
    }
    IEnumerator Attacking(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        // trigger the stop animation events here
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector2.right * 1f);
    }
}
