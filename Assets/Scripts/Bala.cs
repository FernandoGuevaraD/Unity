using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 20f;
    public float posZ = 80f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z > posZ)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemigo"))
        {
            Destroy(other.gameObject);  // Elimina el enemigo
            Destroy(this.gameObject);  // La bala se destruye
            // Opcional: también podrías desactivar el collider si no quieres múltiples colisiones
            GetComponent<Collider>().enabled = false;
        }
    }
}
