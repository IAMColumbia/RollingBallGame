using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectStars : MonoBehaviour
{
    //Got these examples from https://www.youtube.com/watch?v=Gs5QxGrRzNQ
    int coins = 0;



    //Shows text of the score
    //[SerializeField] Text scoreText;
    public TMPro.TextMeshProUGUI scoreText;

    //Plays sound of the coin being collected
    AudioSource collectionSoundAudioSource;

    // When the player touches the collectibles it will disappear
    // Got this from a Youtube video https://www.youtube.com/watch?v=YQEq6Lkd69c
    private void Start()
    {
        collectionSoundAudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            Debug.Log("Coins" + coins);
            scoreText.text = ("Score: " + coins);
            collectionSoundAudioSource.Play();
        }
    }
}
