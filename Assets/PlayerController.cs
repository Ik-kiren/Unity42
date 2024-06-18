using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    public GameObject sceneCamera;
    public int speed = 1;
    public float jumpForce = 150f;
    int jump = 0;
    int cameraZOffset = 8;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.name == "Floor") {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
        jump = 0;
    }

    void OnCollisionStay(Collision collision) {
        jump = 0;
    }

    void OnCollisionExit(Collision collision) {
        jump = 1;
    }

    
    void FixedUpdate()
    {
        sceneCamera.transform.LookAt(gameObject.transform);
        sceneCamera.transform.position = new Vector3(sceneCamera.transform.position.x, sceneCamera.transform.position.y, gameObject.transform.position.z - cameraZOffset);
    }

    void Update()
    {
        float xVel = Input.GetAxis("Horizontal");
        float zVel = Input.GetAxis("Vertical");

        if (jump == 0 && Input.GetKeyDown("space")) {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(new Vector3(0, jumpForce, 0));
            jump = 1;
        }
        rb.velocity = new Vector3(xVel * speed, rb.velocity.y, zVel * speed);
    }
}
