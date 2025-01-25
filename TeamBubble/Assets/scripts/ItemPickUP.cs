using UnityEngine;

public class ItemPickUP : MonoBehaviour
{
    public Item item;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PickUp(){
        InventoryManager.Instance.Add(item); // add item to inventory
        Destroy(gameObject); //destroy the original item on the map
    }

    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    private void OnMouseDown()
    {
        PickUp();
    }
}
