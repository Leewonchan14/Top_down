using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isAction;

    public ui UI = new ui();
    // Start is called before the first frame update
    private void Awake() {
        instance = this;
        isAction = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Action(GameObject scanObject){
        //대화창이 꺼져있었다면
        if(isAction == false){
            UI.ChatText.text = string.Format("This is {0}",scanObject.name);
        }
        isAction = !isAction;
        UI.ChatPanel.SetActive(isAction);
    }
    [System.Serializable]
    public class ui{
        public Text ChatText;
        public GameObject ChatPanel;
    }
}
