using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {

    public Rigidbody rBody;

    private float inputH;
    private float inputV;

    private float moveX;
    private float moveZ;
    public int moveSpeed = 200;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector3(moveX, 0f, moveZ);
    }

    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        moveX = inputH * moveSpeed * Time.deltaTime;
        moveZ = inputV * moveSpeed * Time.deltaTime;
    }
}
