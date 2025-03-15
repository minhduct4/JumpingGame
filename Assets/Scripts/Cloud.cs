using UnityEngine;

public class Cloud : MonoBehaviour
{
    public Camera mainCamera;
    float leftPositon;
    float rightPositon;
    float speed;
    float cloudWidth;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(1f, 3f);
        leftPositon = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightPositon = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        Debug.Log("left: " + leftPositon + " right: " + rightPositon);
        cloudWidth = GetComponent<Renderer>().bounds.size.x; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        if (transform.position.x <= leftPositon - cloudWidth/2) {  
            transform.position = new Vector3(rightPositon + cloudWidth/2, transform.position.y, transform.position.z);
            speed = Random.Range(1f, 3f);
        }
    }

    void OnDrawGizmosSelected()
    { 
        //Vector3 p = mainCamera.WorldToViewportPoint(new Vector3(0,0,0));
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(p, 1F); 
        //Debug.Log(p);
    }

}
