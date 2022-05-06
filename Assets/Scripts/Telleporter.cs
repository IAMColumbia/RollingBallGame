using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telleporter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform exit;
    [SerializeField] float delay;
    [SerializeField] ParticleSystem teleportParticles;

    WaitForSeconds teleportTime;

    private void Start()
    {
        teleportTime = new WaitForSeconds(delay);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        StartCoroutine(TeleportAfterDelay(collision.gameObject));
    }

    IEnumerator TeleportAfterDelay(GameObject target)
    {
        teleportParticles.Play();
        yield return teleportTime;
        target.transform.position = exit.position;
    }

}
