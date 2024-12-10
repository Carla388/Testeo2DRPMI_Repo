using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem; //Librer�a para que funcione el New Input System

public class PlayerController2d : MonoBehaviour
{


    //Referencias generales 
    [SerializeField] Rigidbody2D playerRb; //Ref al rigidbody del player
    [SerializeField] PlayerInput playerInput; //Ref al gestor del input del jugador 

    [Header("Movement Parameters")]
    private Vector2 moveInput; //Almac�n de Input del Player
    public float speed;

    [Header("Jump Parameters")]
    public float jumpForce;

    [SerializeField] bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        //Autoreferecniar componentes: Nombre de variable = GetComponent()
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        playerRb.velocity = new Vector3(moveInput.x * speed, playerRb.velocity.y, 0);
    }
   

    #region Input Events 
    //Para crear un evento:
    //Se define PUBLIC sin tipo de dato (void) y con una referencia al input ( Callback.Context)
    public void HandleMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }


  
    }




    #endregion








}
