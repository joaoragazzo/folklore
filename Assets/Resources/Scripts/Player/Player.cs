using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using Cursor = UnityEngine.Cursor;



[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    // Player PlayerStatsController.Stats
    public PlayerStatsController PlayerStatsController { get; private set; }
    
    private Camera mainCamera;
    
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;
    private WorldGeneration worldgeneration;
    


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
        if (PlayerStatsController.Stats.Health < 0)
            PlayerStatsController.Stats.Health = 0;
        
        if(PlayerStatsController.Stats.CanTurn)
            LookAtMousePosition();
        
        #region Movement script
        
        //Vector3 foward = transform.TransformDirection(Vector3.forward);
        //Vector3 right = transform.TransformDirection(Vector3.right);
        
        Vector3 forward = Vector3.forward;
        Vector3 right = Vector3.right;

        PlayerStatsController.Stats.CanMove = !(PlayerStatsController.Stats.ZombiesAttacking.Count >= 1);

        PlayerStatsController.Stats.IsRunning = Input.GetKey(KeyCode.LeftShift);
        
        float curSpeedX = PlayerStatsController.Stats.CanMove ? (PlayerStatsController.Stats.IsRunning ? PlayerStatsController.Stats.RunSpeedMultiplier * PlayerStatsController.Stats.WalkSpeed : PlayerStatsController.Stats.WalkSpeed) * Input.GetAxis("Vertical") : 0 ;
        float curSpeedY = PlayerStatsController.Stats.CanMove ? (PlayerStatsController.Stats.IsRunning ? PlayerStatsController.Stats.RunSpeedMultiplier * PlayerStatsController.Stats.WalkSpeed : PlayerStatsController.Stats.WalkSpeed) * Input.GetAxis("Horizontal") : 0 ;
        //float movementDirectionY = moveDirection.y;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            PlayerStatsController.Stats.IsMoving = true;
        }
        else PlayerStatsController.Stats.IsMoving = false;
        
        
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Verifica se o jogador está se movendo diagonalmente (ambos os eixos têm entrada)
        if (Mathf.Abs(curSpeedX) > 0.1f && Mathf.Abs(curSpeedY) > 0.1f)
        {
            // Normaliza o vetor de movimento para garantir que a velocidade diagonal não seja mais rápida
            moveDirection.Normalize();
            moveDirection *= (PlayerStatsController.Stats.IsRunning ? PlayerStatsController.Stats.RunSpeedMultiplier * PlayerStatsController.Stats.WalkSpeed : PlayerStatsController.Stats.WalkSpeed); // Aplica a velocidade correta após a normalização
        }
        
        characterController.Move(moveDirection * Time.deltaTime);
        
        #endregion

        #region Fixing player location

        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        
        #endregion
        
        #region Check if the player is near to the edge
        
        worldgeneration.CheckBorders(transform.position);
        
        #endregion

        PlayerStatsController.Stats.PlayerPosition = transform.position;
        
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
