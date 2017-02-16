using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public Animator anim;
    public Rigidbody rbody;


    void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();   
    }
    void Update()
    {
        if (Input.GetKeyDown("3"))
        {
            anim.Play("WAIT03", -1, 0f);
        }
        if (Input.GetKeyDown("4"))
        {
            anim.Play("WAIT04", -1, 0f);
        }

        if (Input.GetKeyDown("f"))
        {
             anim.Play("DAMAGED01", -1, 0f); 
        } 
    }
}

