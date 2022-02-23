using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using System.IO;
public class Room{
    public bool hasNorthExit = false;
    public bool hasEastExit  = false;
    public bool hasSouthExit = false;
    public bool hasWestExit  = false;
    public bool isCleared    = false;
    private string RemoveWhiteSpace(string str){
            return str.Replace(" ", string.Empty);
    }


    public void RoomCleared(){
        this.isCleared    = true;
    }

    public bool canMove(string direction, Vector2Int position){
         bool canMove = true;
         switch (direction)
            {                
                case "north":{
                    if(position.y == 0 || !this.hasNorthExit) canMove = false;
                }   break;
                case "east":{
                    if(position.x == 3 || !this.hasEastExit) canMove = false;
                }   break;
                case "south":{
                    if(position.y == 3 || !this.hasSouthExit) canMove = false;
                }   break;
                case "west":{
                    if(position.x == 0 || !this.hasWestExit) canMove = false;
                }   break;    
            }
  
        return this.isCleared && canMove;
    }
  public Room(string directions){
        
        directions = RemoveWhiteSpace(directions);

        foreach (string exit in directions.ToLower().Split(','))
        {
            switch (exit)
            {
                case "n":{
                    this.hasNorthExit = true;
                }   break;
                case "e":{
                    this.hasEastExit = true;
                }   break;
                case "s":{
                    this.hasSouthExit = true;
                }   break;
                case "w":{
                    this.hasWestExit = true;
                }   break;                                                
            }
        }
    }
}

public class moveRoomHandler : MonoBehaviour
{
    public GameObject map;
    public static Room[,] rooms;
    public static Vector2Int playerLocation;
    
    private string RemoveWhiteSpace(string str){
        return str.Replace(" ", string.Empty);
    }
    void RoomCleared(){

        rooms[playerLocation.y, playerLocation.x].RoomCleared();
    }
    public bool MoveToAdjacentRoom(string direction, ref Vector2Int position, Room room){
        direction = RemoveWhiteSpace(direction.ToLower());

        if (room.canMove(direction, position))
        {
            switch (direction)
            {                
                case "north":{
                    position.y--;
                }   break;
                case "east":{
                    position.x++;
                }   break;
                case "south":{
                    position.y++;
                }   break;
                case "west":{
                    position.x--;
                }   break;    
            }
            if(room.isCleared) map.BroadcastMessage("initialiseTileMap", false);
            return true;
        }
        return false;
    }
    Room[,] ReadRoomsFromFile(string filePath){
        
        StreamReader inputStream = new StreamReader(filePath);
        int lineNumber = 0;

        Room[,] mazeArray = null;
        //loop through each row of a given text file
        //from the file create a 2d array that represents a room in the maze
        int mapWidth  = 4;
        int mapHeight = 4;
        while(!inputStream.EndOfStream)
        {
            string inputLine = inputStream.ReadLine( );
            
            if(mazeArray == null){
                mazeArray = new Room[mapHeight, mapWidth];
            }
            string[] directions = RemoveWhiteSpace(inputLine).Split(';');
            

            for (int x = 0; x < directions.Length; x++)
            {
                mazeArray[lineNumber, x] = new Room(directions[x]);
            }
            lineNumber++;
            
        }

        inputStream.Close();  
        return mazeArray;
    }
    void Start(){
        rooms = ReadRoomsFromFile(System.IO.Path.GetFullPath(".")+ "/Assets/Maps/Maze1.txt");
        playerLocation = new Vector2Int(0,0);
    }

    

    public void North(){
        if (!MoveToAdjacentRoom("north", ref playerLocation, rooms[playerLocation.y, playerLocation.x]))
        {
        
            Debug.Log("cant enter room");
        }
        Debug.Log(playerLocation);
        
    }
    public void East(){
        if (!MoveToAdjacentRoom("east", ref playerLocation, rooms[playerLocation.y, playerLocation.x]))
        {
              Debug.Log("cant enter room");
        }
        Debug.Log(playerLocation);
    }
    public void South(){
        if (!MoveToAdjacentRoom("south", ref playerLocation, rooms[playerLocation.y, playerLocation.x]))
        {
            Debug.Log("cant enter room");
        }
        Debug.Log(playerLocation);
    }
    public void West(){
        if (!MoveToAdjacentRoom("west", ref playerLocation, rooms[playerLocation.y, playerLocation.x]))
        {

            Debug.Log("cant enter room");
        }
        Debug.Log(playerLocation);
    }
}
