using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Prefab del cubo proyectil
    public GameObject bomba;
    public Transform playerTransform; // Transform del jugador (c�mara o punto de referencia)
    public float spawnDistance = 10f; // Distancia fija desde el jugador
    public float spawnIntervalMin = 2f; // Tiempo m�nimo entre instancias
    public float spawnIntervalMax = 3f; // Tiempo m�ximo entre instancias
    public float destinationOffsetRange = 2f; // Rango para variar la direcci�n del cubo

    [Range(0f, 1f)]
    public float probabilidaddebomba = 0.3f;


    void Start()
    {
        // Inicia el ciclo de instanciaci�n
        StartCoroutine(SpawnCubes());
    }

    IEnumerator SpawnCubes()
    {
        while (true) // Ciclo infinito para instanciar cubos
        {
            // Calcula un offset aleatorio para variar la direcci�n
            float offset = Random.Range(-destinationOffsetRange, destinationOffsetRange);

            // Calcula la posici�n de instanciaci�n
            Vector3 spawnPos = playerTransform.position + (playerTransform.forward * spawnDistance);
            spawnPos += playerTransform.right * offset;

            // Asegura que el cubo spawnee a una altura fija
            spawnPos.y = 1f; // Altura fija desde el suelo
            
            GameObject instPrefab = (Random.value < probabilidaddebomba) ? bomba : cubePrefab;
            // Instancia el cubo
            GameObject cube = Instantiate(instPrefab, spawnPos, Quaternion.identity);

            // Le da una direcci�n hacia el jugador
            cube.AddComponent<MoveTowardsPlayers>().Initialize(playerTransform.position, offset);

            // Espera un tiempo aleatorio antes de instanciar el siguiente cubo
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));

           

        }
    }

}
