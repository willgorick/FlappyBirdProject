using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdBody;
    public float flapStrength;
    public MetaScript meta;

    [SerializeField]
    private InputActionReference jump;

    private void OnEnable() 
    {
        jump.action.performed += Jump;
    }

    private void OnDisable()
    {
        jump.action.performed -= Jump;   
    }

    public void Jump(InputAction.CallbackContext obj) 
    {
        if (!meta.gameIsOver)
        {
            birdBody.velocity = Vector2.up * flapStrength;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        meta.gameOver();
        meta.gameIsOver = true;
    }
}
