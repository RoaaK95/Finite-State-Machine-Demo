using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public sealed class GameEnvironment
{
    private static GameEnvironment _instance;
    private List<GameObject> _checkpoints = new List<GameObject>();
    public List<GameObject> _Checkpoints { get { return _checkpoints; } }

    public static GameEnvironment Singleton
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameEnvironment();
                _instance._Checkpoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));
                _instance._checkpoints = _instance._checkpoints.OrderBy(waypoint => waypoint.name).ToList();

            }

            return _instance;
        }
    }
}
