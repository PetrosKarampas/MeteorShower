using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    public float speed;
    public float selfRotationSpeed;
    GameObject sun;
    void Start()
    {
        sun = GameObject.Find("Sun");
    }

    void Update()
    {
        transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, Time.deltaTime * selfRotationSpeed, 0));
    }
}
