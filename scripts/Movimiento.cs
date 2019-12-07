/*Nombre de script: Movimiento.
   funcion: su funcion es para registar y asignar la movilidad al jugador, asi mismo se le aplican condiciones de si hay piso o no 
   con el objetivo de poder saltar.
   Desarrollador: Adriande jesus gonzalez canales
   Asignatura: Estructura de datos.
   Fecha de desarrollo: 14/11/19
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
// Aquí solo se declaran las variables que se usaran en el script.
{
    #region Variables Publicas.
    public float velocidadRotacion;
    public float velocidad;
    public float fuerzaSalto;
    public bool sihaypiso;
    public bool registroSuma = false;
    public bool aceptarinsercion = true;
    // Variables Privadas.
    Rigidbody rigidSalto;
    GameManager inventarioBalas;
   
    #endregion


    // Start is called before the first frame update
    void Start()
    // Aquí solo se declaran las variables que usaran al iniciar el juego, y se le pide al script que busque al contador en el gamemanager.
    {
        //transform.position = new Vector3(10f,0,0);
        // velocidad = 6;
        inventarioBalas = FindObjectOfType<GameManager>();
        rigidSalto = GetComponent<Rigidbody>();
        fuerzaSalto = 15f; // o lo que es lo mismo 8 newtons
        sihaypiso = false;

        
    }

    // Update is called once per frame

    void Update()
    /* Aquí es donde se crea una suma para registrar los objetos almacenados, el tipo de dato que se está almacenando 
       y el tamaño del arreglo que no debe de ser mayor a tres.

    */

    {

        #region Contador de municiones
        if (registroSuma==true &&inventarioBalas.contadorTiposMunicion < 3)
        {
            inventarioBalas.contadorTiposMunicion++;
            registroSuma = false;
            

          

        }
        if (inventarioBalas.contadorTiposMunicion == 3 && registroSuma == true)
        {
            Debug.Log("Ya estoy lleno");
            registroSuma = false;

        }
        if (inventarioBalas.contadorTiposMunicion >= inventarioBalas.balas.Length)
        {
            aceptarinsercion = false;


        }
        #endregion

        #region Controlador de Mov
        /* Aquí es donde se crea un esquema de entrada de los botones del teclado para que el objeto "Player" se pueda mover por la
            zona de juego.

         */

        if (Input.GetKeyDown(KeyCode.Space)&& sihaypiso==true)
        {
            rigidSalto.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            sihaypiso = false;


        }
        

        if (Input.GetKey(KeyCode.W))
        {
            //transform.position = transform.position + new Vector3(0, 0, 10f) * Time.deltaTime;

            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);



        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * velocidad * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);

        }

        // Aqui se crea el sistema de entrada del mouse para que nuestro jugador pueda rotar en los ejes X,Y y Z.
        float anguloRotacion = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * anguloRotacion * velocidadRotacion * Time.deltaTime);
        #endregion








    }

    private void OnCollisionEnter(Collision otro)
    //OnCollisioEnter registra a nivel código la colisión entre dos objetos y la inserción del tipo de objeto a disparar.
    {
        // si la etiqueta es :
        if (otro.gameObject.tag =="Suelo")
        {
            Debug.Log("Me estas pisando");
            sihaypiso = true;


        }

        // o si la etiqueta es :

        if (otro.gameObject.tag == "ProyectilItem" && aceptarinsercion == true)
        {
            
            inventarioBalas.balas[inventarioBalas.contadorTiposMunicion] = otro.gameObject;
            otro.gameObject.SetActive(false);


            Debug.Log("Haz insertado");
            registroSuma = true;



        }





    }


}// Fin de la clase 

