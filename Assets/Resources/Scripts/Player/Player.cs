using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Cursor = UnityEngine.Cursor;



[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    // Player Stats
    public PlayerStats Stats { get; private set; }
    
    
    private Camera mainCamera;
    
    public float gravity = 10f;

    //public Camera playerCamera;
    //public float jumpPower = 7f;
    //public float lookSpeed = 2f;
    //public float lookXLimit = 45f;
    //private float rotationX = 0;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;
    private WorldGeneration worldgeneration;

    private bool tested = false;


    public void Awake()
    {
        Stats = new PlayerStats();
    }


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        worldgeneration = GetComponent<WorldGeneration>();
        mainCamera = Camera.main;
        
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Stats.CanTurn)
            LookAtMousePosition();
        
        #region Movement script
        
        //Vector3 foward = transform.TransformDirection(Vector3.forward);
        //Vector3 right = transform.TransformDirection(Vector3.right);
        
        Vector3 forward = Vector3.forward;
        Vector3 right = Vector3.right;

        Stats.IsRunning = Input.GetKey(KeyCode.LeftShift);
        
        float curSpeedX = Stats.CanMove ? (Stats.IsRunning ? Stats.RunSpeedMultiplier * Stats.WalkSpeed : Stats.WalkSpeed) * Input.GetAxis("Vertical") : 0 ;
        float curSpeedY = Stats.CanMove ? (Stats.IsRunning ? Stats.RunSpeedMultiplier * Stats.WalkSpeed : Stats.WalkSpeed) * Input.GetAxis("Horizontal") : 0 ;
        //float movementDirectionY = moveDirection.y;
        
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Verifica se o jogador está se movendo diagonalmente (ambos os eixos têm entrada)
        if (Mathf.Abs(curSpeedX) > 0.1f && Mathf.Abs(curSpeedY) > 0.1f)
        {
            // Normaliza o vetor de movimento para garantir que a velocidade diagonal não seja mais rápida
            moveDirection.Normalize();
            moveDirection *= (Stats.IsRunning ? Stats.RunSpeedMultiplier * Stats.WalkSpeed : Stats.WalkSpeed); // Aplica a velocidade correta após a normalização
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

        if (Input.GetKey(KeyCode.B))
        {
            Stats.Health -= 1;
        }
        
    }
    
    void LookAtMousePosition()
    {
        // Obtendo a posição do mouse na tela
        Vector2 mousePosition = Input.mousePosition;

        // Convertendo a posição do mouse para uma posição no mundo do jogo
        Ray cameraRay = mainCamera.ScreenPointToRay(mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // Plano horizontal
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            // Pega o ponto no mundo onde o raio intersecta o plano
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            
            // Ignora a diferença de altura (y)
            pointToLook.y = transform.position.y;

            // Faz o personagem olhar para esse ponto
            transform.LookAt(pointToLook);
        }
    }
    
}
