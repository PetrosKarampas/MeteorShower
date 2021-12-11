using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameObject MeteorShattered;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Planet")) 
        {
            var obj = Instantiate(MeteorShattered, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(obj, 5);
        }
        if (other.gameObject.CompareTag("Sun"))
        {
            Destroy(gameObject, 0.4f);
        }
    }
}
