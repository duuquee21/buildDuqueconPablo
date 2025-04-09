using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawners : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform spawnPoint
        ;
    public float spawnInterval = 2f;

    public float cubeSpeed = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCube), 0f, spawnInterval);
    }

    private void SpawnCube()
    {
        Debug.Log("Generando un cubo"); // Esto confirmará si el método se está ejecutando
        GameObject newCube = Instantiate(cubePrefab, spawnPoint.position, Quaternion.identity);

        CubeMover mover = newCube.GetComponent<CubeMover>();
        if (mover != null)
        {
            mover.speed = cubeSpeed;
        }
    }

}
