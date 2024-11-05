using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;
    public float jumpHeight = 3;
    public Animator animator;

    private bool canJump = true;  // Controla si el personaje puede saltar
    private float gravity = -9.81f;
    private Vector3 velocity;

    void Update()
    {
        // Usa el método isGrounded de CharacterController para detectar si está en el suelo
        if (characterController.isGrounded)
        {
            // Reinicia la velocidad en Y si está en el suelo
            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // Permite saltar si el personaje está en el suelo
            canJump = true;
        }
        else
        {
            // Desactiva el salto cuando no está en el suelo
            canJump = false;
        }

        // Obtén el input de movimiento en el plano horizontal
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Actualiza el Animator con las velocidades
        animator.SetFloat("Velx", x);
        animator.SetFloat("Velz", z);

        // Calcula el vector de movimiento en base al input
        Vector3 move = transform.right * x + transform.forward * z;

        // Aplica el movimiento horizontal
        characterController.Move(move * speed * Time.deltaTime);

        // Salto, solo si está en el suelo y se puede saltar
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            canJump = false;  // Desactiva el salto hasta que vuelva a tocar el suelo
        }

        // Aplica la gravedad
        velocity.y += gravity * Time.deltaTime;

        // Aplica el movimiento vertical
        characterController.Move(velocity * Time.deltaTime);
    }
}