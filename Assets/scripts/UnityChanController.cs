using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody myRigitbody;
    private float velocityZ = 16f;
    private float velocityX = 10f;
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

        if (Input.GetKey (KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
        {
            inputVelocityX = -this.velocityX;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.movableRange > this.transform.position.x)
        {
            inputVelocityX = this.velocityX;
        }


        this.myRigitbody.velocity = new Vector3(inputVelocityX, 0, this.velocityZ);
    }
}
