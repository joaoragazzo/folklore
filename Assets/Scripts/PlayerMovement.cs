using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cursor = UnityEngine.Cursor;



[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float gravity = 10f;

    //public Camera playerCamera;
    //public float jumpPower = 7f;
    //public float lookSpeed = 2f;
    //public float lookXLimit = 45f;
    //private float rotationX = 0;

    private Vector3 moveDirection = Vector3.zero;
    public bool canMove = true;
    private CharacterController characterController;
    private WorldGeneration worldgeneration;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        worldgeneration = GetComponent<WorldGeneration>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement script
        
        Vector3 foward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0 ;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0 ;
        //float movementDirectionY = moveDirection.y;
        
        moveDirection = (foward * curSpeedX) + (right * curSpeedY);    
        
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        
        characterController.Move(moveDirection * Time.deltaTime);
        
        #endregion

        #region Check if the player is near to the edge
        
        worldgeneration.CheckBorders(transform.position);
        
        #endregion
        
        #region Jumping fucntion (descontinued)

        // Jumping function
        // if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        // {
        //     moveDirection.y = jumpPower;
        // }
        // else
        // {
        //     moveDirection.y = movementDirectionY;
        // }
        
        #endregion
        
        #region Camera movement (fescontinued)
        // Camera move function
        // if (canMove)
        // {
        //     rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        //     rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        //     playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0,0);
        //     transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0 );
        //     
        // }
        #endregion

    }
    
}
