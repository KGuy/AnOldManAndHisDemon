using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHuggingScript : MonoBehaviour {

    public Transform bottom;
    public Rigidbody rb;
    private float checkDistance = 0.5f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        Ray ray = new Ray(bottom.position, Vector3.down);

        bool isGrounded = Physics.Raycast(bottom.position, Vector3.down, checkDistance);

        if (!isGrounded) {
            rb.velocity = new Vector3(rb.velocity.x, -20, rb.velocity.z);
        }

    }
}
