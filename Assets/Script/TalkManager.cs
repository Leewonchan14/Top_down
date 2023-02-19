using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int,string[]> talkData;
    Dictionary<int,Sprite[]> talkSprite;

    public Sprite[] NPC_A;
    public Sprite[] NPC_B;
    private void Awake() {
        talkData = new Dictionary<int, string[]>();
        talkSprite = new Dictionary<int, Sprite[]>();
        GeneratorData();
    }
    void GeneratorData(){
        //talkData
        //NPC A : 10 ; NPC B : 200
        //Box : 300 ; Desk : 400
        talkData.Add(100,new string[] {"안녕!:0","하이루~:1","어서와~:2","무슨일이야?:3"});
        talkData.Add(200,new string[] {"ㅋㅋㅋㅋ:0","헬로:1","어쩌다가..:2","ㄴㄴ:3"});
        talkData.Add(300,new string[] {"평범한 나무상자이다."});
        talkData.Add(400,new string[] {"누군가 사용한 흔적이 있는 탁자이다."});
        //NPC Sprite
        talkSprite.Add(100,NPC_A);
        talkSprite.Add(200,NPC_B);

        //Quest Talk id = QuestID + NPC id;
        talkData.Add(10 + 100,new string[] {"뭐야넌!:0",
                                            "소름끼쳐...:0",
                                            "한번둘러봐:1"});
    }
    public string GetTalk(int id,int talkIndex){
        if(talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
    public Sprite GetSprite(int id,int portaitIndex){
        return talkSprite[id][portaitIndex];
    }
}
