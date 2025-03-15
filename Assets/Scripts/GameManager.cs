using UnityEngine;

public class GameManager : MonoBehaviour
{
    float timeInterval = 2f;
    float eslapedTime = 0;
    ObjectPooling pooling;
    public Transform enemySpawnPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pooling = FindAnyObjectByType<ObjectPooling>();
    }

    // Update is called once per frame
    void Update()
    {
        eslapedTime += Time.deltaTime;
        if (eslapedTime >= timeInterval) {
            eslapedTime = 0;
            GameObject enemy = pooling.GetGameObject();
            if (enemy != null)
            {
                enemy.SetActive(true);
                enemy.transform.position = new Vector2(Random.Range(-2.7f, 2.7f), enemySpawnPosition.position.y);
            }
        }
    }
}
