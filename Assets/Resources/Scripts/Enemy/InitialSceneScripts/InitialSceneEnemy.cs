
using UnityEngine;

public class SaciInitialScene : MonoBehaviour
{
    public float speed = 3f;
    private bool startWalkingBackwards;
    public bool invert;

    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        Invoke("StartMoveBackwardsFunction", GameStatsController.Stats.initialSceneDelayInSeconds);
        Destroy(gameObject, 20f);
    }

    void Update()
    {
        if (!startWalkingBackwards) return;
        Vector3 backwardDirection;
        
        
        // Movimentar o inimigo para trás
        if (!invert)
            backwardDirection = -transform.forward;
        else
            backwardDirection = transform.forward;
        
        transform.Translate(backwardDirection * speed * Time.deltaTime, Space.World);
        
    }

    // Update is called once per frame
    void StartMoveBackwardsFunction()
    {
        _animator.SetBool("WalkingBackward", true);
        startWalkingBackwards = true;
    }
}
