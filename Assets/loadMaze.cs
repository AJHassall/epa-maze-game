using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Tilemaps;
using Pathfinding;


public class loadMaze : MonoBehaviour
{
    // Start is called before the first frame update

    private int m_MapHeight = 17;
    private int m_MapWidth  = 17;

    public Tile floorTile;
    public Tile wallTile;
    public Tile coinTile;
    public Tilemap coinTilemap;
    public Tilemap floorTilemap;
    public Tilemap wallTilemap;
    public GameObject enemyPrefab;
    
    void Start()
    {
        string[,] maze = loadMazeFromFile(System.IO.Path.GetFullPath(".")+ "/Assets/Maps/Room1.txt");
        initialiseTileMap(maze);     

        StartCoroutine(scanPathingGrid());
    }
    IEnumerator scanPathingGrid(){
        yield return new WaitForSeconds(1f);
        AstarPath.active.Scan();
    }
    // Update is called once per frame
    void Update()
    {
     
    }


    
    private void setTile(Tilemap tm, Tile t, int x, int y){
        tm.SetTile(new Vector3Int(x - m_MapWidth/2, y-m_MapHeight/2, 0), t);
    }
    //initialise the tile map object with values from an array.
    void initialiseTileMap(string [,] array){
        for (int y = 0; y < m_MapHeight; y++)
        {
            for (int x = 0; x <  m_MapWidth; x++)
            {
                switch (array[y,x])
                {
                    //wall
                    case "1":{
                        setTile(wallTilemap, wallTile, x, y);
                    } break;
                    //floor
                     case "0":{
                        setTile(floorTilemap, floorTile, x, y);
                    } break;
                    //enemy
                     case "e":{
                        Instantiate(enemyPrefab,floorTilemap.CellToWorld(new Vector3Int(x - m_MapWidth/2,y - m_MapHeight/2,0)) , new Quaternion());                        
                        setTile(floorTilemap, floorTile, x, y);
                    } break;
                    //coin
                    case "c":{
                        setTile(floorTilemap, floorTile, x, y);
                        setTile(coinTilemap, coinTile, x, y);
                    } break;
                    
                   
                }
            
            }
        }
    }

    string[,] loadMazeFromFile(string filePath){
        
        StreamReader inputStream = new StreamReader(filePath);
        int lineNumber = 0;

        string[,] mazeArray = null;
        //loop through each row of a given text file
        //from the file create a 2d array that represents a room in the maze
        while(!inputStream.EndOfStream)
        {
            string inputLine = inputStream.ReadLine( );

            if(inputLine.StartsWith("#MapWidth")){
                m_MapWidth  = int.Parse( inputLine.Split('=')[1]);
            }
            else if(inputLine.StartsWith("#MapHeight")){
                m_MapHeight = int.Parse( inputLine.Split('=')[1]);
            }
            else{
                if(mazeArray == null){
                    mazeArray = new string[m_MapHeight, m_MapWidth];
                }
                string[] row = inputLine.Split(',');

                for (int x = 0; x < row.Length; x++)
                {
                    mazeArray[lineNumber, x] = row[x];
                }
                lineNumber++;
            }
        }

        inputStream.Close( );  
        return mazeArray;
    }
}
