using UnityEngine;

public class AnimationLoop : MonoBehaviour
{
    // Referencia al Animator
    private Animator animator;

    // Nombre de la animaci�n que queremos reproducir en bucle
    public string animationName;

    void Start()
    {
        // Obtenemos el componente Animator
        animator = GetComponent<Animator>();

        // Reproducimos la animaci�n al iniciar el juego
        PlayAnimationLoop();
    }

    void PlayAnimationLoop()
    {
        // Verificamos si el Animator est� configurado y la animaci�n est� disponible
        if (animator != null)
        {
            // Establecemos el estado de la animaci�n que queremos reproducir
            animator.Play(animationName);

            // Hacemos que la animaci�n se repita
            animator.SetBool("isLooping", true);
        }
        else
        {
            Debug.LogError("No se encontr� el Animator en el objeto.");
        }
    }
}
