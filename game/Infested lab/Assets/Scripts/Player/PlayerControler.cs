using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    public Rigidbody rBody;

    private float inputH;
    private float inputV;

    private float moveX;
    private float moveZ;

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

        moveX = inputH * 500 * Time.deltaTime;
        moveZ = inputV * 500 * Time.deltaTime;
    }
}
