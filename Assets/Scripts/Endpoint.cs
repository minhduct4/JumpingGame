using UnityEngine;
using UnityEngine.SceneManagement;

public class Endpoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("SceneManager.sceneCount: " + SceneManager.sceneCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int sceneToLoad = SceneManager.GetActiveScene().buildIndex == 1 ? 0 : 
            SceneManager.GetActiveScene().buildIndex + 1;
        if (collision.tag=="Player")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
