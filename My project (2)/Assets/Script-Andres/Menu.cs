using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }

    

    public void Opciones()
    {

    }

    public void Creditos()
    {
         
    }

    public void Quit()
    {
        Application.Quit();
    }
}
