using UnityEngine;

namespace AirHockey.Unity
{
    public class TableMonoScript : MonoBehaviour, ITableService
    {
        public GameSettings.TablePositions TablePositions => tablePositions;
        
        [SerializeField] private GameSettings.TablePositions tablePositions;
    }

    public interface ITableService
    {
        GameSettings.TablePositions TablePositions { get; }
    }
}