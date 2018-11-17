using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataLoader {

    JsonSaveLoad<LevelData> dataloader;
    public List<LevelData> levels = new List<LevelData>();

    public LevelDataLoader()
    {
        dataloader = new JsonSaveLoad<LevelData>("Levels");
        levels = dataloader.Load();
    }

    public LevelData GetLevel(int index)
    {
        return levels[index];
    }

    public void AddLevel(LevelData level)
    {
        levels.Add(level);
        dataloader.Save(levels);
    }

    public void ModifyLevel(LevelData level, int index)
    {
        levels[index] = level;
        dataloader.Save(levels);
    }
}
