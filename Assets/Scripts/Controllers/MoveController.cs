using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public AudioSource Bounce;

    private Rigidbody2D playerRigidbody;

    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpSpeed = 500f;
    private bool moveLeft = false;
    private bool moveRight = false;
    private bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveLeft()
    {
        moveLeft = true;
    }

    public void MoveRight()
    {
        moveRight = true;
    }

    public void Jump()
    {
        isJump = true;
        if (playerRigidbody.velocity.y == 0)
        {
            playerRigidbody.AddForce(Vector2.up * jumpSpeed);
        }
    }

    public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
        playerRigidbody.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            playerRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
        else if (moveRight)
        {
            playerRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if ((other.collider.tag == "Ground") && isJump)
        {
            Bounce.Play();
            isJump = false;
        }
    }

}
