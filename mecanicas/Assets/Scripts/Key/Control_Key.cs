using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Key : MonoBehaviour
{
    public bool Dentro;
    void Start()
    {
        
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
        if(Dentro && Input.GetKeyDown(KeyCode.E))
        {
            ControlPuerta.tomada = true;
        }
    }
}
