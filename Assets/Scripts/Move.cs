using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10.0f;
    public float horizontalInput;
    public float verticalInput;
    public GameObject miObjeto;
    public GameObject miOtroObjeto;
    public float jumpForce = 10f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    private Rigidbody rb;

    public bool cambiaObjeto = false;

    public Transform camara; // Asigna la Main Camera en el inspector

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;
        Vector3 move = transform.position + movement * speed * Time.fixedDeltaTime;

        rb.MovePosition(move);
    }

    void Update()
    {
        // Movimiento
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Comprobación de suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Intercambiar objeto
        if (Input.GetKeyDown(KeyCode.E))
        {
            cambiaMiObjeto();
        }

        // Rotar hacia la dirección de la cámara
        Vector3 direccionCamara = camara.forward;
        direccionCamara.y = 0f;

        if (direccionCamara != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccionCamara);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, Time.deltaTime * 10f); // Puedes cambiar 10f por más o menos velocidad
        }
    }

    private void cambiaMiObjeto()
    {
        GameObject clon = Instantiate(cambiaObjeto ? miOtroObjeto : miObjeto, transform.position, Quaternion.identity);
        clon.transform.localScale = Vector3.one;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}