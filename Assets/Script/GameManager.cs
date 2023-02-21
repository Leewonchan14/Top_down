using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public QuestManager questManager;
    public TalkManager talkManager;
    public static GameManager instance;
    public Image portraitImg;
    Sprite preSprite;

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
        GameLoad();
        questManager.CheckQuest(UI.questName);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")){
            UI.menuSet.SetActive(UI.menuSet.activeSelf?false:true);
        }
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
        public GameObject menuSet;
        public TextMeshProUGUI questName;
    }
    void Talk(int id, bool isNPC){
        //현재 퀘스트 아이디 가져오기
        int questTalkIndex = 0;
        //퀘스트아이디와 오브젝트아이디를 더한KEY로 대화 가져오기
        string talkStr = "";

        //애니메이션 중이면 안넘어감
        if(UI.ChatText.isAnim){
            UI.ChatText.SetMsg();
            return;
        }
        else{
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkStr = talkManager.GetTalk(id+questTalkIndex,talkIndex);
        }
        
        //대화가 끝났다면 액션 false, 토크인덱스를 0으로 초기화 (처음대화부터...)
        //대사가 끝나면 체크퀘스트로 퀘스트 액션 인덱스를 증가시킨다.
        if(talkStr == null) {
            isAction=false;
            talkIndex=0;
            questManager.CheckQuest(id,UI.questName);
            return;
        }
        //NPC라면 NPC초상화를 같이 설정
        if(isNPC){
            UI.ChatText.SetMsg(talkStr.Split(':')[0]);
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
    public void GameSave(){
        PlayerPrefs.SetFloat("PlayerX",player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY",player.transform.position.y);
        PlayerPrefs.SetFloat("QuestId",questManager.questId);
        PlayerPrefs.SetFloat("QuestActionIndex",questManager.questActionIndex);
        PlayerPrefs.Save();
    }
    public void GameLoad(){
        if(!PlayerPrefs.HasKey("PlayerX")) return;
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        float id = PlayerPrefs.GetFloat("QuestId");
        float Index = PlayerPrefs.GetFloat("QuestActionIndex");
        player.transform.position = new Vector3(x,y,0);
        questManager.questId = (int)id;
        questManager.questActionIndex = (int)Index;
    }
    public void ExitGame(){
        Application.Quit();
    }
}
