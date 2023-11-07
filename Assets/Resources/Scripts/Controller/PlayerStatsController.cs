using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    public static PlayerStatsController Stats { get; private set; }
    public bool IsAlive { get; set; } = true;
    public float Health { get; set; } = 100f;
    public float MaxHealth { get; set; } = 100f;
    public float WalkSpeed { get; set; } = 6f;
    public float RunSpeedMultiplier { get; set; } = 2f;
    public int Strength { get; set; } = 1;
    public float CritChance { get; set; } = 0.0f;
    public float CritMultiplier { get; set; } = 2.5f;
    public float AxeRotateSpeed { get; set; } = 120f;
    public float BaseDamageMultiplier { get; set; } = 100f;
    public int Money { get; set; } = 0;
    public bool CanMove { get; set; } = true;
    public bool CanTurn { get; set; } = true;
    public bool CanFire { get; set; } = true;
    public bool IsRunning { get; set; } = false;
    public bool IsMoving { get; set; }
    public bool IsAttacking { get; set; }
    public Vector3 Mouse3DPosition { get; set; }
    public Vector3 PlayerPosition { get; set; }
    public double RifleDamage { get; set; } = 10;
    public double ShotgunDamage { get; set; } = 10;
    public double SniperDamage { get; set; } = 250;
    public List<Upgrade> Upgrades { get; set; } = new List<Upgrade>();
    public HashSet<CorpoSeco> ZombiesAttacking { get; set; } = new HashSet<CorpoSeco>();
    public bool Freezed = false;
    
    private void Awake()
    {
        if (Stats == null)
        {
            Stats = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    
    public void TakeDamage(float amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            IsAlive = false;
        }
    }
    

    public void Freeze()
    {
        CanFire = false;
        CanTurn = false;
        CanMove = false;
        Freezed = true;
    }

    public void Unfreeze()
    {
        CanFire = true;
        CanTurn = true;
        CanMove = true;
        Freezed = false;
    }
    
}