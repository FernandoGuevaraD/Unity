using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Test_clase : MonoBehaviour
{
    //si las variables son publica como aqui se las puede editar desde Unity
    public float posX = 0.2f;
    public float posy = 25.2f;
    public float posz = -33.3f;
    void Start()
    {
        //Debug.Log("My name is: --> " +name);
        //Debug.Log("Position X --> " + transform.position.x );

        //Cambia la posición de la camara 
        transform.position = new Vector3(posX, posy, posz);
    }

    void Update()
    {
        //Debug.Log("Hello world Unity engine");
    }
}
