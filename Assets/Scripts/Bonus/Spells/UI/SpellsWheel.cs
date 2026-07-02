using System.Collections.Generic;
using Runtime;
using UnityEngine;

namespace Bonus.Spells.UI
{
    public class SpellsWheel : MonoBehaviour
    {
        private int _slotCount;
        private const float RADIUS = 1f;

        private readonly List<WheelItem> _items = new List<WheelItem>();

        [SerializeField]
        private GameObject _wheelItemPrefab;
        private SpellQueue _queue;

        private void Start()
        {
            _slotCount = LvlVariables.AvailableSpellsCount;

            float angleStep = 360f / _slotCount;

            for (int i = 0; i < _slotCount; i++)
            {
                float angle = angleStep * i + angleStep * 1.5f;
                float rad = -angle * Mathf.Deg2Rad;

                Vector3 pos =
                    transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * RADIUS;

                var item = Instantiate(_wheelItemPrefab, transform);
                item.name = "SpellItem_" + i;
                item.transform.position = pos;

                // Разворот в сторону центра (2D LookAt)
                Vector3 dir = transform.position - pos;
                float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                item.transform.rotation = Quaternion.Euler(0, 0, rotZ + 90f);

                _items.Add(item.transform.GetComponent<WheelItem>());
            }

            _queue = new SpellQueue();
            _queue.Initialization(_items);
        }

        public List<WheelItem> GetItems() => _items;

        public WheelItem GetByIndex(int index) => _items[index];
    }
}
