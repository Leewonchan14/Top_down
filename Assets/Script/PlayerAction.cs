using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private float h;
    private float v;
    bool isHorizonMove;
    [Header("#PlayerInfo")]
    public float speed;
    [Header("#Player_Scanner")]
    public RaycastHit2D front_Hit;
    public RaycastHit2D Box_Hit;

    public Vec vec = new Vec();
    public Scan scan = new Scan();
    public Component compo = new Component();
    
    // Start is called before the first frame update
    private void Awake() {
        compo.rigid = GetComponent<Rigidbody2D>();
        compo.anim = GetComponent<Animator>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        DirCheck();
        AnimCheck();
        if(Input.GetButtonDown("Jump")){
            Debug.Log(scan.Object);
        }
        FrontCheck();
    }
    void FixedUpdate() {
        //십자이동 구현
        vec.input = isHorizonMove?Vector2.right*h:Vector2.up*v;
        compo.rigid.velocity = vec.input*speed;
    }
    void DirCheck(){
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");


        //수직눌리거나 || 수평양방향이 눌리고있을때 한 방향이 떼질때 
        if(vDown || (hUp&&h==0)) {isHorizonMove = false;}
        else if(hDown || (vUp&&v==0)) {isHorizonMove = true;}

        if(vec.input != Vector2.zero) vec.dir = vec.input;
    }
    private void LateUpdate() {
        
    }
    void AnimCheck(){
        compo.anim.SetInteger("HAxisRaw",(int)vec.input.x);
        compo.anim.SetInteger("VAxisRaw",(int)vec.input.y);
    }
    void FrontCheck(){
        float distance = vec.dir.x==0?0.5f:0.4f;
        // front_Hit = Physics2D.Raycast(transform.position, vec.dir, distance, scan.Layer);
        // scan.Object = front_Hit?front_Hit.collider.gameObject:null;
        front_Hit = Physics2D.BoxCast(transform.position, transform.lossyScale/2, 0,vec.dir,distance, scan.Layer);
        scan.Object = front_Hit?front_Hit.collider.gameObject:null;
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        float distance = vec.dir.x==0?0.5f:0.4f;
        //그릴시작점, 방향*거리
        // Gizmos.DrawRay(transform.position, Vector3 * 50.0f);
        //시작점, 사이즈
        Gizmos.DrawWireCube(transform.position + new Vector3(vec.dir.x,vec.dir.y,0)*distance, transform.lossyScale/2);
    }
}
[System.Serializable]
public class Vec{
    public Vector2 input;
    public Vector2 dir;
}

[System.Serializable]
public class Scan{
    public LayerMask Layer;
    public GameObject Object;
}
[System.Serializable]
public class Component{
    public Rigidbody2D rigid;
    public Animator anim;
}