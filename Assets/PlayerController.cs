using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    int jump = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.name == "Floor")
            Debug.Log("Game Over");
        jump = 0;
    }

    void OnCollisionStay(Collision collision) {
        jump = 0;
    }

    void OnCollisionExit(Collision collision) {
        jump = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float xVel = Input.GetAxis("Horizontal");
        float zVel = Input.GetAxis("Vertical");
        if (jump == 0 && Input.GetKeyDown("space")) {
            rb.AddForce(new Vector3(0, 150f, 0));
            jump = 1;
        }
        rb.velocity = new Vector3(xVel, rb.velocity.y, zVel) * 1;
    }
}
