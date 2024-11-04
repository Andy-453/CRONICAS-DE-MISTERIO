using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInteractior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealthObject"))
        {
            GameManager.Instance.AddHealth(other.gameObject.GetComponent<Health_Object>().health);

            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Arma"))
        {
            GameManager.Instance.LoseHealth(10);
        }
    }
}
