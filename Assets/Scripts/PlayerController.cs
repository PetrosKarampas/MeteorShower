using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float sensitivity = 2f;
    private float horizontalInput;
    private float verticalInput;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public GameObject meteorPrefab;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        yaw += sensitivity * Input.GetAxis("Mouse X");
        pitch -= sensitivity * Input.GetAxis("Mouse Y");
       
        pitch = Mathf.Clamp(pitch, -60f, 90f);
        

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(meteorPrefab, transform.position, transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("WHY NOT WORK");
        playerRb = GetComponent<Rigidbody>();
        Vector3 awayFromPlanet = transform.position - collision.gameObject.transform.position;
        //playerRb.AddForce(awayFromPlanet * 50, ForceMode.Force);
        Debug.Log("Player collided with: " + collision.gameObject.name );
    }

}
