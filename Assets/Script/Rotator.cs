using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Start() {
        GetComponent<Rigidbody>().AddTorque(new Vector3(15, 30, 45));
    }
}
