using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
public class InitialiseRoom : MonoBehaviour
{
    // Start is called before the first frame update

    public Tile floorTile;
    public Tile wallTile;
    public Tile coinTile;
    public Tilemap coinTilemap;
    public Tilemap floorTilemap;
    public Tilemap wallTilemap;
    public GameObject enemyPrefab;

    private const int m_MapWidth = 17;
    private const int m_MapHeight = 17;

    void InstantiateEvent(Vector2Int position){
        
        
        Debug.Log(123);

        transform.position = new Vector3(position.x * 100, position.y * 100, 0);
    }

    void Start()
    {
        string[,] room = LoadRoomFile(System.IO.Path.GetFullPath(".")+ "/Assets/Maps/Room1.txt");
        InitialiseRoomTileMap(room);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string[,] LoadRoomFile(string filePath){
        
        StreamReader inputStream = new StreamReader(filePath);
        int lineNumber = 0;

        string[,] mazeArray = new string[m_MapHeight,m_MapWidth];
        //loop through each row of a given text file
        //from the file create a 2d array that represents a room in the maze
        int y = 0;
        while(!inputStream.EndOfStream)
        {
            string inputLine = inputStream.ReadLine();
            string[] row = inputLine.Split(',');
            int x = 0;
            foreach (string tile in row)
            {
                mazeArray[y,x++] = tile;
            }
        }

        inputStream.Close( );  
        return mazeArray;


    }
     private void SetTile(Tilemap tm, Tile t, int x, int y){
        tm.SetTile(new Vector3Int(x - m_MapWidth/2, y-m_MapHeight/2, 0), t);
    }
    void InitialiseRoomTileMap(string [,] array){
         for (int y = 0; y < m_MapHeight; y++)
         {
             for (int x = 0; x <  m_MapWidth; x++)
             {
                 switch (array[y,x])
                 {
                     //wall
                     case "1":{
                         SetTile(wallTilemap, wallTile, x, y);
                         SetTile(floorTilemap, floorTile, x, y);
                     } break;
                     //floor
                      case "0":{
                         SetTile(floorTilemap, floorTile, x, y);
                     } break;
                     //enemy
                      case "e":{
                         Instantiate(enemyPrefab,floorTilemap.CellToWorld(new Vector3Int(x - m_MapWidth/2,y - m_MapHeight/2,0)) , new Quaternion());
                      
                         SetTile(floorTilemap, floorTile, x, y);
                     } break;
                     //coin
                     case "c":{
                         SetTile(floorTilemap, floorTile, x, y);
                         SetTile(coinTilemap, coinTile, x, y);
                     } break;
                  
                 
                 }
          
             }
         }
     }
}
