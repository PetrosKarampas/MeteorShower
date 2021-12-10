using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private AudioSource explosionSoundEffect;
    public GameObject MeteorShattered;
   
    // Start is called before the first frame update
    void Start()
    {
        explosionSoundEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Planet") || other.gameObject.CompareTag("Sun")) {
            var obj = Instantiate(MeteorShattered, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(obj, 5);
        }
    }
}
