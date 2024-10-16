using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyAttack : MonoBehaviour
{
    public GameObject enemySword;
    private Transform playerPosition;
    public float attackVelocity = 50f;



    void Start()
    {
        playerPosition = FindObjectOfType<Movement>().transform;
    }

    void Update()
    {
        
    }

    void attackPlayer()
    {
        Vector3 playerDirection = playerPosition.position = transform.position;  

        
    }
}
