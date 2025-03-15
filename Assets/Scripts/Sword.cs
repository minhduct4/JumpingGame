using UnityEngine;

public class Sword : Weapon
{ 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        damage = 20f;
    }
     
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Đã chém trúng player");
        }
    }
}
