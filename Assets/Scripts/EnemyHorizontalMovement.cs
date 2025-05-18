using UnityEngine;

public class EnemyHorizontalMovement : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    [Tooltip("Velocidad de movimiento en unidades/segundo")]
    public float speed = 3f;

    [Space]
    [Tooltip("Límite izquierdo en el eje X")]
    public float leftBound = -34f;
    [Tooltip("Límite derecho en el eje X")]
    public float rightBound = -8f;

    private int direction = 1; // 1=derecha, -1=izquierda
    private Vector3 fixedPosition; // Para bloquear ejes Y/Z

    void Start()
    {
        // Bloquear posición inicial en Y/Z
        fixedPosition = transform.position;
        fixedPosition.y = transform.position.y;
        fixedPosition.z = transform.position.z;
    }

    void Update()
    {
        // Calcular nueva posición solo en X
        float newX = transform.position.x + direction * speed * Time.deltaTime;

        // Verificar límites
        if (newX >= rightBound)
        {
            newX = rightBound;
            direction = -1;
        }
        else if (newX <= leftBound)
        {
            newX = leftBound;
            direction = 1;
        }

        // Aplicar movimiento solo en X manteniendo Y/Z fijos
        fixedPosition.x = newX;
        transform.position = fixedPosition;
    }

    // Visualización de límites en el Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 center = new Vector3((leftBound + rightBound) / 2, transform.position.y, transform.position.z);
        Vector3 size = new Vector3(Mathf.Abs(rightBound - leftBound), 0.5f, 0.5f);
        Gizmos.DrawWireCube(center, size);
    }
}