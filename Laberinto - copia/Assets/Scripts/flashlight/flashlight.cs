using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public Light LuzLinterna;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
           {
            if(LuzLinterna.enabled == true)
            {
                LuzLinterna.enabled = false;
            }
            else if(LuzLinterna.enabled == false)
            {
                LuzLinterna.enabled = true;
            }
        }
    }
}
