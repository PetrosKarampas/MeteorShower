using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private Renderer renderer;
    private SphereCollider collider;
    private GameManager gameManager;
    private AudioSource audio;
    public GameObject planetShattered;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        renderer    = GetComponent<Renderer>();
        collider    = GetComponent<SphereCollider>();
        audio       = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            ExplodePlanet();
            UpdateScore();
            audio.Play();
            Destroy(gameObject, audio.clip.length);
        }
    }

    void ExplodePlanet() {
        var shatter      = Instantiate(planetShattered, transform.position, transform.rotation);
        renderer.enabled = false;
        collider.enabled = false;
        Destroy(shatter, 5);
    }

    void UpdateScore()
    {
        gameManager.UpdateScore(5);
    }

}
