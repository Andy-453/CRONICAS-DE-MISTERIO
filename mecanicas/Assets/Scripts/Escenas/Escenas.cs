using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Primera");
    }

    public void CargarNivel(string NombreNivel1)
    {
        SceneManager.LoadScene(NombreNivel1);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
