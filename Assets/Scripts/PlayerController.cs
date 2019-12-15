using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRb;

    public bool grounded;
    //LayerMask provides a selection of layers of which we created player and ground
    public LayerMask isGround;

    private Collider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the rigidbody2D that is attached to the player
        myRb = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        //if collider attached to player is touching ground give the ability to jump
        //otherwise you could jump infinitly thus making the game preety easy.
        grounded = Physics2D.IsTouchingLayers(myCollider, isGround);

        Move();
        Jump2();
        FallOffPlatform();
    }

    void Move()
    {
        myRb.velocity = new Vector2(moveSpeed, myRb.velocity.y);
    }

    //For Mobile Android gets called via button UI onClick
    public void Jump()
    {
        if(grounded == true)
        {
            myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
        }
    }

    //For PC
    //Note: Don't want to call Jump() in Update as it will jump infinitly
    //so i made a seprate jump function for mobile and pc.

    public void Jump2()
    {
        if(grounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
            }
        }
    }

    //If the position of the player falls below -2.5f reset game.
    public void FallOffPlatform()
    {
        if(transform.position.y < -2.5f)
        {
            SceneManager.LoadScene("Main");
        }
    }

}
