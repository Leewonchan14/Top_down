using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public QuestManager questManager;
    public TalkManager talkManager;
    public static GameManager instance;
    public Image portraitImg;

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
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkStr = talkManager.GetTalk(id+questTalkIndex,talkIndex);
        if(talkStr == null) {
            isAction=false;
            talkIndex=0;
            return;
        }
        if(isNPC){
            UI.ChatText.text = talkStr.Split(':')[0];
            portraitImg.color = new Color(1,1,1,1);
            portraitImg.sprite = talkManager.GetSprite(id,int.Parse(talkStr.Split(':')[1]));
        }else{
            UI.ChatText.text = talkStr;
            portraitImg.color = new Color(1,1,1,0);
        }
        isAction = true;
        talkIndex++;
    }
}
