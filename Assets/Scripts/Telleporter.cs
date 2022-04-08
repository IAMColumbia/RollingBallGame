using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telleporter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform exit;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = exit.position;
    }
}
