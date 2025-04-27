using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atributosF : MonoBehaviour
{
    // Start is called before the first frame update
    public int ataque;
    public int defensa;
    public int vida;
    void Start()
    {
        valoresPorDefect();
    }

    public void valoresPorDefect()
    {
        ataque = 78;
        defensa = 78;
        vida = 77;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
