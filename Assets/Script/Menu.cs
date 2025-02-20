using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    Button titleBtn;
    void Awake()
    {
        StartCoroutine(InitMenu());
        titleBtn=GameObject.Find("title").GetComponent<Button>();
        titleBtn.onClick.AddListener(()=>{
            SceneMove.LoadScene(Scenes.Title);
        });
    }

    IEnumerator InitMenu()
    {
        // Session.setRows() 코루틴이 끝날 때까지 대기
        yield return StartCoroutine(Session.setRows());
        // 데이터가 준비된 후 실행
        for (int i = 0; i <= Session.maxLevel && i <= Session.level; i++)
        {
            MenuBtn btn = Instantiate<MenuBtn>(Resources.Load<MenuBtn>("btn"), transform);
            btn.num = i;
        }
    }
}
