using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject playerBall;
    public float speed = 18f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerBall = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        float moveHorizontal = playerBall.transform.position.x - transform.position.x;
        float moveVertical = playerBall.transform.position.z - transform.position.z;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.LookAt(playerBall.transform);
        this.transform.position += transform.forward * speed * 0.5f * Time.deltaTime;
    }
}
