using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 3;
    public float timer = 0;
    public float heightOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > spawnRate)
        {
            spawnPipe();
            timer = 0;
        }
        else 
        {
            timer = timer + Time.deltaTime;
        }
    }

    void spawnPipe()
    {
        float lowPoint = transform.position.y - heightOffset;
        float highPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowPoint, highPoint), 0), transform.rotation);
    }
}
