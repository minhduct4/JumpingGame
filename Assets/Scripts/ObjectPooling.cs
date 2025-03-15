using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject enemy;
    private Queue<GameObject> pool = new Queue<GameObject>();
    private int poolSize = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(enemy);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
        
    }

    public GameObject GetGameObject()
    {
        if (pool.Count == 0) return null;
        return pool.Dequeue();
    }

    public void PutGameObjectToPool(GameObject obj)
    {
        pool.Enqueue(obj);
        obj.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
