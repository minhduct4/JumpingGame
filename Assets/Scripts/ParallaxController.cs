using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    Vector3 StartLocation;
    public Camera camera;
    public float parallaxValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, StartLocation.y + parallaxValue * camera.transform.position.y, transform.position.z); ;
    }
}
