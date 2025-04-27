using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    // Cambia el color del material a transparente
    public void PorDefecto()
    {
        Debug.Log("escucho");
        // Verifica si el objeto tiene un Renderer
        Renderer renderer = this.GetComponent<Renderer>();

        if (renderer != null)
        {
            Debug.Log("escucho2");
            // Cambia el color del material a transparente
            Color transparentColor = new Color(255, 255, 255, 0); // Negro completamente transparente
            renderer.material.color = Color.white;
        }

    }
}
