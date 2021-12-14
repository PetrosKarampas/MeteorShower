using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private Renderer renderer;
    private SphereCollider collider;
    private GameManager gameManager;
    private AudioSource audio;
    private Light light;
    public GameObject planetShattered;
    public GameObject explosion;
    public GameObject shardExplosion;
    

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        renderer    = GetComponent<Renderer>();
        collider    = GetComponent<SphereCollider>();
        audio       = GetComponent<AudioSource>();
        light       = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            ExplodePlanet();
            UpdateScore();
            Destroy(gameObject, audio.clip.length);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet Shard"))
        {
            ExplodeShard(collision);
            
        }
    }

    void ExplodePlanet() {
        var shatter      = Instantiate(planetShattered, transform.position, transform.rotation);
        var explosionfx  = Instantiate(explosion, transform.position, transform.rotation);
        audio.Play();
        renderer.enabled = false;
        collider.enabled = false;
        Destroy(explosionfx, 7);
        Destroy(shatter, 7);
        
    }

    void ExplodeShard(Collision shard)
    {
        ContactPoint contact = shard.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        var shardFX = Instantiate(shardExplosion, pos, rot);
        shardFX.gameObject.GetComponent<PlanetRotation>().speed = GetComponent<PlanetRotation>().speed;
        Destroy(shardFX, 2);
        Destroy(shard.gameObject);
    }

    void UpdateScore()
    {
        gameManager.UpdateScore(5);
    }

}
