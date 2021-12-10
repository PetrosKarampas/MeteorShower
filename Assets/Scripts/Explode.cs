using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public Renderer rend;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Meteor"))
        {
            gameManager.UpdateScore(5);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            rend.enabled = false;
            Destroy(gameObject, audio.clip.length);
        }

        //Destroy(obj);
    }

}
