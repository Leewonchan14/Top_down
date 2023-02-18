using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float h;
    public float v;
    public float speed;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate() {
        rigid.velocity = new Vector2(h,v)*speed;
    }
}
