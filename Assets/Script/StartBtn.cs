using UnityEngine;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(()=>{
          SceneMove.LoadScene(Scenes.Menu);  
        }); 
    }
}
