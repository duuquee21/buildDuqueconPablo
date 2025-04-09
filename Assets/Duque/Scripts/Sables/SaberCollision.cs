using UnityEngine;

public class SaberCollision : MonoBehaviour
{
    public ParticleSystem hitEffect; // Efecto de partículas cuando se corta un cubo

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);  // Verificar colisión

        // Comprobamos si el objeto con el que colisionamos tiene el tag "Cube"
        if (other.CompareTag("Cube"))
        {
            // Si tienes un efecto de partículas, lo instancias
            if (hitEffect != null)
            {
                Instantiate(hitEffect, other.transform.position, Quaternion.identity);
            }

            
            

            // Destruye el cubo cuando sea golpeado
            Destroy(other.gameObject);

            FindAnyObjectByType<ScoreManager>().IncreaseScore();


        }
        else if (other.CompareTag("Bomba"))
        {
            // Destruye el cubo cuando sea golpeado
            Destroy(other.gameObject);

            FindAnyObjectByType<ScoreManager>().DecreaseScore();
        }
       
    }
    
}
