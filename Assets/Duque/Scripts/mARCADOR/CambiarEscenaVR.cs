using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class CambiarEscenaVR : MonoBehaviour
{
    [SerializeField] private string escenaDestino; 

    private void Start()
    {
        
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(CambiarEscena);
        }
    }

    private void CambiarEscena(SelectEnterEventArgs args)
    {
        SceneManager.LoadScene(escenaDestino);
    }
}
