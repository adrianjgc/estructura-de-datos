/*Nombre de script: destruirBala
   funcion: su funcion es hacer desaparecer o quitar del radar de la vista y de la existencia del plano del juego al momento de hacer colision con un objeto
   o al momento de salir de la vista o camara del jugador.
   Desarrollador: Adriande jesus gonzalez canales
   Asignatura: Estructura de datos.
   Fecha de desarrollo: 14/11/19
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirBala : MonoBehaviour
{
    // Start is called before the first frame update
    // esta parte sirve para que la bala despues de ser dispara y/o colisionada desaparzca despues de un cierto tiempo.
    void Start()
    {
        Destroy(this.gameObject,1f);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
