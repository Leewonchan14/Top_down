using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    Dictionary<int,QuestData> questList;
    // Start is called before the first frame update
    private void Awake() {
        questList = new Dictionary<int, QuestData>();
        GenerteData();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerteData(){
        questList.Add(10,new QuestData("첫 마을방문",new int[] {100,200}));
    }
    public int GetQuestTalkIndex(int Id){
        return questId;
    }
}
