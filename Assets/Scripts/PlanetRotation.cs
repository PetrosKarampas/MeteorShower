using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update
    GameObject sun;
    void Start()
    {
        sun = GameObject.Find("Sun");
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
