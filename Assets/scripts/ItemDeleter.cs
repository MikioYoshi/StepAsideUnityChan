using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeleter : MonoBehaviour
{
    //private GameObject unitychan;

    // Start is called before the first frame update
    void Start()
    {
        //this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //MainCameraと各PrehabのZ軸座標を比較
        if (transform.position.z <= Camera.main.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}