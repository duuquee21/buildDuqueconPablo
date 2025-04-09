using UnityEngine;

public class SableToggleJuego : MonoBehaviour
{
    public GameObject sableDerecho;

    void Start()
    {
        // Leer si el jugador activó el doble sable
        bool dobleSableActivo = PlayerPrefs.GetInt("DobleSable", 0) == 1;

        sableDerecho.SetActive(dobleSableActivo);
    }
}
