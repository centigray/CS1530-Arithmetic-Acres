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
      Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y,0);//convert player position to vector3

      if(GameManager.instance.tileManager.IsInteractable(position))
      {
        Debug.Log("This tile is interactable");
      }
    }
  }
}
