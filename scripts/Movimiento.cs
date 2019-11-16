using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    #region Variables Globales

    //publicas
    public float velocidad;
    public float fuerzaSalto;
    public bool sihaypiso;
    public bool registroSuma = false;
    public bool aceptarinsercion = true;

    //privadas
    Rigidbody rigidSalto;
    GameManager inventarioBalas;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(10f,0,0);
        inventarioBalas = FindObjectOfType<GameManager>();
        rigidSalto = GetComponent<Rigidbody>();
        sihaypiso = false;

        
    }

    // Update is called once per frame

    void Update()
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
        if (Input.GetKeyDown(KeyCode.Space)&& sihaypiso==true)
        {
            rigidSalto.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            sihaypiso = false;


        }
        

        if (Input.GetKey(KeyCode.W))
        {
            //transform.position = transform.position + new Vector3(0, 0, 10f) * Time.deltaTime;

            transform.Translate(Vector3.forward * 5f * Time.deltaTime);



        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 10f * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * 5f * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 10f * Time.deltaTime);

        }
        #endregion








    }

    private void OnCollisionEnter(Collision otro)
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

