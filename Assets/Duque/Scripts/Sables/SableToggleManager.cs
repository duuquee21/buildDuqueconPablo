using UnityEngine;
using UnityEngine.UI;

public class SableToggleManager : MonoBehaviour
{
    public Toggle dobleSableToggle;

    void Start()
    {
        // Si ya se guardó una preferencia, usarla
        if (PlayerPrefs.HasKey("DobleSable"))
        {
            bool activo = PlayerPrefs.GetInt("DobleSable") == 1;
            dobleSableToggle.isOn = activo;
        }

        dobleSableToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    public void OnToggleChanged(bool isOn)
    {
        // Guardar en PlayerPrefs (1 = activado, 0 = desactivado)
        PlayerPrefs.SetInt("DobleSable", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
