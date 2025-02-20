using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    Text result;
    Button nextLevel, menu;
    AudioSource audio;
    void Start()
    {
        result = GetComponent<Text>();
        audio=GetComponent<AudioSource>();
        nextLevel = GameObject.Find("nextLevel").GetComponent<Button>();
        menu = GameObject.Find("menu").GetComponent<Button>();
        result.text = Session.isSuccess ? "해설\n" + Session.explanation : "오답";
        result.fontSize = Session.isSuccess ? 50 : 200;
        result.color = Session.isSuccess ? Color.black : Color.red;
        //정답이면서 현제 다음 스테이지를 오픈해도 되는지 구하고 더함              
        Session.level += Convert.ToInt32(Session.isSuccess && Session.level == Session.selectLevel);
        //마지막 스테이지인지 판단하여 버튼을 활성/비활성화함
        nextLevel.gameObject.SetActive(Session.selectLevel + 1 < Session.maxLevel);

        //다음 스테이지로 가는 버튼이 활성화 되면 기능을 넣어줌
        if (nextLevel.gameObject.activeSelf)
        {
            nextLevel.transform.GetChild(0).GetComponent<Text>().text=Session.isSuccess?"다음 레벨로": "다시하기";
            nextLevel.onClick.AddListener(()=>{
                Session.selectLevel+=Convert.ToInt32(Session.isSuccess);
                SceneMove.LoadScene(Scenes.Game);
            });
        }
        menu.onClick.AddListener(() =>
        {
            SceneMove.LoadScene(Scenes.Menu);
        });
        audio.clip=Resources.Load<AudioClip>(Session.isSuccess ? "success":"fail");
        audio.Play();
    }

    void Update()
    {

    }
}
