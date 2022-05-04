using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Collectibles : MonoBehaviour
{
    //Got these examples from https://www.youtube.com/watch?v=Gs5QxGrRzNQ
    int coins = 0;

    [SerializeField] float speedX;
    [SerializeField] float speedY;
    [SerializeField] float speedZ;

    //Shoes text of the score
    [SerializeField] Text scoreText;
    //Plays sound of the coin being collected
    [SerializeField] AudioSource collectionSound;

    // When the player touches the collectibles it will disappear
    // Got this from a Youtube video https://www.youtube.com/watch?v=YQEq6Lkd69c
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            Debug.Log("Coins" + coins);
            scoreText.text = ("Score" + coins);
            collectionSound.Play();
        }
    }

    private void Update()
    {
        //Rotates the coin
        transform.Rotate(360 * speedX * Time.deltaTime, 360 * speedY * Time.deltaTime, 360 * speedZ * Time.deltaTime);
    }

}
