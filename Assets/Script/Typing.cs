using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Typing : MonoBehaviour
{
    Text myText;
    public GameObject myArrow;
    // Start is called before the first frame update
    public string targetMsg;
    public float CharPerSeconds;
    int index;
    public void SetMsg(string Msg)
    {
        targetMsg = Msg;
        EffectStart();
    }
    void EffectStart(){
        myArrow.SetActive(false);
        index = 0;
        myText.text="";
        Effecting();
    }
    void Effecting(){
        if(targetMsg.Length == index){
            EffectEnd();
            return;
        }
        myText.text += targetMsg[index];
        index++;
        Invoke("Effecting",CharPerSeconds);
    }
    public void EffectEnd(){
        myText.text = targetMsg;
        myArrow.SetActive(true);
    }
    void Awake(){
        myText = GetComponent<Text>();
    }
    void Start(){
        
    }
}
