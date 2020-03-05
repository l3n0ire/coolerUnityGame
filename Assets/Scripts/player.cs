using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int move =100;
    public int jump =100;
    public GameObject Ob;
    bool inAir=false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb =Ob.GetComponent<Rigidbody>();

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
                rb.AddForce(new Vector3(0,0,move));
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow)){
                rb.AddForce(new Vector3(-move,0,0));
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow)){
                rb.AddForce(new Vector3(move,0,0));
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow)){
                rb.AddForce(new Vector3(0,0,-move));
            }
            else if(Input.GetKeyDown(KeyCode.RightShift) && !inAir){
                rb.AddForce(new Vector3(0,jump,0));
                inAir=true;
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
    }
}
