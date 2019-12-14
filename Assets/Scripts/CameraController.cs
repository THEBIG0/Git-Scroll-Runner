using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerController player;

    //Keep track of the players last position
    private Vector3 lastPlayerPosition;
    //Move the Camera based on where I am minus where i last was.
    private float distanceToMove;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPosition = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = player.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);


        lastPlayerPosition = player.transform.position;

    }
}
