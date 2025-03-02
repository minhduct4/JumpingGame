using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float moveSpeed = 5f;
    float moveToRight = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMove();
    }
    void HandleMove()
    {
        rigidbody.linearVelocity = new Vector2(moveSpeed * moveToRight, rigidbody.linearVelocity.y);
    }
}
