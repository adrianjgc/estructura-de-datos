/*Nombre de script: Dañojugador.
   funcion: su funcion es hacer el daño al jugador o mas bien recivirdaño o causar daño.
   Desarrollador: Adriande jesus gonzalez canales
   Asignatura: Estructura de datos.
   Fecha de desarrollo: 14/11/19
*/using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dañojugador : MonoBehaviour
{
    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Player")
        {
            jugador.GetComponent<Vida>().vida--;
        }
        
    }
}
