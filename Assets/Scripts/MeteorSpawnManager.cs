using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawnManager : MonoBehaviour
{
    private float scale;
    void Start()
    {
        scale = Random.Range(1.0f, 5.0f);
        transform.localScale = new Vector3(scale, scale, scale);
    }

}