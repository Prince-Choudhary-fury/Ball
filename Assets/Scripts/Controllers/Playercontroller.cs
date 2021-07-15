using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{

    private Rigidbody2D playerRigidbody;
    private CircleCollider2D playerCollider;
    public int playerSpeed = 8;
    public float jumpSpeed = 5f;

    [SerializeField]
    private LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        playerRigidbody.velocity = new Vector2(dirX * playerSpeed, playerRigidbody.velocity.y);

        if ((Input.GetButtonDown("Jump") ) && isGrounded())
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpSpeed);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.CircleCast(playerCollider.bounds.center, playerCollider.radius, Vector2.down, 0.1f, jumpableGround);
    }

}
