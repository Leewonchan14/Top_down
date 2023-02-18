using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    Vector2 inputVec;
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
    }
    void FixedUpdate() {
        rigid.velocity = inputVec*speed;
    }
    void OnMove(InputValue value){
        inputVec = value.Get<Vector2>();
    }
}
