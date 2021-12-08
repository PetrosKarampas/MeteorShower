using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float bound = 150;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if an object goes past the player's view remove that object
        if (transform.position.x > bound || transform.position.y > bound || transform.position.z > bound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -bound || transform.position.y <-bound || transform.position.z < -bound)
        {
            Destroy(gameObject);
        }
    }
}
