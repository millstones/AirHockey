using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Millstones.Common
{
    public class GameObjectFactory
    {
        public GameObjectFactory() { _prefabs = new Dictionary<string, GameObject>(); }
        
        public IEnumerator<GameObject> Build(string prefabName, bool startActive = false)
        {
            if (_prefabs.TryGetValue(prefabName, out var go) == false)
            {
                var load = Addressables.LoadAssetAsync<GameObject>(prefabName);
                while (load.IsDone == false) yield return null;

                go = load.Result;

                _prefabs.Add(prefabName, go);
            }

            var gameObject = GameObject.Instantiate(go);
            gameObject.SetActive(startActive);
            yield return gameObject;
        }

        readonly Dictionary<string, GameObject> _prefabs; 
    }
}