using UnityEngine;
using UnityEngine.UI;

public class MenuBtn : MonoBehaviour
{
    int _num;
    public int num{
        set{
            _num=value;
            text.text=(++value)+"";
        }
        get{
            return _num;
        }
    }
    Button btn;
    Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        text=transform.GetChild(0).GetComponent<Text>();
        btn=GetComponent<Button>();
        btn.onClick.AddListener(()=>{
            Session.selectLevel=num;
            SceneMove.LoadScene(Scenes.Game);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
