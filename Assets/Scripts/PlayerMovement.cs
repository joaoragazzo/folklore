using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;
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


    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    public bool canMove = true;
    private CharacterController characterController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
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

        #region Check if the player is near to the edge
        
        CheckBorders();
        
        #endregion
        
        

        // Jumping function
        // if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        // {
        //     moveDirection.y = jumpPower;
        // }
        // else
        // {
        //     moveDirection.y = movementDirectionY;
        // }
        
        // Camera move function
        // if (canMove)
        // {
        //     rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        //     rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        //     playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0,0);
        //     transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0 );
        //     
        // }

    }

    void CheckBorders()
    {
        RaycastHit hit;
        float distanceToCheck = 2.0f; 
        float radiusToCheck = 10.0f;  //TODO: Aumentar o tamanho para ficar do tamanho ideal para o jogador não ver o terreno ser gerado 
        
        for (float i = 0f; i <= 2 * Mathf.PI; i += 0.50f)
        {
            Vector3 rayVector3 = new Vector3((Mathf.Cos(i) * radiusToCheck) + transform.position.x, 
                transform.position.y, 
                (Mathf.Sin(i) * radiusToCheck) + transform.position.z);
            
            //Debug.DrawRay(rayVector3, Vector3.down * distanceToCheck, Color.red, 2.0f);
            if (!Physics.Raycast(rayVector3, Vector3.down, out hit, distanceToCheck))
            {
                // Não há terreno abaixo do jogador após a distância especificada
                //Debug.Log("Near edge");
            }    
        }
    }
}
