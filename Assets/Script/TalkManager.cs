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
        talkData.Add(100,new string[] {"안녕!:0","하이루~:1","어서와~:2","한번 둘러보도록 해:3"});
        talkData.Add(200,new string[] {"ㅋㅋㅋㅋ:0","헬로:1","어쩌다가..:2","ㄴㄴ:3"});
        talkData.Add(300,new string[] {"평범한 나무상자이다."});
        talkData.Add(400,new string[] {"누군가 사용한 흔적이 있는 탁자이다."});
        //NPC Sprite
        talkSprite.Add(100,NPC_A);
        talkSprite.Add(200,NPC_B);

        //Quest Talk id = QuestID + NPC id;
        talkData.Add(10 + 100,new string[] {"어서와:0",
                                            "이 마을엔 놀라운 전설이 있다는데.:0",
                                            "오른쪽 호수 쪽에 루도에게 물어봐:1"});

        talkData.Add(11 + 200,new string[] {"너도 호수의 전설이 궁금한거야?:0",
                                            "그럼 일 하나만 해줄래?:0",
                                            "내 집 근처에 동전좀 주워줘:1"});
    }
    public string GetTalk(int id,int talkIndex){
        int key = id;
        // 만약 키가 존재하지 않으면, 퀘스트 관련 대화가 없다면 기본 키로 설정
        if (!talkData.ContainsKey(key)){
            key = talkData.ContainsKey(id - id % 10) ? id - id % 10 : id - id % 100;
        }
        // 출력할 대화가 없으면 null 반환
        if (talkIndex == talkData[key].Length) return null;
        return talkData[key][talkIndex];
    }
    public Sprite GetSprite(int id,int portaitIndex){
        return talkSprite[id][portaitIndex];
    }
}
