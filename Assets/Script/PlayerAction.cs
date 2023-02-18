using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    private float h;
    private float v;
    public bool isChange;
    public bool isHorizonMove;
    public float speed;
    public Vector2 inputVec;

    Vector2 curVec;
    Rigidbody2D rigid;
    Animator anim;
    // Start is called before the first frame update
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        curVec = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        HorizonCheck();
        AnimCheck();
    }
    void FixedUpdate() {
        //십자이동 구현
        inputVec = isHorizonMove?Vector2.right*h:Vector2.up*v;
        rigid.velocity = inputVec*speed;
    }
    void HorizonCheck(){
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");
        //수직눌리거나 || 수평양방향이 눌리고있을때 한 방향이 떼질때 
        if(vDown || (hUp&&h==0)) {isHorizonMove = false;}
        else if(hDown || (vUp&&v==0)) {isHorizonMove = true;}
    }
    private void LateUpdate() {
        
    }
    void AnimCheck(){
        anim.SetInteger("HAxisRaw",(int)inputVec.x);
        anim.SetInteger("VAxisRaw",(int)inputVec.y);
    }
}
