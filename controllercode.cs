using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controllercode : maincode
{

    // Update is called once per frame
    void FixedUpdate () {
        
        if (OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            WIN = false;
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)|| Input.GetKeyDown(KeyCode.W))
        {
            JUMP = true;
        }
        else JUMP = false;
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad)|| Input.GetKeyDown(KeyCode.S))
        {
            SLIDE = true;
        }
        else SLIDE = false;

//        mator.SetBool("JUMP", JUMP);
//        mator.SetBool("SLIDE", SLIDE);
    }
}
