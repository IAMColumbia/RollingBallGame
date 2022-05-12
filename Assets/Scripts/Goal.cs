using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //AudioSource winSoundAudioSource;
    private void Start()
    {
        //winSoundAudioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
            //winSoundAudioSource.Play();
            Debug.Log("Goal hit!");
        }
    }
}
