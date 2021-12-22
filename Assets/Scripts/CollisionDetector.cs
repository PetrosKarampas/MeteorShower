using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public GameObject MeteorShattered;
   
    private void OnTriggerEnter(Collider other)
    {
        // If meteor collides with a planet destroy meteor and instantiate the shattered meteor
        if(other.gameObject.CompareTag("Planet")) 
        {
            var obj = Instantiate(MeteorShattered, transform.position, transform.rotation);
            obj.gameObject.transform.localScale = transform.localScale/2f;
            Destroy(gameObject);
            Destroy(obj, 5);
        }
        // If meteor colllides with the sun just destroy the meteor
        if(other.gameObject.CompareTag("Sun"))
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
