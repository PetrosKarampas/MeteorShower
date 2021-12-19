using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    public float speed;
    public float selfRotationSpeed;
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
        transform.Rotate(new Vector3(0, Time.deltaTime * selfRotationSpeed, 0));
    }
}
