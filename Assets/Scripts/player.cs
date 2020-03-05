using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int velocity = 5;
    public int jump =500;
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
        if(collision.gameObject.tag == "Surface" || collision.gameObject.tag == "Playable"  && inAir){
            inAir=false;

        }
        if(collision.gameObject.name=="powerUp"){
            velocity*=2;
            jump*=2;
            Destroy(collision.gameObject);
        }
        
    }
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);

        if(Ob.name == "Player")
        {
            transform.Translate(move * velocity * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15F);
        }

        if(Input.GetKeyDown(KeyCode.RightShift) && !inAir){
            rb.AddForce(new Vector3(0,jump,0));
            inAir=true;
        }
    }
}
