using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public Transform[] destination;

    public Animator animator;

    private int i = 0;

    public float distanceToFollowPath = 2f;

    [Header("-----------Follow------------")]

    public bool followPlayer;

    public bool attack;

    private GameObject player;

    private float distanceToPlayer;

    public float distanceToFollowPlayer = 10;
    void Start()
    {
        navMeshAgent.destination = destination[i].transform.position;
        player = FindObjectOfType<Movement>().gameObject;
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= distanceToFollowPlayer)
        {
            FollowPlayer();
        }
        else
        {
            EnemyPath();
        }
    }

    public void EnemyPath()
    {
        navMeshAgent.destination = destination[i].position;
        if (Vector3.Distance(transform.position, destination[i].position) <= distanceToFollowPath)
        {
            if (destination[i] != destination[destination.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }

    public void FollowPlayer()
    {
        if(Vector3.Distance(transform.position, player.transform.position) > 1 && !attack)
        {
            navMeshAgent.destination = player.transform.position;
            animator.SetBool("Attack", false);
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Attack", true);
            attack = true;
        }
    }
    public void Final_Ani()
    {
        animator.SetBool("Attack", false );
        attack = false;
    }
}
