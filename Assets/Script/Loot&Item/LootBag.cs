using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    public class LootBag : MonoBehaviour
    {
        public GameObject droppedItemPrefab;
        public List<ItemSO> lootList = new List<ItemSO>();

        List<ItemSO> GetDroppedItem()
        {
            int randomNumber = Random.Range(1, 101);
            Debug.Log(randomNumber);
            List<ItemSO> dropItems = new List<ItemSO>();
            foreach (ItemSO item in lootList)
            {
                if (randomNumber <= item.dropChance)
                {
                    dropItems.Add(item);
                    return dropItems;
                }
            }
            return dropItems;
        }

        public void SpawnLoot(Vector3 spawnPosition)
        {
            List<ItemSO> dropItems = GetDroppedItem();
            foreach (ItemSO item in dropItems)
            {
                GameObject lootItem = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
                lootItem.GetComponent<SpriteRenderer>().sprite = item.ItemImage;
                /*
                float dropForce = 200f;

                Vector2 dropDirection = new Vector2(Random.Range(-0.16f, 0.16f), Random.Range(-0.16f, 0.16f));
                lootItem.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
                */
            }
        }


    }
}