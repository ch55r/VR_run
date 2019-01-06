using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationcode : maincode
{

    Rigidbody rbody;
    public static Animator mator;
    BoxCollider col;
    float AccSpeed = 0; //애니메이션에 따른 이동여부
    string motion = ""; //현재 재생중인 이름을 받을 문자열
    bool WAIT =false;



    void Awake()//객체가 준비된 순간 실행, Start보다 빠르다, 리지드바디와 애니메이터를 가져온다.
    {
        rbody = GetComponent<Rigidbody>();
        mator = GetComponent<Animator>();
        col = GetComponent<BoxCollider>();

    }

        void FixedUpdate() // 키보드쪽을 입력받고, 캐릭터를 회전시킨다 (이동은 Onanimatormove에서)
    {

        mator.SetBool("MISS", MISS);
        mator.SetBool("SLIDE", SLIDE);
        mator.SetBool("JUMP", JUMP);
        mator.SetBool("WAIT", WAIT);
        mator.SetBool("WIN", WIN);

    }
    
    void OnAnimatorMove()//애니메이션 동작을 처리할때마다 실행
    {
        motion = CurrentAni(); //현재 모션을 받는다
        AnimeSwitching(); //모션에 따른 스크립트 실행
        Vector3 pos = transform.forward.normalized *AccSpeed * 2f * Time.fixedDeltaTime;
 //       if (Accel) pos *= 3f; //가속중인경우 3배 더 빠르게
        rbody.MovePosition(transform.position + pos);

    }
    string CurrentAni()//현재 애니메이션 이름을 받아온다
    {
        //애니메이터에 존재하는 모든 애니메이션 클립을 전체배열로 foreach문 실행
        foreach (AnimationClip clip in mator.runtimeAnimatorController.animationClips) 
            
            if (mator.GetCurrentAnimatorStateInfo(0).IsName(clip.name)) return clip.name.ToString();
        return null; //찾지못한경우 null반환
    }
    string NextAni()//다음 예정 애니메이션 이름을 받아온다
    {
        foreach (AnimationClip clip in mator.runtimeAnimatorController.animationClips)
            if (mator.GetNextAnimatorStateInfo(0).IsName(clip.name)) return clip.name.ToString();
        return "";
    }
    void AnimeSwitching()//모션 상태에 따른 제어 스크립트
    {
 //      Debug.Log(motion);
        switch (motion)
        {
            case "RUN00_F":     //달리기   
                runing = true;
                AccSpeed = 2;
                Col_ch(1);
                break;
            case "UMATOBI00":      //점프
                runing = false;
                AccSpeed = 1.5f;
                SLIDE = false;
                Col_ch(2);
                break;
            case "SLIDE00":     //슬라이딩
                runing = false;
                AccSpeed = 1.5f;
                JUMP = false;
                Col_ch(3);
                break;
            case "WAIT02":      //충돌
                AccSpeed = 0;
                runing = false;
                SLIDE = false;
                JUMP = false;
                MISS = false;
                Col_ch(1);
                break;
            case "WAIT00":      //완주
                SLIDE = false;
                runing = false;
                JUMP = false;
                AccSpeed = 0;
                Col_ch(1);
                break;
            case "WAIT04":
            case "WAIT03":
                runing = false;
                AccSpeed = 0;
                SLIDE = false;
                JUMP = false;
                MISS = false;
                Col_ch(1);
                break;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("닿았당~~");
        if (coll.tag=="장애물")
        {
            MISS = true;
        }
        if (coll.tag == "결승선")
        {
            WIN = true;
            mator.SetBool("WIN", true);
        }
    }

    void Col_ch(int n)      //애니메이션에 따른 캐릭터 콜라이더 변경
    {
        if (n == 1)
        {
            col.size = new Vector3(0.5421028f, 1.479388f, 0.1799774f);
            col.center = new Vector3(-0.004603207f, 0.7757155f, -0.01041508f);
        }
        else if (n == 2)
        {
            col.size = new Vector3(0.5421028f, 0.6573918f, 0.1799774f);
            col.center = new Vector3(-0.004603207f, 1.428418f, -0.01041508f);
        }
        else if(n==3)
        {
            col.size = new Vector3(0.5421028f, 0.9451215f, 0.1799774f);
            col.center = new Vector3(-0.004603207f, 0.5085822f, -0.01041508f);
        }
    }
    
}

