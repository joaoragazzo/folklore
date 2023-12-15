using UnityEngine;
using Cursor = UnityEngine.Cursor;



[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{

    [SerializeField] private AudioSource attackSound;
    [SerializeField] private AudioSource walkingSound;
    [SerializeField] private AudioSource damageSound;
    [SerializeField] private AudioSource daySound;
    [SerializeField] private AudioSource nightSound;
    private float oldHealth;
    private Camera mainCamera;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;
    private WorldGeneration worldgeneration;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        worldgeneration = GetComponent<WorldGeneration>();
        mainCamera = Camera.main;
        
        Cursor.visible = true;
       
        oldHealth = PlayerStatsController.Stats.Health;

    }

    // Update is called once per frame
    void Update()
    {
        if (WorldStatsController.Stats.IsPaused) return;
        
        if (PlayerStatsController.Stats.Health <= 0)
        {
            PlayerStatsController.Stats.Health = 0;
            PlayerStatsController.Stats.IsAlive = false;
            WorldStatsController.Stats.Pause();
        }
        
        if(PlayerStatsController.Stats.CanTurn)
            LookAtMousePosition();
        
        #region Movement script
        
        Vector3 forward = Vector3.forward;
        Vector3 right = Vector3.right;
        
        PlayerStatsController.Stats.IsRunning = Input.GetKey(KeyCode.LeftShift);
        
        float curSpeedWS = PlayerStatsController.Stats.CanMove && !PlayerStatsController.Stats.isAttackingWithAxe  && !(PlayerStatsController.Stats.ZombiesAttacking.Count >= 1) ? (PlayerStatsController.Stats.IsRunning ? PlayerStatsController.Stats.RunSpeedMultiplier * PlayerStatsController.Stats.WalkSpeed : PlayerStatsController.Stats.WalkSpeed) * Input.GetAxis("Vertical") : 0 ;
        float curSpeedAD = PlayerStatsController.Stats.CanMove && !PlayerStatsController.Stats.isAttackingWithAxe  && !(PlayerStatsController.Stats.ZombiesAttacking.Count >= 1) ? (PlayerStatsController.Stats.IsRunning ? PlayerStatsController.Stats.RunSpeedMultiplier * PlayerStatsController.Stats.WalkSpeed : PlayerStatsController.Stats.WalkSpeed) * Input.GetAxis("Horizontal") : 0 ;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            PlayerStatsController.Stats.IsMoving = true;
            if(PlayerStatsController.Stats.IsMoving && !walkingSound.isPlaying)
            {
                walkingSound.Play();
            }
            
        }
        else
        {
            PlayerStatsController.Stats.IsMoving = false;
            if(walkingSound.isPlaying)
            {
                walkingSound.Stop();
            }
        }
        
        moveDirection = (forward * curSpeedWS) + (right * curSpeedAD);
        
        if (Mathf.Abs(curSpeedWS) > 0.1f && Mathf.Abs(curSpeedAD) > 0.1f)
        {
            moveDirection.Normalize();
            moveDirection *= (PlayerStatsController.Stats.IsRunning ? PlayerStatsController.Stats.RunSpeedMultiplier * PlayerStatsController.Stats.WalkSpeed : PlayerStatsController.Stats.WalkSpeed); // Aplica a velocidade correta após a normalização
        }

        PlayerStatsController.Stats.PlayerVelocity = moveDirection;
        
        characterController.Move(moveDirection * Time.deltaTime);
        
        #endregion

        #region Fixing player location

        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        
        #endregion
        
        #region Check if the player is near to the edge
        
        worldgeneration.CheckBorders(transform.position);
        
        #endregion

        PlayerStatsController.Stats.PlayerPosition = transform.position;

    
        #region Cycle Music 
        
        if(WorldStatsController.Stats.IsDay && !daySound.isPlaying)
        {
            Debug.Log("Dia - Tocando som do dia");
            nightSound.Stop();
            daySound.Play();
        }

        if (!WorldStatsController.Stats.IsDay)
        {
            daySound.Stop();
        }
        
        if(!WorldStatsController.Stats.IsDay && !nightSound.isPlaying)
        {
            Debug.Log("Noite - Tocando som da noite");
            daySound.Stop();
            nightSound.Play();
        }
        
        if (WorldStatsController.Stats.IsDay)
        {
            nightSound.Stop();
        }
        
        #endregion
    
    
    

        #region Damage Sound

        if(PlayerStatsController.Stats.Health < oldHealth && !damageSound.isPlaying)
        {
            damageSound.Play();
        }
        oldHealth = PlayerStatsController.Stats.Health;
       
        #endregion

        #region Attack Sound

        if(PlayerStatsController.Stats.isAttackingWithAxe && !attackSound.isPlaying)
        {
                attackSound.Play();
        }

        #endregion

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
