using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;         // Puntaje estático
    public TMP_Text worldSpaceScore;    // Texto que se quedará en el espacio del mundo
    public int scoreToWin = 20;         // Puntaje necesario para ganar

    public GameObject endGamePanel;     // Panel o UI que se muestra al finalizar el juego

    private void Start()
    {
        // Asegura que el puntaje comience en 0
        score = 0;

        // Cargar el puntaje objetivo desde PlayerPrefs
        if (PlayerPrefs.HasKey("ScoreToWin"))
        {
            scoreToWin = PlayerPrefs.GetInt("ScoreToWin");
        }

        // Oculta el panel de fin de juego al inicio
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(false);
        }
    }

    public void IncreaseScore()
    {
        score++; // Incrementa el puntaje
        UpdateScoreText();

        if (score >= scoreToWin)
        {
            EndGame();
        }
    }
    public void DecreaseScore()
    {
        score--; 
        UpdateScoreText();

        if (score >= scoreToWin)
        {
            EndGame();
        }
    }

    private void UpdateScoreText()
    {
        if (worldSpaceScore != null)
        {
            worldSpaceScore.text = "Score: " + score.ToString(); // Actualiza el texto del marcador
        }
    }

    private void EndGame()
    {
        // Muestra el panel de fin de juego
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(true);
        }

        // Detenemos el tiempo del juego
        Time.timeScale = 0f;

        Debug.Log("¡Juego terminado! Has alcanzado el puntaje de " + scoreToWin);
    }
}
