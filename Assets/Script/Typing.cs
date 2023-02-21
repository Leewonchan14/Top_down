using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Typing : MonoBehaviour
{
    Text myText;
    AudioSource audioSorce;
    public GameObject myArrow;
    public bool isAnim;
    // Start is called before the first frame update
    public string targetMsg;
    public float CharPerSeconds;
    int index;
    public void SetMsg(string Msg)
    {
        targetMsg = Msg;
        EffectStart();
    }
    public void SetMsg(){
        CancelInvoke();
        EffectEnd();
    }
    void EffectStart(){
        myArrow.SetActive(false);
        index = 0;
        myText.text="";
        isAnim = true;
        Effecting();
    }
    void Effecting(){
        if(targetMsg.Length == index){
            EffectEnd();
            return;
        }
        myText.text += targetMsg[index];
        audioSorce.Play();
        index++;
        Invoke("Effecting",CharPerSeconds);
    }
    public void EffectEnd(){
        isAnim = false;
        myText.text = targetMsg;
        myArrow.SetActive(true);
    }
    void Awake(){
        myText = GetComponent<Text>();
        audioSorce = GetComponent<AudioSource>();
    }
    void Start(){
        
    }
}
