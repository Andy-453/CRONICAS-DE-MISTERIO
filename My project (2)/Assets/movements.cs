using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;        // Velocidad de movimiento
    public float jumpForce = 5.0f;    // Fuerza del salto
    public Animator animator;         // Referencia al Animator
    public Rigidbody rb;              // Referencia al Rigidbody

    private bool isGrounded;           // Si el personaje está en el suelo

    void Start()
    {
        // Asegurarse de que el Rigidbody y Animator están asignados
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        // Obtener el input del teclado para movimiento
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Crear un vector de movimiento basado en el input
        Vector3 move = new Vector3(moveX, 0.0f, moveZ) * speed * Time.deltaTime;

        // Mover el personaje
        transform.Translate(move, Space.Self);

        // Verificar si el personaje está caminando
        if (move != Vector3.zero)
        {
            animator.SetBool("isWalking", true);  // Activar animación de caminar
        }
        else
        {
            animator.SetBool("isWalking", false); // Desactivar animación de caminar
        }
    }

    void Jump()
    {
        // Verificar si el personaje está en el suelo y si se presiona la tecla de salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("isJumping");  // Activar animación de salto
        }
    }

    // Detectar si el personaje está en el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.ResetTrigger("isJumping"); // Reiniciar el estado de salto
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}