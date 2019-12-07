
/* Nombre de script: DañoBala.
   funcion: activar mecanica de eliminacion de enemigos.
   Nombre del desarrollador: Adrian de jesus gonzalez canales.
   Asignatura: Estructura de datos.
   Fecha de desarrollo:26/10/19.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoBala : MonoBehaviour
{ 
    public Score scoreSuma;

    void Start()
    {
        scoreSuma = FindObjectOfType<Score>();
    }
    //OnCollisioEnter se registra a nivel codigo la colision o destruccion de ambos, tanto el enemigo y la bala.
    void OnCollisionEnter(Collision otroEnemigo)
    {
        if (otroEnemigo.gameObject.tag == "Enemigo")
        {
            scoreSuma.score += 10;
            Destroy(otroEnemigo.gameObject);
            Destroy(this.gameObject);

        }
        
    }


}
