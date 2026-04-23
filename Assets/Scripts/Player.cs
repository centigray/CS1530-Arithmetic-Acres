using UnityEngine;

public class Player : MonoBehaviour
{
  public Inventory inventory;

  private void Awake()
    {
        inventory = new Inventory(21);
    }

  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.Space))
    {
      Vector3Int position = GameManager.instance.tileManager.GetTilemapPosition(transform.position);
      Debug.Log("IsSeeded: " + GameManager.instance.tileManager.IsSeeded(position));
      Debug.Log("IsPlowed: " + GameManager.instance.tileManager.IsPlowed(position));
      Debug.Log("IsInteractable: " + GameManager.instance.tileManager.IsInteractable(position));
      Inventory.Slot selectedSlot = inventory.slots[inventory.selectedIndex];

      bool isSeed = selectedSlot.type == CollectableType.CARROT_SEED || selectedSlot.type == CollectableType.PUMPKIN_SEED 
      || selectedSlot.type == CollectableType.CABBAGE_SEED;

      if(GameManager.instance.tileManager.IsSeeded(position))
      {
        FindObjectOfType<InteractController>().Interact(position);
        return;
      }

      // if holding a seed and standing on plowed tile → plant it
      if(isSeed && GameManager.instance.tileManager.IsPlowed(position) && !GameManager.instance.tileManager.IsSeeded(position)) 
      {
        GameManager.instance.tileManager.SetSeeded(position, selectedSlot.type);
        return;
      }
      if(GameManager.instance.tileManager.IsInteractable(position))
      {
        Debug.Log("This tile is interactable");
        GameManager.instance.tileManager.SetInteracted(position);
      }

      Vector3 worldPos = GameManager.instance.tileManager.GetWorldPosition(position);
      Collider2D[] hits = Physics2D.OverlapCircleAll(worldPos, 0.5f);
      foreach(Collider2D hit in hits)
      {
          Collectable crop = hit.GetComponent<Collectable>();
          if(crop != null)
          {
            inventory.Add(crop);
            Destroy(crop.gameObject);
            FindObjectOfType<Inventory_UI>().Refresh(); // refresh the UI
          }
      }
    }
  }
}
