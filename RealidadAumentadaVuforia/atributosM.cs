using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atributosM : MonoBehaviour
{
    public int ataque;
    public int defensa;
    public int vida;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Mingueza up");
        valoresPorDefect();
    }


    public void valoresPorDefect()
    {
        ataque = 62;
        defensa = 78;
        vida = 77;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
