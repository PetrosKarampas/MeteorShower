using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float bound = 350;
    void Update()
    {
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
