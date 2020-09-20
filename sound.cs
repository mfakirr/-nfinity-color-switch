using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sound : MonoBehaviour
{
    public bool soundon=false, soundoff=false;
    public GameObject soundonline, soundoffline,music ;
    public AudioSource musicc;
 
    private void Start()
    {
        soundoffline.SetActive(false); soundonline.SetActive(true);
        musicc.Play();//backgroun music
    }
    void Update()
    {
        //for sound on off control
        if (soundoff || PlayerPrefs.GetInt("soundcontrol") == 1)
        {//music on
            //it has "or" because when it is playing again, remember what station it is
            musicc.mute = false;DontDestroyOnLoad(music);//for music continue next scene
            soundoffline.SetActive(false); soundonline.SetActive(true); soundoff = false; Debug.Log("sounoff");
         
        }
        if (soundon || PlayerPrefs.GetInt("soundcontrol")==0)
        {//music off

            musicc.mute = true;
            soundoffline.SetActive(true);soundonline.SetActive(false); soundon = false;Debug.Log("sounon"); 
        
        }

    }

    public void soundof()
    {//button click music on
        PlayerPrefs.SetInt("soundcontrol", 1);
        soundoff = true;
    }
    public void soundonn()
    {
        PlayerPrefs.SetInt("soundcontrol", 0);
        soundon = true;
    } }
