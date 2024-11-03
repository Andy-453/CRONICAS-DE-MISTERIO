using UnityEngine;

public class OpenURL : MonoBehaviour
{
    // URL que quieres abrir
    public string url = "https://localhost:7275/api/Auth/register";

    // Este m�todo se puede conectar al bot�n desde el editor de Unity
    public void OpenWebPage()
    {
        Application.OpenURL(url);
    }
}