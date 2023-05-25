using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class WorldBorder : MonoBehaviour
{
    GameSession gameSession;
    PolygonCollider2D polygon;
    Player player;
    
    void Awake()
    {
        polygon = GetComponent<PolygonCollider2D>();
        gameSession = FindObjectOfType<GameSession>();
        player = FindObjectOfType<Player>();

    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && player.GetIsAlive())
        {   
            gameSession.PlayerDeath();
        }
        
    }
}
