using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persecucion : MonoBehaviour
{
    public Transform playerPosition;
    public float velocidadEnemigo;
    

    // Start is called before the first frame update
    void Start()
    {
       playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (direccion.magnitude < 1f)
        {
            Vector3 PlayerPos = new Vector3(playerPosition.position.x, transform.position.y, playerPosition.position.z);

            Vector3 direccion = PlayerPos - transform.position;

            //voltear hacia abajo
            transform.LookAt(direccion, Vector3.up);
            transform.Translate(direccion.normalized * velocidadEnemigo * Time.deltaTime);
        }
    }
}
