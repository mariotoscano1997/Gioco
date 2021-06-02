using System;
using UnityEngine;
using UnityEngine.Audio;

public  class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    public bool isMute;
    public static AudioManager istance;
    void Awake(){

        if(istance==null){
            istance=this;
        }            
        else 
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        if(!isMute)
            foreach(Sound s in sounds){
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip= s.clip;
                s.source.volume=s.volume;
                s.source.pitch=s.pitch;
            }

    }
    public AudioManager getInstance(){
        return istance;
    }
    // Start is called before the first frame update
    void Start()
    {        
            Play("MainTheme");     
    }
    public void MuteAllSound(){
       foreach(Sound s in sounds){

                s.source.volume=0;
            }
    }
    public void PlayAllSound(){
         foreach(Sound s in sounds){

                s.source.volume=s.volume;
            }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(string name){
        string mute=PlayerPrefs.GetString("Sound");
        print("il valore di Mute è :"+ mute);
        
        Sound s= Array.Find(sounds, sound=>sound.name==name);
        if(s==null)
            return;
        if(mute=="False"){
            s.source.volume=0;
        }        
        s.source.Play();
    }
}
