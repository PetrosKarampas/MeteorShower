using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameObject MeteorShattered;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
            Destroy(gameObject, 0.5f);
        }
    }
}
