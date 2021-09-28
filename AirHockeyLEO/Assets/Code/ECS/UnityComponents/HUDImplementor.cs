using Millstones.LeoECSExtension.UnityComponents;
using UnityEngine;
using UnityEngine.UIElements;

namespace AirHockey.ECS.UnityComponents
{
    public class HUDImplementor : MonoBehaviour, IHUDComponentImplementor, IImplementor
    {
        private Label _upPlayerScore;
        private Label _downPlayerScore;
        private void OnEnable()
        {
            var visualRootElement = transform.Find("HUD").gameObject.GetComponent<UIDocument>().rootVisualElement;

            _upPlayerScore = visualRootElement.Q<Label>("up-player-score");
            _downPlayerScore = visualRootElement.Q<Label>("down-player-score");
            
            
            
        }

        public int UpPlayerScore
        {
            set => _upPlayerScore.text = value.ToString();
        }

        public int DownPlayerScore 
        {
            set => _downPlayerScore.text = value.ToString();
        }
    }
}
