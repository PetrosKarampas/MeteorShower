using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardInteraction : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sun"))
        {
            Destroy(gameObject);
        }
    }
}
