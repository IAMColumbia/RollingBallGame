using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;
    // Maximum angle to tilt the camera to fake the level tilting
    public float boardTiltMax = 15f; 
    private Vector3 desiredPosition;
    private GameObject desiredPositionObject;

    private float rotationDamping = 10f;
    private float movementDamping = 150f;
    private float turnSpeed = 300f;

    private float turnAngle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //initialization
        //offset = transform.position;
        desiredPosition = transform.position;
        desiredPositionObject = new GameObject("cameraFollow");
        DontDestroyOnLoad(desiredPositionObject);
        desiredPositionObject.transform.position = transform.position;

        // find the player object
        player = GameObject.Find("Player");

        if (player == null)
        {

            Debug.LogError("Could not find object \"Player\" !");
            DestroyImmediate(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the camera around the ball to adjust left/right movement 
        turnAngle += Input.GetAxis("Turn") * turnSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        // find the ZX direction from the player to the camera
        var heading = transform.position - player.transform.position;
        heading.y = 0f;
        var distance = heading.magnitude;
        var direction = heading / distance;

        // Find the right vector for the direction
        var rotationVectorRight = Vector3.Cross(direction, Vector3.up);

        // Move the camera
        desiredPositionObject.transform.position = player.transform.position + offset;

        // Rotate around the players Y axis by the turn value
        desiredPositionObject.transform.RotateAround(player.transform.position, Vector3.up, turnAngle);

        // Forward/backward board rotation
        desiredPositionObject.transform.RotateAround(player.transform.position, rotationVectorRight, -Input.GetAxisRaw("Vertical") * boardTiltMax);

        // Ensure we're looking at the player before the roll rotation is applied
        desiredPositionObject.transform.LookAt(player.transform.position);

        // Apply the roll rotation
        desiredPositionObject.transform.RotateAround(desiredPositionObject.transform.position, direction, -Input.GetAxisRaw("Horizontal") * boardTiltMax);

        // Cameras position to match the target object
        transform.position = Vector3.Slerp(transform.position, desiredPositionObject.transform.position, Time.deltaTime * movementDamping);

        // Cameras rotation to match the target object
        transform.rotation = Quaternion.Lerp(transform.rotation,
                                              desiredPositionObject.transform.rotation,
                                              Time.deltaTime * rotationDamping);

        // Re-center the camera on the object to account for new roll rotation
        CenterCameraOnPlayer();

    }

    private void CenterCameraOnPlayer()
    {
        //add credit
        Plane plane = new Plane(transform.forward, player.transform.position);
        Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0.0f));
        float distance;
        plane.Raycast(ray, out distance);

        var point = ray.GetPoint(distance);
        var offset = player.transform.position - point;
        transform.position += offset;
    }
}
