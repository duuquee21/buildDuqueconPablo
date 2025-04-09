using UnityEngine;

public class SaberController : MonoBehaviour
{
    public Transform handTransform; // La transformación del controlador de la mano
    public float saberLength = 1.0f; // Longitud del sable
    public GameObject saberPrefab; // Prefab del sable (puede ser una barra o un modelo 3D)

    private GameObject saberInstance; // Instancia del sable

    void Start()
    {
        // Instancia el sable al inicio
        saberInstance = Instantiate(saberPrefab, handTransform.position, Quaternion.identity);
    }

    void Update()
    {
        // Actualiza la posición y rotación del sable para que siga la mano
        saberInstance.transform.position = handTransform.position;
        saberInstance.transform.rotation = handTransform.rotation;

        // Ajustar la longitud del sable si es necesario
        saberInstance.transform.localScale = new Vector3(saberLength, saberLength, saberLength);
    }
}