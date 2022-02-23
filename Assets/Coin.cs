using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap  coinTileMap;

    private void OnCollisionEnter2D(Collision2D other) {
       Vector3 hitPosition = Vector3.zero;
        if (coinTileMap != null)
        {
            foreach (ContactPoint2D hit in other.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;

                Vector3Int v = coinTileMap.WorldToCell(hitPosition);
                if (other.gameObject.tag == "Player")
                {
                    coinTileMap.SetTile(v, null);
                    
                    for (int x = -2; x != 2; x++){
                        for (int y = -2; y != 2; y++){
                            coinTileMap.SetTile(new Vector3Int(v.x-x, v.y-y, 0), null);
                        
                        }
                    }
                }
            }
            ScoreManager.instance.changeScore();
        }
    }
}
