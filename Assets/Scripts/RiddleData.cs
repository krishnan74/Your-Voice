using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RiddleData", menuName = "GameData/RiddleData", order = 1)]
public class RiddleData : ScriptableObject
{
    public List<Riddle> riddles = new List<Riddle>();
}
