using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 20f;
    private CharacterController characterController;
    public Animator camAnim;
    private bool isWalking;

    private Vector3 inputVector;
    private Vector3 movementVector;

    private float gravity = -10;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
        CheckForHeadBob();

        camAnim.SetBool("isWalking", isWalking);

    }

    void MovePlayer()
    {
        characterController.Move(movementVector * Time.deltaTime);
    }

    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        movementVector = (inputVector * speed) + (Vector3.up * gravity);
    
    }

    void CheckForHeadBob()
    {
        if(characterController.velocity.magnitude>0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

}
