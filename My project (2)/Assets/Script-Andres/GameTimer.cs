using UnityEngine;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float gameTime = 0f; // Tiempo en segundos
    private bool gameEnded = false;

    void Update()
    {
        // Solo incrementa el tiempo si el juego no ha terminado
        if (!gameEnded)
        {
            gameTime += Time.deltaTime;
        }
    }

    // Llama a esta función cuando el jugador termine el juego
    public void EndGame()
    {
        gameEnded = true;
        Debug.Log("Tiempo total: " + GetFormattedTime());
    }

    // Retorna el tiempo en formato mm:ss para mostrar
    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60F);
        int seconds = Mathf.FloorToInt(gameTime % 60F);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Endpoint que puedes usar para enviar el tiempo al servidor
    
}