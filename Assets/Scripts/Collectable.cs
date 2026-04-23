using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;

    //player walks into collectable
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        //add collectable to player
        if (player)
        {
            player.inventory.Add(this);
            //delete colelctable from screen
            Destroy(this.gameObject);
        }
    }

}
public enum CollectableType
    {
        NONE, CARROT_SEED, PUMPKIN_SEED, CABBAGE_SEED, CARROT, SPROUT, FAT_SPROUT, YELLOW, PUMPKIN, GREEN_PUMPKIN
    }