using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public GameObject MeteorShattered;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Planet")) 
        {
            var obj = Instantiate(MeteorShattered, transform.position, transform.rotation);
            obj.gameObject.transform.localScale = transform.localScale/2f;
            Destroy(gameObject);
            Destroy(obj, 5);
        }
        if (other.gameObject.CompareTag("Sun"))
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
