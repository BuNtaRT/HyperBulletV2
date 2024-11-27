using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lib
{
    public class ObjectPool : MonoBehaviour
    {
        private static GameObject _overSpawnCell;
        private static GameObject _mainContainer;

        [SerializeField]
        private List<ObjectsInfo> objectsInfo = new List<ObjectsInfo>();
        private static List<ObjectsInfo> _objectsInfoStatic = new List<ObjectsInfo>();
        private static Dictionary<TypeObj, Queue<GameObject>> _poolDictionary;

        private void Awake()
        {
            _mainContainer = new GameObject();
            _mainContainer.name = "_POOL_";

            _overSpawnCell = new GameObject();
            _overSpawnCell.name = "OverSpawnCell";
            _overSpawnCell.transform.SetParent(_mainContainer.transform);
            _poolDictionary = new Dictionary<TypeObj, Queue<GameObject>>();

            _objectsInfoStatic = objectsInfo;

            foreach (ObjectsInfo temp in objectsInfo)
            {
                GameObject cellPool = new GameObject();
                cellPool.transform.SetParent(_mainContainer.transform);
                cellPool.name = temp.prefab.name;

                Queue<GameObject> tempQueue = new Queue<GameObject>();
                for (int i = 0; i < temp.count; i++)
                {
                    GameObject obj = Instantiate(temp.prefab, cellPool.transform, true);
                    obj.SetActive(false);
                    tempQueue.Enqueue(obj);
                }

                _poolDictionary.Add(temp.type, tempQueue);
            }
        }

        public static Transform SpawnObj(TypeObj type, Vector3 position)
        {
            if (_poolDictionary[type].Count != 0)
            {
                GameObject temp = _poolDictionary[type].Dequeue();
                temp.SetActive(true);
                temp.transform.position = position;
                return temp.transform;
            }
            else
            {
                var temp = _objectsInfoStatic.FirstOrDefault(o => (o.type == type)).prefab;
                if (temp == null)
                    Debug.LogError("type " + type + " doesn't set");

                GameObject tempObj = Instantiate(temp, _overSpawnCell.transform, true);
                tempObj.transform.position = position;
                return tempObj.transform;
            }
        }

        public static void Destroy(TypeObj type, GameObject obj)
        {
            obj.SetActive(false);
            _poolDictionary[type].Enqueue(obj);
        }
    }

    public enum TypeObj : byte
    {
        Enemy,
        Bullet,
        ExplosionFromBullet,
        Spell,
        Perk,
        None
    }

    [Serializable]
    public struct ObjectsInfo
    {
        public TypeObj type;
        public GameObject prefab;
        public int count;
    }
}
