using UnityEngine;

public class AnimationLoop : MonoBehaviour
{
    // Referencia al Animator
    private Animator animator;

    // Nombre de la animación que queremos reproducir en bucle
    public string animationName;

    void Start()
    {
        // Obtenemos el componente Animator
        animator = GetComponent<Animator>();

        // Reproducimos la animación al iniciar el juego
        PlayAnimationLoop();
    }

    void PlayAnimationLoop()
    {
        // Verificamos si el Animator está configurado y la animación está disponible
        if (animator != null)
        {
            // Establecemos el estado de la animación que queremos reproducir
            animator.Play(animationName);

            // Hacemos que la animación se repita
            animator.SetBool("isLooping", true);
        }
        else
        {
            Debug.LogError("No se encontró el Animator en el objeto.");
        }
    }
}
