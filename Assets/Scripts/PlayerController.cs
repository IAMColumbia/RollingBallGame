using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveForce;

    Rigidbody rb;

    bool moveRight;
    bool moveLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //The player gets to move when the Input is being pressed
        moveLeft = Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.D);
    }

    private void FixedUpdate()
    {
        if (moveLeft)
        {
            rb.AddForce(Vector3.left * moveForce, ForceMode.Impulse);
        }
        if (moveRight)
        {
            rb.AddForce(Vector3.right * moveForce, ForceMode.Impulse);
        }
    }


}
