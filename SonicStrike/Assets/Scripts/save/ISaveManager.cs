using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ISaveManager
{
    void loadData(gameData data);
    void saveData(ref gameData data);
}
