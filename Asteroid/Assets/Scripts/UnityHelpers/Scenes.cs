using UnityEngine.SceneManagement;

public static class Scenes {

    public static void Load_Game() { Load("Game"); }
    public static void Load_MainMenu() { Load("MainMenu"); }
    public static void Load_Setup() { Load("Setup"); }
    public static void ReloadThisScene() { Load(SceneManager.GetActiveScene().name); }

    static void Load(string s) { SceneManager.LoadScene(s); }
}
