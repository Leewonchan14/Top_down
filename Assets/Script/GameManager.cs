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
    public Sprite preSprite;

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
        UI.ChatPanel.SetBool("isShow",isAction);
    }
    [System.Serializable]
    public class ui{
        public Typing ChatText;
        public Animator ChatPanel;
        public Animator Portrait;
    }
    void Talk(int id, bool isNPC){
        //현재 퀘스트 아이디 가져오기
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        //퀘스트아이디와 오브젝트아이디를 더한KEY로 대화 가져오기
        string talkStr = talkManager.GetTalk(id+questTalkIndex,talkIndex);
        //대화가 끝났다면 액션 false, 토크인덱스를 0으로 초기화 (처음대화부터...)
        //대사가 끝나면 체크퀘스트로 퀘스트 액션 인덱스를 증가시킨다.
        if(talkStr == null) {
            isAction=false;
            talkIndex=0;
            questManager.CheckQuest(id);
            return;
        }
        //NPC라면 NPC초상화를 같이 설정
        if(isNPC){
            UI.ChatText.GetComponent<Typing>().SetMsg(talkStr.Split(':')[0]);
            portraitImg.color = new Color(1,1,1,1);
            portraitImg.sprite = talkManager.GetSprite(id,int.Parse(talkStr.Split(':')[1]));
            if(preSprite != portraitImg.sprite){
                UI.Portrait.SetTrigger("isChange");
                preSprite = portraitImg.sprite;
            }
            
        } //NPC가 아니라면 ( 사물 )
        else{
            UI.ChatText.SetMsg(talkStr);
            portraitImg.color = new Color(1,1,1,0);
        }
        isAction = true;
        talkIndex++;
    }
}
