using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int velocity = 5;
    public int jump =500;
    GameObject Ob1;
    GameObject Ob2;
    bool inAir=false;
    public bool isOb1=true;
    Rigidbody rb1;
    Rigidbody rb2;

    // Start is called before the first frame update
    void Start()
    {
        Ob1 = GameObject.Find("Player");
        Ob2 = GameObject.Find("enemy");
        rb1=  Ob1.GetComponent<Rigidbody>();
        rb2=  Ob2.GetComponent<Rigidbody>();




    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Surface" || collision.gameObject.tag == "Playable"  && inAir){
            inAir=false;

        }
        
    }
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            isOb1=!isOb1;

        }

        if(isOb1 )
        {
            Ob1.transform.Translate(move * velocity * Time.deltaTime, Space.World);
            if(move!=Vector3.zero){
                Ob1.transform.rotation = Quaternion.Slerp(Ob1.transform.rotation, Quaternion.LookRotation(move), 0.15F);

            }
       }
       else if(!isOb1 )
        {
            Ob2.transform.Translate(move * velocity * Time.deltaTime, Space.World);
            if(move!=Vector3.zero){
                Ob2.transform.rotation = Quaternion.Slerp(Ob2.transform.rotation, Quaternion.LookRotation(move), 0.15F);

            }
       }

        if(Input.GetKeyDown(KeyCode.RightShift) && !inAir){
            if(isOb1){
                rb1.AddForce(new Vector3(0,jump,0));
                inAir=true;
            }
            else if(!isOb1){
                rb2.AddForce(new Vector3(0,jump,0));
                inAir=true;
            }
        }
    }
}
