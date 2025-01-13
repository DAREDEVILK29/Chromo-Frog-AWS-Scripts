using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    [SerializeField] public float BlockIndex;
    private BoxCollider2D blockCollider;
    public EggScript eggScript;
   
   
    


    private void Awake()    
    {
        blockCollider = GetComponent<BoxCollider2D>();
        if (blockCollider == null)
        {
            Debug.LogError("BoxCollider2D component not found on this GameObject.");
        }
        UpdateBlockLayer(BlockIndex);

       
    }

  

   
    private void UpdateBlockLayer(float BlockIndex)
    {
        switch (BlockIndex)
        {
            case 4:
                gameObject.layer = LayerMask.NameToLayer("Layer_Red");
                break;
            case 1:
                gameObject.layer = LayerMask.NameToLayer("Layer_Blue");
                break;
            case 2:
                gameObject.layer = LayerMask.NameToLayer("Layer_Orange");
                break;
            case 3:
                gameObject.layer = LayerMask.NameToLayer("Layer_Pink");
                break;
            case 5:
                gameObject.layer = LayerMask.NameToLayer("Layer_Yellow");
                break;
            default:
                gameObject.layer = LayerMask.NameToLayer("Default");
                break;
        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        // Get the Player component from the collided object
        Player player = collision.collider.GetComponent<Player>();
        eggScript = collision.collider.gameObject.GetComponent<EggScript>();

        if (player != null)  // Check if the collided object is the player
        {
            // The player will collide with the block only if they share the same layer
            if (player.gameObject.layer == gameObject.layer || EggScript.canPassIndex.Contains(BlockIndex))
            {
                // The player can interact with the block
                Physics2D.IgnoreCollision(blockCollider, player.GetComponent<Collider2D>(), true);
               
                
               
                Debug.Log($"Player of layer {player.gameObject.layer} collided with block of layer {gameObject.layer}");
               
                
                   
                    
                   
                    
                
            }
            else
            {
                Physics2D.IgnoreCollision(blockCollider, player.GetComponent<Collider2D>(), false);
                // Ignore collision if layers don't match
                Debug.Log($"Ignoring collision: Player's layer {player.gameObject.layer} != Block's layer {gameObject.layer}");
            }
         
        }
    }

   
}
