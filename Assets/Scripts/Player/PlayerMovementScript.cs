using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpStrength;

    public float groundDrag;

    [Header("GroundCheck")]
    public float playerHeight;
    public LayerMask ground;                                
    bool isGrounded;
                                    
    public Rigidbody rigid;
    public Transform player;

    float horizontalInput;
    float verticleInput;

    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        MyInput();
        if (isGrounded) {
            rigid.drag = groundDrag;
        } else
        {
            rigid.drag = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) == true && isGrounded)
        {
            rigid.velocity = Vector2.up * jumpStrength;
        }
        
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticleInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = player.forward * verticleInput + player.right * horizontalInput;
        rigid.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
