﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int move =1;
    public int jump =100;
    public GameObject Ob;
    bool inAir=false;
    Rigidbody rb;
    CharacterController characterController;
    private Vector3 moveDirection = new Vector3(0,0,0);
    Vector3 up = new Vector3(0,0,1);
    Vector3 down = new Vector3(0,0,-1);
    Vector3 left = new Vector3(-1,0,0);
    Vector3 right = new Vector3(1,0,0);
    Vector3 zero = new Vector3(0,0,0);
    float gravity=10;



    // Start is called before the first frame update
    void Start()
    {
        rb =Ob.GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();

        //rb.AddForce(new Vector3(0,500,0));
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name=="Ground" || 
        collision.gameObject.name=="Player"||
        collision.gameObject.name=="enemy"  && inAir){
            inAir=false;

        }
        if(collision.gameObject.name=="powerUp"){
            move*=2;
            jump*=2;
            Destroy(collision.gameObject);
        }
        
    }
    void Update()
    {

        if(Ob.name=="Player"){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                //rb.AddForce(new Vector3(0,0,move));
                moveDirection =up*move;
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow)){  
                moveDirection =left*move;
            }
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                moveDirection =right*move;
            }
            if(Input.GetKeyDown(KeyCode.DownArrow)){
                moveDirection =down*move;
            }
            if(Input.GetKeyDown(KeyCode.RightShift) && !inAir){
                rb.AddForce(new Vector3(0,jump,0));
                inAir=true;
            }

            if(Input.GetKeyUp(KeyCode.UpArrow)){
                moveDirection = zero;
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow)){  
                moveDirection = zero;
            }
            if(Input.GetKeyUp(KeyCode.RightArrow)){
                moveDirection = zero;
            }
            if(Input.GetKeyUp(KeyCode.DownArrow)){
                moveDirection = zero;
            }
            
        }

        else if(Ob.name=="enemy"){
            if(Input.GetKeyDown(KeyCode.W)){
                rb.AddForce(new Vector3(0,0,move));
            }
            else if(Input.GetKeyDown(KeyCode.A)){
                rb.AddForce(new Vector3(-move,0,0));
            }
            else if(Input.GetKeyDown(KeyCode.D)){
                rb.AddForce(new Vector3(move,0,0));
            }
            else if(Input.GetKeyDown(KeyCode.S)){
                rb.AddForce(new Vector3(0,0,-move));
            }
            else if(Input.GetKeyDown(KeyCode.LeftShift) && !inAir){
                rb.AddForce(new Vector3(0,jump,0));
                inAir=true;

            }
        }
        moveDirection.y -=gravity *Time.deltaTime;
        characterController.Move( moveDirection*Time.deltaTime );

    }
}
