using UnityEngine;

public class CamaraMouseSeguir : MonoBehaviour
{
    public Transform jugador;      // El jugador a seguir
    public Vector3 offset = new Vector3(0, 5, -10); // Distancia relativa al jugador
    public float sensibilidadMouse = 100f; // Sensibilidad de la cámara
    private float rotacionY = 0f;  // Solo necesitamos rotación en Y ahora

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Oculta y bloquea el cursor al centro
        rotacionY = transform.eulerAngles.y; // Inicializa con la rotación actual
    }

    void Update()
    {
        // Solo movimiento horizontal del mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;

        rotacionY += mouseX;

        // Aplicar rotación solo en el eje Y
        transform.rotation = Quaternion.Euler(0f, rotacionY, 0f);
    }

    void LateUpdate()
    {
        // Seguir al jugador con rotación aplicada
        if (jugador != null)
        {
            // Mantenemos el offset original sin rotación vertical
            Vector3 desiredPosition = jugador.position + offset;

            // Aplicamos solo la rotación horizontal al offset si es necesario
            desiredPosition = jugador.position + Quaternion.Euler(0, rotacionY, 0) * offset;

            transform.position = desiredPosition;

            // La cámara siempre mira al jugador
            transform.LookAt(jugador);
        }
    }
}