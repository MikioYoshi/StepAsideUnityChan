﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody myRigitbody;
    private float velocityZ = 16f;
    private float velocityX = 10f;
    private float velocityY = 10f;
    private float movableRange = 3.4f;


    // Start is called before the first frame update
    void Start()
    {
        this.myAnimator = GetComponent<Animator>();

        this.myAnimator.SetFloat ("Speed", 1);

        this.myRigitbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputVelocityX = 0;
        float inputVelocityY = 0;

        if (Input.GetKey(KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
        {
            inputVelocityX = -this.velocityX;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.movableRange > this.transform.position.x)
        {
            inputVelocityX = this.velocityX;
        }

        if (Input.GetKeyDown(KeyCode.Space) && -this.transform.position.y < 0.5)
        {
            this.myAnimator.SetBool("Jump", true);
            inputVelocityY = this.velocityY;
        }
        else
        {
            inputVelocityY = this.myRigitbody.velocity.y;
        }

        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName ("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }


        this.myRigitbody.velocity = new Vector3(inputVelocityX, inputVelocityY, this.velocityZ);
    }
}
