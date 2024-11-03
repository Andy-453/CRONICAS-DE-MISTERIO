using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text; // Para la codificaci�n en JSON

public class LoginManager : MonoBehaviour
{
    public InputField emailInputField; // Vinculado en el Inspector
    public InputField passwordInputField; // Vinculado en el Inspector
    public GameObject feedbackPanel; // Panel de feedback, vinculado en el Inspector
    public GameObject successPanel; // Panel de �xito, vinculado en el Inspector
    public Button loginButton; // Bot�n de inicio de sesi�n, vinculado en el Inspector

    private void Start()
    {
        // Aseg�rate de que el bot�n de inicio de sesi�n llame al m�todo OnLoginButtonClicked
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

        // Verifica si los campos est�n vac�os
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            feedbackPanel.SetActive(true); // Muestra el panel de feedback
            successPanel.SetActive(false); // Aseg�rate de que el panel de �xito est� oculto
            yield break; // Salir del Coroutine si los campos est�n vac�os
        }

        // Crear el contenido de la solicitud en JSON
        string jsonBody = $"{{\"email\":\"{email}\",\"password\":\"{password}\"}}";

        string url = "https://localhost:7275/api/Auth/login"; // Aseg�rate de usar HTTPS si es posible
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
                successPanel.SetActive(false); // Aseg�rate de que el panel de �xito 
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