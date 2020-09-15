using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ballcode : MonoBehaviour
{
   
    public Rigidbody2D boll;
    public float jumpingforce;
    public Color purple, yellow, pink, blue;
    public string nowcolor;
    public SpriteRenderer artist;
    public GameObject balls;
    public Transform colorchanger;
    public TextMeshProUGUI skortext, highscore,score;
    public int skor = 0,tutucux=5,tutucuy=5,tutucuz=5,x=0,y=0,z=0,sayici;
    public GameObject[] objects;
    public Transform[] objeler,objelery,objelerz,objelerx,foward;
    public GameObject startpanel,endpanel;
    bool anan, c, a, b,d,f,e;
    public AudioSource jumpsound,takeit,explosion;
    
    void Start()
    {
        
        randomcolor();
        jumpingforce = 0;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        startpanel.SetActive(true);
        endpanel.SetActive(false);
        
       /* for (int i = 0; i < 6; i++)
        {
            objects[i].SetActive(true);
        }*/
    }

    void Update()
    {
        skortext.text = "Score : " + (int)skor;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            jumpsound.Play();
            boll.velocity = Vector2.up * jumpingforce;
        }


 
    }


    
    
    private void OnTriggerEnter2D(Collider2D touch)
    {
        Debug.Log("degdi");
        
        if (touch.tag != nowcolor && touch.tag != "colorchanger" && touch.tag != "passone" && touch.tag != "passtwo" && touch.tag != "passthree" && touch.tag != "first" && touch.tag != "second" && touch.tag != "third") 
        {
            Debug.Log("carpti");
            explosion.Play();
            GetComponent<ParticleSystem>().Play();
            artist.enabled = false;
            jumpingforce = 0;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Invoke("endscene", 1);
          
        }


        if (touch.tag == "colorchanger")
        {
            skor++;
            takeit.Play();
            colorchanger.position = new Vector3(colorchanger.position.x, colorchanger.position.y- 8, colorchanger.position.z);
            randomcolor();
        }

        if (touch.tag == "passone")
        {
            a = true;
            changebarriers();
        }
        if (touch.tag == "passtwo")
        {
            b = true; 

            changebarriers();
        

        }
        if (touch.tag == "passthree")
        {
            c = true;

            changebarriers();
        }

        if (touch.tag == "first")
        {
            d = true;

            fowardd();
        }
        if (touch.tag == "second")
        {
            e = true;

            fowardd();
        }
        if (touch.tag == "third")
        {
            f = true;

            fowardd();
        }




    }
        public void started()
        {

            jumpingforce = 2.50f;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            startpanel.SetActive(false);

        }

        void changebarriers()
    {
       

        if (a)
        {
            x = Random.Range(0, 5);
   
            Debug.Log("birinci");
            objeler[0].position = new Vector3(objeler[0].position.x, objeler[0].position.y-24, objeler[0].position.z);
            objelerx[x].position = new Vector3(foward[0].position.x- 3.627919f, foward[0].position.y+1.78698f, foward[0].position.z);

            a = false;
           

        }
        if (b)
        {
           y = Random.Range(0, 5);

            Debug.Log("ikinci");
            objeler[1].position = new Vector3(objeler[1].position.x, objeler[1].position.y - 24, objeler[1].position.z);
            objelery[y].position = new Vector3(foward[1].position.x- 0.5559194f, foward[1].position.y + 1.78698f, foward[1].position.z);

            b = false;
            
        }
        if (c)
        {
            z = Random.Range(0, 5);
         
            Debug.Log("üçüncü");
            objeler[2].position = new Vector3(objeler[2].position.x, objeler[2].position.y - 24, objeler[2].position.z);
            objelerz[z].position = new Vector3(foward[2].position.x- 3.627919f, foward[2].position.y + 1.78698f, foward[2].position.z);

            c = false;
           
        }

        
        

    }

    void fowardd()
    {
        if (d)
        {
            sayici++;
            foward[0].position = new Vector3(foward[0].position.x, foward[0].position.y - 24, foward[0].position.z);
            d = false;
        }
        if (e)
        {
            foward[1].position = new Vector3(foward[1].position.x, foward[1].position.y - 24, foward[1].position.z);
            e = false;
        }
        if (f)
        {
            foward[2].position = new Vector3(foward[2].position.x, foward[2].position.y - 24, foward[2].position.z);
            f = false;
          //  bacgroundone[0].position = new Vector3(bacgroundone[0].position.x, bacgroundone[0].position.y - 56.6f, bacgroundone[0].position.z);
        }
      //  if (sayici == 2) { bacgroundone[1].position = new Vector3(bacgroundone[1].position.x, bacgroundone[1].position.y - 56.6f, bacgroundone[1].position.z); }

    }
    void endscene()
    {
       // highscore.text = "High Score = "+(int)skor;
        score.text = "Score = " + (int)skor;
        tutucux = PlayerPrefs.GetInt("bestscore");
       
        if (skor < tutucux)
        {
            highscore.text = "High score : " + (int)tutucux;
        }
        else
        {
            tutucux = skor;
            PlayerPrefs.SetInt("bestscore", tutucux);
            highscore.text = "High score :" + (int)tutucux;
        }
        endpanel.SetActive(true);

    }

    public void restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);/*sahneyi etkinleştir ama şuan üzerinde çalıştığımız sahneyi*/
        Time.timeScale = 1;

    }

   
    void randomcolor()
    {
        int randomnumbers = Random.Range(0, 4);
        switch (randomnumbers)
        {
            case 0:
                nowcolor = "blue" ;
                artist.color = blue;
                break;
            case 1:
                nowcolor = "purple";
                artist.color = purple;
                break;
            case 2:
                nowcolor = "yellow";
                artist.color = yellow;
                break;
            case 3:
                nowcolor = "pink";
                artist.color = pink;
                break;
                //renkleri gelen int sayısına göre rastgele seç.
        }

    }

    /*DENENENLER
     * BU AMK yer değiştirmede aynı objeler one gittiği için sıkıntı oluyor
     * yeniden yaratmada destroy komutu bozuluyo
     * napim ben amk
     
     
     
     
     
     
     
     */




}
