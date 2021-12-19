using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private Renderer renderer;
    private SphereCollider collider;
    private GameManager gameManager;
    private AudioSource explosionSound;
    public GameObject planetShattered;
    public GameObject explosion;
    public GameObject shardExplosion;
    

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        renderer = GetComponent<Renderer>();
        collider = GetComponent<SphereCollider>();
        explosionSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            ExplodePlanet();
            UpdateScore();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet Shard"))
        {
            ExplodeShard(collision);
        }
    }

    void ExplodePlanet() 
    {
        var shatter = Instantiate(planetShattered, transform.position, transform.rotation);
        var explosionfx = Instantiate(explosion, transform.position, transform.rotation);
        explosionSound.Play();
        renderer.enabled = false;
        collider.enabled = false;
        Destroy(gameObject, 7);
        Destroy(explosionfx, 7);
        Destroy(shatter, 7);
        
    }

    void ExplodeShard(Collision shard)
    {
        ContactPoint contact = shard.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        var shardFX = Instantiate(shardExplosion, pos, rot);
        shardFX.gameObject.GetComponent<PlanetRotator>().speed = GetComponent<PlanetRotator>().speed;
        Destroy(shardFX, 2);
        Destroy(shard.gameObject);
    }

    void UpdateScore()
    {
        gameManager.UpdateScore(5);
    }

}
