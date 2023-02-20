using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    Dictionary<int,QuestData> questList;
    // Start is called before the first frame update
    private void Awake() {
        questList = new Dictionary<int, QuestData>();
        GenerteData();
    }
    void Start()
    {
        CheckQuest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerteData(){
        questList.Add(10,new QuestData("첫 마을방문",new int[] {100,200}));
        questList.Add(20,new QuestData("동전주워주기",new int[] {500,200}));
    }
    public int GetQuestTalkIndex(int Id){
        return questId+ questActionIndex;
    }
    public void CheckQuest(int id){
        //npc아이디와 퀘스트와 관련된 npc아이디가 같을때만 퀘스트가 진행됨
        if(id==questList[questId].npcId[questActionIndex]){
            questActionIndex++;
        }
        //퀘스트가 끝나면 다음 퀘스트로 변경
        if(questActionIndex==questList[questId].npcId.Length)
            NestQuest();
        Debug.Log(questList[questId].questName);
    }
    public void CheckQuest(){
        Debug.Log(questList[questId].questName);
    }
    void NestQuest(){
        questId += 10;
        questActionIndex = 0;
    }
}
