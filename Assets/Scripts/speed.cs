using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    private static int velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision) {
        GameObject.Find("Player").GetComponent<player>().velocity *=2;
        GameObject.Find("Player").GetComponent<player>().jump *=2;
        Destroy(GameObject.Find("speed"));

        
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }
}
