using UnityEngine;

public class Cloud : MonoBehaviour
{
    public Camera mainCamera;
    float leftPositon;
    float rightPositon;
    public float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftPositon = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightPositon = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        Debug.Log("left: " + leftPositon + " right: " + rightPositon);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        if (transform.position.x <= leftPositon) { 
            
            transform.position = new Vector3(rightPositon, transform.position.y, transform.position.z);
        }
    }

    void OnDrawGizmosSelected()
    { 
        Vector3 p = mainCamera.WorldToViewportPoint(new Vector3(0,0,0));
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(p, 1F); 
        Debug.Log(p);
    }

}
