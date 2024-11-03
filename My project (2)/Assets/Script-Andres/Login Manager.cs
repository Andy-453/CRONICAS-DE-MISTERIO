using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text; // Para la codificación en JSON

public class LoginManager : MonoBehaviour
{
    public InputField emailInputField; // Vinculado en el Inspector
    public InputField passwordInputField; // Vinculado en el Inspector
    public GameObject feedbackPanel; // Panel de feedback, vinculado en el Inspector
    public GameObject successPanel; // Panel de éxito, vinculado en el Inspector
    public Button loginButton; // Botón de inicio de sesión, vinculado en el Inspector

    private void Start()
    {
        // Asegúrate de que el botón de inicio de sesión llame al método OnLoginButtonClicked
        loginButton.onClick.AddListener(OnLoginButtonClicked);
    }

    public void OnLoginButtonClicked()
    {
        StartCoroutine(LoginCoroutine());
    }

    private IEnumerator LoginCoroutine()
    {
        if (emailInputField == null || passwordInputField == null || feedbackPanel == null || successPanel == null)
        {
            Debug.LogError("One or more fields are not assigned in the Inspector.");
            yield break; // Salir del Coroutine si hay un problema
        }

        string email = emailInputField.text;
        string password = passwordInputField.text;

        // Verifica si los campos están vacíos
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            feedbackPanel.SetActive(true); // Muestra el panel de feedback
            successPanel.SetActive(false); // Asegúrate de que el panel de éxito esté oculto
            yield break; // Salir del Coroutine si los campos están vacíos
        }

        // Crear el contenido de la solicitud en JSON
        string jsonBody = $"{{\"email\":\"{email}\",\"password\":\"{password}\"}}";

        string url = "https://localhost:7275/api/Auth/login"; // Asegúrate de usar HTTPS si es posible
        using (UnityWebRequest webRequest = new UnityWebRequest(url, "POST"))
        {
            // Convertir el cuerpo JSON en bytes
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            // Establecer las cabeceras
            webRequest.SetRequestHeader("Content-Type", "application/json");

            // Enviar la solicitud
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                string responseText = webRequest.downloadHandler.text;
                if (responseText.Contains("User not found"))
                {
                    feedbackPanel.SetActive(true);
                    successPanel.SetActive(false);
                    Debug.LogError("User not found");
                }
                feedbackPanel.SetActive(true); // Muestra el panel de feedback
                successPanel.SetActive(false); // Asegúrate de que el panel de éxito 
                Debug.LogError("Error: " + webRequest.error);
                Debug.LogError("Response Code: " + webRequest.responseCode);
                Debug.LogError("Response Text: " + webRequest.downloadHandler.text);
            }
            else
            {

                feedbackPanel.SetActive(false);
                successPanel.SetActive(true);
                Debug.Log("Login successful!");

            }
        }
    }
}