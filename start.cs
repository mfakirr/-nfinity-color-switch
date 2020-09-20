using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class start : MonoBehaviour
{
    public AudioSource startbutton;
    
    // Start is called before the first frame update

    public void started ()
        
        {
        if (PlayerPrefs.GetInt("soundcontrol") == 1)
        {//start button  music
            startbutton.mute = false; 
        }
        else { startbutton.mute = true;  }
        
        startbutton.Play();
        SceneManager.LoadScene(1);//load game scene
    }

   
}
 
