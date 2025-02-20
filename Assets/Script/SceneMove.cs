using UnityEngine.SceneManagement;

public static class SceneMove
{
    public static void LoadScene(Scenes scene){
        SceneManager.LoadScene(scene.ToString());
    }
}
public enum Scenes{
    Game,
    Menu,
    Title,
    Result,
}