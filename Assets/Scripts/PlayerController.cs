using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;
    public float speed;
    public Vector3 startingPoint;
    private Rigidbody rb;
    public float bounds;

    private void FixedUpdate()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection = camera.transform.TransformDirection(movementDirection);
        movementDirection.y = 0;

        rb.AddForce(movementDirection * speed * Time.deltaTime, ForceMode.VelocityChange);

        if (transform.position.y < startingPoint.y - bounds)
        {
            transform.position = startingPoint;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

}
