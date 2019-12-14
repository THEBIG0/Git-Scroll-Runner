using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRb;

    public Button yourButton;

    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the rigidbody2D that is attached to the player
        myRb = GetComponent<Rigidbody2D>();
        //Get a reference to the button Component
        Button btn = yourButton.GetComponent<Button>();
        //When button is pressed call Jump() function
        btn.onClick.AddListener(Jump);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump2();
    }

    void Move()
    {
        myRb.velocity = new Vector2(moveSpeed, myRb.velocity.y);
    }

    //For Mobile Android
    public void Jump()
    {
        myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
    }

    //For PC
    //Note: Don't want to call Jump() in Update as it will jump infinitly
    //so i made a seprate jump function for mobile and pc.
    
    public void Jump2()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
        }
    }
}
