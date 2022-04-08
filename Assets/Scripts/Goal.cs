using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).normal.x <-.5)
        {
            Debug.Log("Goal hit!");
        }
    }
}
