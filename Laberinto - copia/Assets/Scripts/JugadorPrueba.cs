using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Velocidad = 10;
    Rigidbody miRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        miRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        miRigidbody.AddForce(new Vector3(horizontal,0,vertical) * Velocidad);
    }
}
    