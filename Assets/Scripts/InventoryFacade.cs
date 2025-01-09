using System.Collections.Generic;

namespace UnityEngine
{
    public class InventoryFacade:MonoBehaviour
    {
        private Inventory inventory;
        
        public static InventoryFacade Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject); // Удаляем дублирующийся объект
                return;
            }

            Instance = this; // Сохраняем ссылку на текущий объект
            DontDestroyOnLoad(gameObject); // Сохраняем между сценами

            // Инициализация инвентаря
            inventory = new Inventory();
            if (inventory == null)
            {
                Debug.LogError("Inventory не найден на объекте с InventoryFacade!");
            }
        }
        
        public void AddToInventory(KeyItem item)
        {
            inventory.AddItem(item);
        }

        public KeyItem CheckForItemInInventory(int doorId)
        {
            return inventory.FindItem(doorId);
        }

        public List<KeyItem> GetItemsInInventory()
        {
            return inventory.GetItems();
        }

    }
}