using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // reference to player Rigidbody
    public Rigidbody player;
    // Reposition point on death
    public Vector3 respawn(0, 20, 0);
    // Variable for player speed
    public float speed = 2000f;
    // Variable for jump power
    public float jump = 20f;
    // Variable to determine if on a platform
    public bool grounded = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        player.MovePosition(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    
        // Jump
        if (Input.GetKey("Space") && grounded)
        {
            grounded = false;
            player.AddForce(jump * transform.up);
        }
        // Land
        if (!grounded)
        {
            player.AddForce(transform.down * gravity);
        }
    }
    // Method for determining grounded status
    void IsGroundedEnter()
    {
        grounded = true;
    }
    void Update()
    {
        if (player.transform.prosition.y < -15)
        {
            player.transform.position = respawn;
        }
    }
}
