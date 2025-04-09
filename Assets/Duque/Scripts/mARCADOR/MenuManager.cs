using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_Dropdown scoreDropdown;

    private void Start()
    {
        // Cargar la última selección guardada (opcional)
        if (PlayerPrefs.HasKey("ScoreToWin"))
        {
            int savedValue = PlayerPrefs.GetInt("ScoreToWin");
            int index = scoreDropdown.options.FindIndex(option => option.text == savedValue.ToString());
            if (index != -1)
            {
                scoreDropdown.value = index;
            }
        }
    }

    public void OnScoreDropdownChanged()
    {
        // Obtener el valor del Dropdown (10, 20 o 30)
        int selectedScore = int.Parse(scoreDropdown.options[scoreDropdown.value].text);

        // Guardarlo en PlayerPrefs para que esté disponible en la escena del juego
        PlayerPrefs.SetInt("ScoreToWin", selectedScore);
        PlayerPrefs.Save();
    }
}
