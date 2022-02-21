using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Tilemaps;


public class loadMaze : MonoBehaviour
{
    // Start is called before the first frame update

    private int m_MapHeight = 0;
    private int m_MapWidth  = 0;

    public Tile floorTile;
    public Tile wallTile;
    public Tilemap floorTilemap;
    public Tilemap wallTilemap;


    
    void Start()
    {
        string[,] maze = loadMazeFromFile(Path.GetFullPath(".")+ "/Assets/Maps/Maze1.txt");
        initialiseTileMap(maze);     

    }

    // Update is called once per frame
    void Update()
    {
        // 
    }

    void initialiseTileMap(string [,] array){
        for (int y = 0; y < m_MapHeight; y++)
        {
            for (int x = 0; x <  m_MapWidth; x++)
            {
                if( array[y,x] == "1"){
                    wallTilemap.SetTile(new Vector3Int(x - m_MapWidth/ 2, y - m_MapHeight / 2, 0), wallTile) ;
                }
                else{
                    floorTilemap.SetTile(new Vector3Int(x - m_MapWidth/ 2, y - m_MapHeight / 2, 0), floorTile) ;
                }
            
            }
        }
    }

    string[,] loadMazeFromFile(string filePath){
        
        StreamReader inputStream = new StreamReader(filePath);

        
        int lineNumber = 0;

        string[,] mazeArray = null;

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
                    Debug.Log(x + "  " +lineNumber);
                }
                  
                lineNumber++;
            }
        }

        inputStream.Close( );  
        return mazeArray;
    }
}
