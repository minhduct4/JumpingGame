using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    ObjectPooling pooling;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pooling = FindAnyObjectByType<ObjectPooling>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
            pooling.PutGameObjectToPool(collision.gameObject);
        }
    }
}
