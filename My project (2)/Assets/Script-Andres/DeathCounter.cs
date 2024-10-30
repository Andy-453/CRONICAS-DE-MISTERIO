using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    private int deathCount = 0;

    // Esta función debe llamarse cada vez que el jugador muera
    public void AddDeath()
    {
        deathCount++;
        Debug.Log("Muertes totales: " + deathCount);
    }

    // Endpoint para obtener la cantidad de muertes
    
}