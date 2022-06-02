using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public int pace;  //한번에 이동하는 칸 수
    public int action;  //행동력
    private Animator animator;
    Rigidbody2D rigid;
    public bool moveA, moveD, moveW, moveS;  //좌 우 위 아래

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        moveA = true; moveD = true; moveS = true; moveW = true;

    }


    private void Update()
    {

        if (action > 0)  //행동력이 있을 경우 이동 가능
        {
            if (Input.GetKeyDown(KeyCode.A) && moveA == true)
            {
                animator.SetInteger("Direction", 3);
                transform.Translate(new Vector2(-1 * pace, 0));
                action--;
            }
            if (Input.GetKeyDown(KeyCode.D) && moveD == true)
            {
                animator.SetInteger("Direction", 2);
                transform.Translate(new Vector2(1 * pace, 0));
                action--;
            }
            if (Input.GetKeyDown(KeyCode.W) && moveW == true)
            {
                animator.SetInteger("Direction", 1);
                transform.Translate(new Vector2(0, 1 * pace));
                action--;
            }
            if (Input.GetKeyDown(KeyCode.S) && moveS == true)
            {
                animator.SetInteger("Direction", 0);
                transform.Translate(new Vector2(0, -1 * pace));
                action--;
            }
        }
        else  //행동력 0
        {
            //게임 종료

        }

    }


    private void FixedUpdate()
    {
        //움직일 수 있는 방향 체크
        int length = 2;
        Vector2 aVec = new Vector2(rigid.position.x - length, rigid.position.y);
        Debug.DrawRay(aVec, Vector3.left, new Color(0, 0, 1));
        RaycastHit2D rayHitA = Physics2D.Raycast(aVec, Vector3.left, 1, LayerMask.GetMask("Tile"));

        Vector2 dVec = new Vector2(rigid.position.x + length, rigid.position.y);
        Debug.DrawRay(dVec, Vector3.right, new Color(0, 0, 1));
        RaycastHit2D rayHitD = Physics2D.Raycast(dVec, Vector3.right, 1, LayerMask.GetMask("Tile"));

        Vector2 wVec = new Vector2(rigid.position.x, rigid.position.y + length);
        Debug.DrawRay(wVec, Vector3.up, new Color(0, 0, 1));
        RaycastHit2D rayHitW = Physics2D.Raycast(wVec, Vector3.up, 1, LayerMask.GetMask("Tile"));

        Vector2 sVec = new Vector2(rigid.position.x, rigid.position.y - length);
        Debug.DrawRay(sVec, Vector3.down, new Color(0, 0, 1));
        RaycastHit2D rayHitS = Physics2D.Raycast(sVec, Vector3.down, 1, LayerMask.GetMask("Tile"));


        if (rayHitA.collider != null)
        {
            if (rayHitA.distance < 0.5f)
                moveA = true;
        }
        else moveA = false;
        if (rayHitD.collider != null)
        {
            if (rayHitD.distance < 0.5f)
                moveD = true;
        }
        else moveD = false;
        if (rayHitW.collider != null)
        {
            if (rayHitW.distance < 0.5f)
                moveW = true;
        }
        else moveW = false;
        if (rayHitS.collider != null)
        {
            if (rayHitS.distance < 0.5f)
                moveS = true;
        }
        else moveS = false;
        /////////////////////////////////////////////////////////////
        

    }



    //오브젝트에 태그 적용 후 사용(오브젝트 감지해서 씬 변경하기)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            Debug.Log("on portal");
            //다른칸으로 이동

        }
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("on final");
            //게임 종료

        }
        if (collision.gameObject.tag == "Tree")
        {
            Debug.Log("on tree");
            //전투씬 불러오기
        }
        if (collision.gameObject.tag == "Treasure")
        {
            Debug.Log("on treasure chest");
            //보물상자

        }
        if (collision.gameObject.tag == "Grave")
        {
            Debug.Log("on grave");
            //무덤 위
        }
    }


}
