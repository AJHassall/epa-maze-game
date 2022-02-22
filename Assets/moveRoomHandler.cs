using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using System.IO;
public class Room{
    private bool hasNorthExit = false;
    private bool hasEastExit  = false;
    private bool hasSouthExit = false;
    private bool hasWestExit  = false;
    private int currentRoomX;
    private int currentRoomY;

    private bool isCleared    = false;
    private string RemoveWhiteSpace(string str){
        return str.Replace(" ", string.Empty);
    }
    private bool canMove(string direction){
         bool canMove = true;
         switch (direction)
            {                
                case "north":{
                    if(this.currentRoomY == 3) canMove = false;
                }   break;
                case "east":{
                    if(this.currentRoomX == 3) canMove = false;
                }   break;
                case "south":{
                    if(this.currentRoomY == 0) canMove = false;
                }   break;
                case "west":{
                    if(this.currentRoomY == 0) canMove = false;
                }   break;    
            }
    
        return this.isCleared && canMove;
    }
    public void MoveToAdjacentRoom(string direction){
        direction = RemoveWhiteSpace(direction.ToLower());

        if (canMove(direction))
        {
            switch (direction)
            {                
                case "north":{
                    this.currentRoomY++;
                }   break;
                case "east":{
                    this.currentRoomX++;
                }   break;
                case "south":{
                    this.currentRoomY--;
                }   break;
                case "west":{
                    this.currentRoomX--;
                }   break;    
            }
        }
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
            string[] directions = inputLine.Split(',');
            

            for (int x = 0; x < directions.Length; x++)
            {
                mazeArray[lineNumber, x] = new Room(directions[x]);
            }
            lineNumber++;
            
        }

        inputStream.Close();  
        return mazeArray;
    }
    private Room[,] Rooms;

    void Start(){
        Rooms = ReadRoomsFromFile(System.IO.Path.GetFullPath(".")+ "/Assets/Maps/Room1.txt")
    }
    public void North(){
        
    }
    public void East(){
    
    }
    public void South(){

    }
    public void West(){
        
    }
}
