using System;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    Text question;
    InputField answer;
    Button submit,menu,hint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        question=GameObject.Find("question").transform.GetChild(0).GetComponent<Text>();
        answer=GameObject.Find("answer").GetComponent<InputField>();
        submit=GameObject.Find("submit").GetComponent<Button>();
        menu=GameObject.Find("menu").GetComponent<Button>();
        hint=GameObject.Find("hint").GetComponent<Button>();
        menu.onClick.AddListener(()=>{
            SceneMove.LoadScene(Scenes.Menu);
        });
        submit.onClick.AddListener(()=>{
            Session.setSuccess(answer.text);
            SceneMove.LoadScene(Scenes.Result);
        });
        question.text=Session.question;


    }

    // Update is called once per frame
    void Update()
    {

    }
}
