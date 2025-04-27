using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Threading.Tasks;
using TMPro;

public class Batalla : MonoBehaviour
{
    public List<GameObject> cartasCercanas = new List<GameObject>();
    public List<GameObject> cartasCercanasYaJugadas = new List<GameObject>();
    public float distanciaMaxima = 1.2f;
    bool enBatalla = false;
    public TextMeshProUGUI textGanador; // Arrastra aquí el componente TextMeshPro desde el Inspector

    private void Start()
    {
        textGanador.text = "";
    }
    // Update is called once per frame
    void Update()
    {

        ActualizarCartasCercanas();

        if (!enBatalla && cartasCercanas.Count >= 2)
        {

            // Ordenar las cartas por distancia al estadio y seleccionar las dos más cercanas
            cartasCercanas.Sort((a, b) => Vector3.Distance(this.gameObject.transform.position, a.transform.position).CompareTo(Vector3.Distance(this.gameObject.transform.position, b.transform.position)));
            GameObject carta1 = cartasCercanas[0];
            GameObject carta2 = cartasCercanas[1];

            // Verificar que las cartas y sus componentes no sean nulos
            if (carta1 != null && carta2 != null)
            {
                enBatalla = true;
                IniciarBatalla(carta1, carta2);
            }
        }
    }

    void ActualizarCartasCercanas()
    {
        cartasCercanas.Clear();
        foreach (GameObject carta in GameObject.FindGameObjectsWithTag("Carta"))
        {
            if (Vector3.Distance(this.gameObject.transform.position, carta.transform.position) < distanciaMaxima && !cartasCercanasYaJugadas.Contains(carta))
            {
                cartasCercanas.Add(carta);
                
            }
        }
    }

    async void IniciarBatalla(GameObject carta1, GameObject carta2)
    {
        Atributos stats1 = carta1.GetComponent<Atributos>();
        Atributos stats2 = carta2.GetComponent<Atributos>();

        Debug.Log("Batalla");
        while (stats1.vida > 0 && stats2.vida > 0)
        {
            await Task.Delay(1000);
            stats1.vida -= Math.Abs(stats1.defensa - stats2.ataque);
            stats2.vida -= Math.Abs(stats2.defensa - stats1.ataque);

            Debug.Log($"{stats1.name}: {stats1.vida} - {stats2.name}: {stats2.vida}");

            // Mostrar efectos visuales y sonoros
            MostrarEfectos(carta1, carta2);
            stats1.SetNumber(stats1.vida);
            stats2.SetNumber(stats2.vida);
        }

        if (stats1.vida > stats2.vida)
        {
            textGanador.text = stats1.nombre;
            MostrarResultado(carta1, true);
            MostrarResultado(carta2, false);
        }
        else
        {
            textGanador.text = stats2.nombre;
            MostrarResultado(carta1, false);
            MostrarResultado(carta2, true);
        }

        stats1.valoresPorDefecto();
        stats2.valoresPorDefecto();
        stats1.SetNumber(stats1.vida);
        stats2.SetNumber(stats2.vida);

        enBatalla = false;
        cartasCercanas = new List<GameObject>();
        cartasCercanasYaJugadas.Add(carta1);
        cartasCercanasYaJugadas.Add(carta2);
    }

    void MostrarEfectos(GameObject carta1, GameObject carta2)
    {
        // Aquí puedes añadir efectos visuales y sonoros
        
    }

    void MostrarResultado(GameObject imageTarget, bool ganadora)
    {
        // Encuentra el hijo del ImageTarget que tiene que cambiar de color
        foreach (Transform child in imageTarget.transform)
        {
            if (child.CompareTag("Objeto")) // Asegúrate de que el hijo tenga el tag "Carta" (o el que corresponda)
            {
                Renderer renderer = child.GetComponent<Renderer>();
                if (renderer != null)
                {
                    if (ganadora)
                    {
                        renderer.material.color = Color.green;
                    }
                    else
                    {
                        renderer.material.color = Color.red;
                    }
                }
                else
                {
                    Debug.LogWarning("El hijo de ImageTarget no tiene componente Renderer.");
                }
                break; // Termina el bucle después de encontrar el primer hijo adecuado
            }
        }
    }

    public void ResetBatalla()
    {
        this.cartasCercanas = new List<GameObject>();
        this.cartasCercanasYaJugadas = new List<GameObject>();

        this.textGanador.text= string.Empty;
    }

}
