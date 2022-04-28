using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;
    public float speed;
    public Vector3 startingPoint;

    private void FixedUpdate()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection = camera.transform.TransformDirection(movementDirection);

        GetComponent<Rigidbody>().AddForce(movementDirection * speed * Time.deltaTime, ForceMode.VelocityChange);

        if (transform.position.y < -15)
        {
            transform.position = startingPoint;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Spin the object around the target at 20 degrees/second.
        //transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        //how do i read input

        //transform.Rotate

        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        //movementDirection.Normalize();

        //transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);   


    }

}
