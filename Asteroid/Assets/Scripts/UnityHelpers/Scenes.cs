using UnityEngine.SceneManagement;

public static class Scenes {

    public static void Load_Game() { Load("AsteroidGame"); }
    public static void Load_0_LoadScene() { Load("0_Load"); }
    public static void Load_MainMenu() { Load("Menu"); }
    public static void Load_Options() { Load("Options"); }
    public static void Load_Credits() { Load("Credits"); }
    public static void Load_LevelSelector() { Load("LevelSelector"); }
    public static void Load_languageSelector() { Load("LanguajeSelector"); }
    public static void ReloadThisScene() { Load(SceneManager.GetActiveScene().name); }

    static void Load(string s) { SceneManager.LoadScene(s); }
}
