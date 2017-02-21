using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    private Vector3 distance;

	void Start () {

        //determines the distance that the cam was placed from the player
		if(player != null)
        {
            distance = player.transform.position - this.transform.position;
        }

        if (player == null)
        {
            Debug.Log("Oi! you need to assign a player to the camera's script!");
        }


	}
	
	void Update () {
        //sets the camera's position so that the distance between it and the player is always the same
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - new Vector3(distance.x, 0, distance.z);
	}
}
