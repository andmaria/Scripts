using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour {

    private Animation anim;
    private Transform playerTransform;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>();    
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();    
    }

    public void JumpRight()
    {
        if (!(anim.isPlaying))     
        {
            if (playerTransform.position.x == -3f)       
                anim.Play("SecondRight");      

            else if (playerTransform.position.x == 0f)     
                anim.Play("ThirdRight");        
        }
    }

    public void JumpLeft()
    {
        if (!(anim.isPlaying))      
        {
            if (playerTransform.position.x == 0f)      
                anim.Play("FirstLeft");      

            else if (playerTransform.position.x == 3f)     
                anim.Play("SecondLeft");        
        }
    }
}
