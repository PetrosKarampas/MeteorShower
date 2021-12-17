using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawnManager : MonoBehaviour
{
    private float scale;
    void Start()
    {
        scale = Random.Range(2.0f, 10.0f);
        transform.localScale = new Vector3(scale, scale, scale);
    }

}
