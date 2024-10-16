using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPuerta : MonoBehaviour
{
    Animator anim;
    public bool Dentro = false;
    bool puerta = false;
    public static bool tomada = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Dentro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Dentro = false;
        }
    }
    void Update()
    {
        if(Dentro && Input.GetKeyDown(KeyCode.E) && tomada)
        {
            puerta = !puerta;
        }
        if (puerta)
        {
            anim.SetBool("abierta", true);
        }
        else
        {
            anim.SetBool("abierta",false);
        }
    }
}
