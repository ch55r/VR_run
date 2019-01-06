using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracode : maincode
{
    public Camera cencam1;
    public Camera leftcam1;
    public Camera rightcam1;
    public Camera cencam2;
    public Camera leftcam2;
    public Camera rightcam2;
    /*    GameObject leftcam1;
        GameObject rightcam1;
        GameObject cencam2;
        GameObject leftcam2;
        GameObject rightcam2;*/
    // Use this for initialization
    void Start()

    {

/*        cencam1 = GameObject.FindWithTag("cen1");
        leftcam1 = GameObject.FindWithTag("left1");
        rightcam1 = GameObject.FindWithTag("right1");
        cencam2 = GameObject.FindWithTag("cen2");
        leftcam2 = GameObject.FindWithTag("left2");
        rightcam2 = GameObject.FindWithTag("right2");*/




    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (WIN)

        {
            cencam1.depth = 0;
            leftcam1.depth = 0;
            rightcam1.depth = 0;
            cencam2.depth = 1;
            leftcam2.depth = 1;
            rightcam2.depth = 1;
        }
        else
        {
            cencam1.depth = 1;
            leftcam1.depth = 1;
            rightcam1.depth = 1;
            cencam2.depth = 0;
            leftcam2.depth = 0;
            rightcam2.depth = 0;



        }
    }
}
