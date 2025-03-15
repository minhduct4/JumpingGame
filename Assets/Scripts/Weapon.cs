using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float damage = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        
    } 

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // gọi phương thức trừ máu của player
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
