using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCollider : MonoBehaviour
{
    public GameObject shardExplosionFX;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet Shard"))
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            var shardFX = Instantiate(shardExplosionFX, pos, rot);
            Destroy(shardFX, 2);
            Destroy(collision.gameObject, 0.05f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var shardFX = Instantiate(shardExplosionFX, other.gameObject.transform.position, other.gameObject.transform.rotation);
        Destroy(shardFX, 2);
        Destroy(other.gameObject, 0.1f);
    }
}
