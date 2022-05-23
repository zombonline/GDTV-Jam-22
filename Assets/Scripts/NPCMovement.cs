using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public bool isMoving = true;
    [SerializeField] int xMovementAreaSize, yMovementAreaSize;

    float timeAlive;
    [SerializeField] float timeAliveMin, timeAliveMax;
    AIPath aiPath;
    Animator animator;

    IEnumerator PauseAndGenerateNewDestination()
    {
        yield return new WaitForSeconds(5f);
        aiPath.destination = new Vector2(Random.Range(-xMovementAreaSize, xMovementAreaSize), Random.Range(-yMovementAreaSize, yMovementAreaSize));
    }

    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        animator = GetComponent<Animator>();
        
    }
    private void Start()
    {
        aiPath.destination = new Vector2(Random.Range(-xMovementAreaSize, xMovementAreaSize), Random.Range(-yMovementAreaSize, yMovementAreaSize));
        timeAlive = Random.Range(timeAliveMin, timeAliveMax);
    }

    private void Update()
    {

        timeAlive -= Time.deltaTime;
        if(timeAlive <= 0)
        {
            isMoving = false;
            animator.SetBool("Dead", true);
            GetComponentInChildren<NPCCanvas>().dead = true;
        }
        if(!isMoving)
        {
            aiPath.canMove = false;
            return;
        }
        if(GetComponent<AIPath>().reachedEndOfPath)
        {
            if(animator.GetBool("Walking"))
            {
                StartCoroutine(PauseAndGenerateNewDestination());
            }
            animator.SetBool("Walking", false);
        }
        else
        {
            animator.SetBool("Walking", true);
        }
    }

}
