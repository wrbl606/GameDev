using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitator : MonoBehaviour
{
    private float hoverForce = 30f, hoverHeight = 1.5f, powerInput, turnInput;
    Rigidbody rbody;

    void Start() {
        rbody = GetComponent<Rigidbody>();
        hoverForce = Random.Range(30f, 60f);
        hoverHeight = Random.Range(.7f, 1.3f);
    }

    void FixedUpdate() {
        Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight)) {
            if (hit.collider.name.Equals("Ground")) {
                float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
                Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
                rbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
            }
        }
    }
}
