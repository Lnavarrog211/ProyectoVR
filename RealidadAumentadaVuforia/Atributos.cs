using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Atributos : MonoBehaviour
{
    public int ataque;
    public int defensa;
    public int vida;
    public TextMeshProUGUI numberText; // Arrastra aquí el componente TextMeshPro desde el Inspector
    public int currentNumber = 0;
    public string nombre;
    void Start()
    {
        // Asigna valores predeterminados si no están ya establecidos
        valoresPorDefecto();
        UpdateNumber();
    }

    public void valoresPorDefecto()
    {
        // Puedes establecer valores predeterminados aquí si lo deseas, 
        // o configurarlos individualmente en el inspector de Unity
        if (nombre=="Fran")
        {
            ataque = 61;
            defensa = 77;
            vida = 78;
        }
        if (nombre == "Mingueza")
        {
            ataque = 78;
            defensa = 77;
            vida = 62;
        }
        if (nombre == "Dani")
        {
            ataque = 61;
            defensa = 79;
            vida = 77;
        }
    }

    // Método para restablecer los valores a los iniciales si es necesario
    public void ResetValores(int ataqueInicial, int defensaInicial, int vidaInicial)
    {
        ataque = ataqueInicial;
        defensa = defensaInicial;
        vida = vidaInicial;
    }

    public void SetNumber(int number)
    {
        currentNumber = number;
        UpdateNumber();
    }

    private void UpdateNumber()
    {
        if (numberText != null)
        {
            numberText.text = currentNumber.ToString();
        }
    }
}
