using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class playerController : MonoBehaviour
{
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float horizontalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed, Space.World);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6f, 6f), transform.position.y, transform.position.z); //Mathf.Clamp(transform.position.x, min, max), this is for x pos but you can move this to z if the plane is facing a diff direction


    }
}
