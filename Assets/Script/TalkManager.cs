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
        talkData.Add(1,new string[] {"안녕!","하이루~","어서와~","무슨일이야?"});
        talkData.Add(2,new string[] {"ㅋㅋㅋㅋ","헬로"});
        talkData.Add(3,new string[] {"평범한 나무상자이다."});
        talkData.Add(4,new string[] {"누군가 사용한 흔적이 있는 탁자이다."});
        //NPC Sprite
        talkSprite.Add(100,NPC_A);
        talkSprite.Add(200,NPC_B);

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
