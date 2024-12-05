using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController2d : MonoBehaviour
{//Referencia a las antiguas inputs
    float horInput;
    float verInput;


    //Referencias generales 
    [SerializeField] Rigidbody2D playerRb; //Ref al rigidbody del player

    [Header("Movement Parameters")]
    public float speed;

    [Header("Jump Parameters")]
    public float jumpForce;

    [SerializeField] bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        //Autoreferecniar componentes: Nombre de variable = GetComponent()
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxis("Horizontal");
        Jump();
       
    }
    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        playerRb.velocity = new Vector3(horInput * speed, playerRb.velocity.y, 0);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }
        
}