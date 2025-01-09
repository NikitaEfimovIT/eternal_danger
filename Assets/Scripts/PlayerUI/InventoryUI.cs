using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUi : MonoBehaviour
{
    // Start is called before the first frame update
    private InventoryFacade inventory;
    [SerializeField] private GameObject textPrefab; // Ссылка на prefab текста
    [SerializeField] private Transform contentPanel; // Ссылка на объект Content в Scroll View
    void Start()
    {
        inventory = InventoryFacade.Instance;
        // UpdateInventoryUI(inventory.GetItemsInInventory());
    }

    // Update is called once per frame
    
    

    // Метод для обновления Scroll View с элементами из списка
    public void UpdateInventoryUI(List<KeyItem> items)
    {
        // Очистить старые элементы
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        // Добавить новые элементы
        foreach (var item in items)
        {
            // Создать новый текстовый элемент
            GameObject newText = Instantiate(textPrefab, contentPanel);
            TextMeshProUGUI textComponent = newText.GetComponent<TextMeshProUGUI>();
            Debug.Log(newText);
            if (textComponent != null)
            {
                Debug.Log(item.name);
                textComponent.text = item.name;
            }
        }
    }

    void Update()
    {
        UpdateInventoryUI(inventory.GetItemsInInventory());
    }
    
}
