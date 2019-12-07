/*Nombre de script: spawnEnemigos.
   funcion: se activa un punto de creacion para los enemigos y de clonacion de si mismos.
   Desarrollador: Adriande jesus gonzalez canales
   Asignatura: Estructura de datos.
   Fecha de desarrollo: 14/11/19
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemigos : MonoBehaviour
/* se crea array para almacenar objetos llamados"enemigos" y "punto de creacion" posicion del enemigo donde creaarse y se determina
 * el punto en el espacio del mundo en donde se creara el o los enemigos.

*/
{
    #region variables 
    [Header("aqui va tu enemigo")]
    public GameObject enemigo;
    [Header("aqui va tu punto de creacion")]
    public Transform puntoDeCreacion;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn",0.5f,3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Aqui se crea una copia del dato "enemigo".
    void spawn()
    {
        Instantiate(enemigo, puntoDeCreacion.position, puntoDeCreacion. rotation);
    }
}
