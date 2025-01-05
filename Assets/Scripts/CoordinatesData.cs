using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoordinatesData", menuName = "GameData/CoordinatesData", order = 1)]
public class CoordinatesData : ScriptableObject
{
    public List<Coordinates> coordinates = new List<Coordinates>();
}
