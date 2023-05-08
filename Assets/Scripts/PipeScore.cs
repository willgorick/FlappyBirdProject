using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScore : MonoBehaviour
{

    public MetaScript meta;

    // Start is called before the first frame update
    void Start()
    {
        meta = GameObject.FindGameObjectWithTag("Meta").GetComponent<MetaScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3 && !meta.gameIsOver) {
            meta.addScore(1);
        }
    }
}
