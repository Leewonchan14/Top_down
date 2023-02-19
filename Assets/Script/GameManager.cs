using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public static GameManager instance;

    public bool isAction;
    public int talkIndex;

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
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id,objData.isNPC);

        UI.ChatPanel.SetActive(isAction);
    }
    [System.Serializable]
    public class ui{
        public Text ChatText;
        public GameObject ChatPanel;
    }
    void Talk(int id, bool isNPC){
        string talkStr = talkManager.GetTalk(id,talkIndex);
        if(talkStr == null) {
            isAction=false;
            talkIndex=0;
            return;
        }
        if(isNPC){
            UI.ChatText.text = talkStr;
        }else{
            UI.ChatText.text = talkStr;
        }
        isAction = true;
        talkIndex++;
    }
}
