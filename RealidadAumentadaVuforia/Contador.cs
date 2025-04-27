using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI numberText; // Arrastra aqu� el componente TextMeshPro desde el Inspector
    private int currentNumber = 0;

    void Start()
    {
        UpdateNumber(); // Muestra el n�mero inicial
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
