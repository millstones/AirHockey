using System;
using UnityEngine;

namespace AirHockey.Unity
{
    [CreateAssetMenu(fileName = "AirHockey", menuName = "AirHockey/GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] public PutterSettings putterSetting;
        

        [Serializable]
        public struct TablePositions
        {
            public Transform CenterPoint;
            public Transform UpSpawnPoint;
            public Transform DownSpawnPoint;
            public GameObject UpGate;
            public GameObject DownGate;
            public GameObject Plane;
        }

        [Serializable]
        public struct PutterSettings
        {
            public int Speed;
        }
    }
}