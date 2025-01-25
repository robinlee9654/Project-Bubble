using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; //singleton
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    public Toggle EnableRemove;

    public InventoryItemController[] InventoryItems;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(Item item){
        Items.Add(item);
    }

    public void Remove(Item item){
        Items.Remove(item);
    }

    public void ListItems(){
        //clean content before open
        foreach(Transform item in ItemContent){
            Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var deleteButton = obj.transform.Find("DeleteButton").GetComponent<Button>();


            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
            if(EnableRemove.isOn){
                deleteButton.gameObject.SetActive(true);
            }
        }

        SetInventoryItems();
    }

    public void EnableItemsRemove(){
        if (EnableRemove.isOn){ //remove item mode on
            foreach (Transform item in ItemContent){
                item.Find("DeleteButton").gameObject.SetActive(true);
            }
        }
        else{ //remove item mode off
            foreach (Transform item in ItemContent){
                item.Find("DeleteButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems(){
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++){
            InventoryItems[i].AddItem(Items[i]);
        }
    }
}
