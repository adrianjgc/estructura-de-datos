using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    #region Variables
    [Header("aqui va tu enemigo")]
    public GameObject enemigo;

    [Header("aqui va tu punto de creacion")]
    public Transform puntodeCreacion;
    #endregion
}
// Start is called before the first frame update
void Start()
    {
    Invoke Repeating("spawn", 0.5f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
    Instantiate(enemigo, puntodeCreacion.position, puntodeCreacion.rotation);
    }
}
