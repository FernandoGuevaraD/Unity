using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectable : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisione con: " + other.name);
        // accediendo a las variables y metodos de la clase Move
        Move myObject = other.GetComponent<Move>();
        myObject.cambiaObjeto = true; // para cambiar el valor de otra clase y así cambiar valores en otro personaje como balas dobles
        Destroy(this.gameObject);
    }
}
