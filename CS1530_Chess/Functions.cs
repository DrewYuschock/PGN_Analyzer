/*
 * Created by SharpDevelop.
 * User: Drew
 * Date: 6/10/2015
 * Time: 10:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CS1530_Chess
{
	public class Functions
	{
		public List<FileInfo> filePaths = new List<FileInfo>();	//List to hold all the file names the user selected
		public List<Game> gameList = new List<Game>();			//List used to hold all the games the program has parsed
		
		public static int PAWN_VAL = 0;		//Value of pawn specified by user
		public static int KNIGHT_VAL = 0;	//Value of knight specified by user
		public static int BISHOP_VAL = 0;	//Value of bishop specified by user
		public static int ROOK_VAL = 0;		//Value of rook specified by user
		public static int QUEEN_VAL = 0;	//Value of queen specified by user
		public static int KING_VAL = 0;		//Value of king specified by user
		public static int ELO_VAL = 0;		//Value of ELO specified by user
			
		public Functions()					//Empty functions constructor
		{
			
		}
		public void addFilePaths(string[] fp)	//This function adds the files paths to a list every time the directory is selected
		{										//Only really used now to get the final directory output for the CSV
			filePaths.Clear();					//Clear the current list of files	
			for(int i = 0; i < fp.Length; i++)	//For every filepointer string
			{
				FileInfo temp = new FileInfo(fp[i]);	//Create a new object FileInfo from the string
				filePaths.Add(temp);					//And add it to the list of filePaths
			}			
		}
		//Primary file parsing function, takes a FileInfo from user, piece values, and required ELO the game needs to be above
		public void parsePGN(FileInfo finfo, int king_val, int queen_val, int rook_val, int bishop_val, 
		                     int knight_val, int pawn_val, int ELO_val)
        {
			KING_VAL = king_val;		//Set the king value as specified by the user
			QUEEN_VAL = queen_val;		//Set the queen value as specified by the user
			ROOK_VAL = rook_val;		//Set the rook value as specified by the user
			BISHOP_VAL = bishop_val;	//Set the bishop value as specified by the user
			KNIGHT_VAL = knight_val;	//Set the knight value as specified by the user
			PAWN_VAL = pawn_val;		//Set the pawn value as specified by the user
			ELO_VAL = ELO_val;			//Set the ELO value as specified by the user
			
			string[] text = File.ReadAllLines(finfo.ToString());	//Read the current file into an array of lines
			Game currentGame = new Game();	//Create a new game
			
			for(int i = 0; i < text.Length; i++)	//For every line in the file, loop and try to read tags
			{
				string raw = text[i];					//Raw data format of the line
				string line = raw.Replace(".",". ");	//Replacing all .'s with ._'s to catch weirdly formatted pgns
				if(line.Contains("[Event "))			//Extra space is needed to differentiate between Event and EventDate
				{
					if(currentGame.g_event != null)				//If the game isn't null
						gameList.Add(currentGame);		//Add it to the game list
					currentGame = new Game();			//Always create new game object
					var reg = new Regex("\".*?\"");		//Simple regex to get text from a line
    				var matches = reg.Matches(line);	//matches[0] will always hold the event name
    				currentGame.g_event = matches[0].ToString().Replace(',',' ');	//Replace all ,'s with _'s to prevent mixups with csv
				}
				else if(line.Contains("[Site "))		//Catches the site of the current game	
				{
					var reg = new Regex("\".*?\"");		//Simple regex to get text from a line

    				var matches = reg.Matches(line);	//matches[0] will always hold the event name
    				currentGame.g_site = matches[0].ToString().Replace(',',' ');	//Replace all ,'s with _'s to prevent mixups with csv
				}
				else if(line.Contains("[Date "))		//Catches the date of the current game
				{
					var reg = new Regex("\".*?\"");		//Simple regex to get text from a line
    				var matches = reg.Matches(line);	//matches[0] will always hold the event name
    				currentGame.g_date = matches[0].ToString().Replace(',',' ');	//Replace all ,'s with _'s to prevent mixups with csv
				}
				else if(line.Contains("[Round "))		//Catches the round of the current game	
				{
					var reg = new Regex("\".*?\"");		//Simple regex to get text from a line
    				var matches = reg.Matches(line);	//matches[0] will always hold the event name
    				currentGame.g_round = matches[0].ToString().Replace(',',' ');  //Replace all ,'s with _'s to prevent mixups with csv
				}
				else if(line.Contains("[White "))		//Catches the white players name of the current game
				{
					var reg = new Regex("\".*?\"");		//Simple regex to get text from a line
    				var matches = reg.Matches(line);	//matches[0] will always hold the event name
    				currentGame.g_white = matches[0].ToString().Replace(',',' ');	//Replace all ,'s with _'s to prevent mixups with csv
				}
				else if(line.Contains("[Black "))		//Catches the black players name of the current game	
				{
					var reg = new Regex("\".*?\"");		//Simple regex to get text from a line
    				var matches = reg.Matches(line);	//matches[0] will always hold the event name
    				currentGame.g_black = matches[0].ToString().Replace(',',' ');	//Replace all ,'s with _'s to prevent mixups with csv
				}
				else if(line.Contains("[Result "))		//Catches the result of the current game	
				{
					var reg = new Regex("\".*?\"");		//Simple regex to get text from a line
    				var matches = reg.Matches(line);	//matches[0] will always hold the event name
    				if(matches[0].ToString().Contains("1-0"))	//If the result is 1-0, white has won
    					currentGame.g_result = "White";			//Set winner to white (dont use -'s or /'s, csvs treat them as mathmatical operators)
    				else if(matches[0].ToString().Contains("0-1")) //If the result is 0-1, black has won
    					currentGame.g_result = "Black";			//Set winner to black (dont use -'s or /'s, csvs treat them as mathmatical operators)
    				else										//If the string is anything else, assume its a tie
    					currentGame.g_result = "Tie";			//set the result to tie (dont use -'s or /'s, csvs treat them as mathmatical operators)
				}
				else if(line.Contains("[WhiteElo "))	//Catches the white players ELO		
				{
					var reg = new Regex("\".*?\"");		//Simple regex to get text from a line
    				var matches = reg.Matches(line);	//matches[0] will always hold the event name
    				currentGame.g_w_elo = matches[0].ToString().Replace(',',' ');	//Replace all ,'s with _'s to prevent mixups with csv
				}
				else if(line.Contains("[BlackElo "))	//Catches the black players ELO		
				{
					var reg = new Regex("\".*?\"");		//Simple regex to get text from a line
    				var matches = reg.Matches(line);	//matches[0] will always hold the event name
    				currentGame.g_b_elo = matches[0].ToString().Replace(',',' '); //Replace all ,'s with _'s to prevent mixups with csv
				}
				else if(line.Contains("[ECO "))			//Catches the ECO verison from the game, not currently implemented for anything really
				{
					var reg = new Regex("\".*?\"");		//Simple regex to get text from a line
    				var matches = reg.Matches(line);	//matches[0] will always hold the event name
    				currentGame.g_ECO = matches[0].ToString().Replace(',',' '); //Replace all ,'s with _'s to prevent mixups with csv
				}
				//We can add more cases here for more info, this is just a few things to add
				else if(line.StartsWith("1. ")) //The 1. signifies the start of a game. and we now need to add all the lines below until we reach a blank line
				{		
					int j;	//Create an new inner loop to catch all tags realted to game
					for(j = i; j < text.Length && !text[j].Equals(""); j++)	//While the new loop doesn't overstep the file and isn't null (null represents the end of a game)
					{
						currentGame.g_text += text[j].Replace(".", ". ") + " "; //Again, replace all .'s with ._'s to allow parsing to actually happen
					}
					try //Try to parse the game
					{
						currentGame.parseGame();	//Calls the parse function, doesn't need params because all game data is stored in the game object
						
						string gameString = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",	//Create csv string format about the game
					                                  currentGame.g_event, currentGame.g_site, currentGame.g_date,
					                                  currentGame.g_round, currentGame.g_white, currentGame.g_w_elo,
					                                  currentGame.g_black, currentGame.g_b_elo, currentGame.g_result, 
					                                  currentGame.g_strength_by_move);
						currentGame.final_string = gameString;	//set the games final string to the formatted string
					}  //Catch all for errors
					catch(Exception ex)
					{
						MessageBox.Show(ex.ToString());	//Show error in message box
						currentGame.final_string = "";	//Set the final string to ""	
					}
					i=j;								//Move i to where j left off
				}			
			}
			
			if(currentGame.g_event != null)				//Add the last game to the game list, this needs done to prevent the last one from not being added
				gameList.Add(currentGame);			
		}
		public void print()								//Function to print the CSV from the gamelist
		{
			List<string> csv = new List<string>();		//Create new CSV
			csv.Add("Event,Site,Date,Round,White Name,White ELO,Black Name,Black ELO,Result\n"); //Add the CSV header to the list
			foreach(Game g in gameList)					//For each game in the gamelist
			{
				if((g.g_w_elo != null)||(g.g_b_elo != null))	//If the found ELO values in the game aren't null
				{	
					if(ELO_VAL == 0)							//If the ELO value is 0, we want to print all the games
					{
						if(g.final_string == "")				//If the game string is null, there was an issue and we need to tell the user
							csv.Add("Game was not in expected format. Please refer to the PGN wiki to see required format");	//Add message instead of game
						else									
							csv.Add(g.final_string);			//Otherwise add game string as normal
					}
					else
					{
						string w_elo = g.g_w_elo.Replace('"',' '); //Replace the found "'s with black spaces
						string b_elo = g.g_b_elo.Replace('"',' '); //Replace the found "'s with black spaces
						
						if(int.Parse(w_elo) >= ELO_VAL && int.Parse(b_elo) >= ELO_VAL) //If the user set minimum ELO is greater than either the black or white players ELO
						{
							if(g.final_string == "")	//If the game string is invalid
								csv.Add("Game was not in expected format. Please refer to the PGN wiki to see required format"); //Inform the user
							else
								csv.Add(g.final_string); //Otherwise add it to the CSV printout
						}
					}	
				}
			}
			try
			{
				MessageBox.Show("Output file located in: " + filePaths[0].Directory.ToString()+"\\output.csv");	
				//Tell the user where the output file is located, will always be in the directory the user selected as output.csv																							
				File.WriteAllLines(filePaths[0].Directory.ToString()+"\\output.csv",csv.ToArray());
				//Actually convert the list to an array, and write it by line to the CSV
			}
			catch(Exception open)
			{
				MessageBox.Show("Please close the current output file and run again" + open.ToString());	
				//If the file is already open, tell the user to close the file and try again
			}
		}
		public class Game
		{
			public string g_event;			//Game event name if found in file
			public string g_site;			//Game site name if found in file
			public string g_date;			//Game date if found in file
			public string g_round;			//Game round number if found in file
			public string g_white;			//White's player name if found in file
			public string g_black;			//Black's palyer name if found in file
			public string g_result;			//Final result of game if found in file (white, black, tie)
			public string g_w_elo;			//White's ELO if found in file
			public string g_b_elo;			//Black's ELO if found in file
			public string g_ECO;			//Encyclopedia of chess openings version if found in file
			public string g_text;			//Raw text of the game if found in file
			public string g_strength_by_move;	//Strength by move string calculated while parsing
			public string final_string;			//Final string sent to the CSV
			public int w_points = 8*PAWN_VAL + 2*KNIGHT_VAL + 2*BISHOP_VAL + 2*ROOK_VAL + 1*QUEEN_VAL + 1*KING_VAL;	 //Represents the value of w's board
			public int b_points = 8*PAWN_VAL + 2*KNIGHT_VAL + 2*BISHOP_VAL + 2*ROOK_VAL + 1*QUEEN_VAL + 1*KING_VAL;	 //Represents the value of b's board
			
			public Game()					//Empty Constructor
			{
				
			}
			public void parseGame()			//Main parsing algorithm
			{
				string[] split = g_text.Split(' ');	//split now contains the following
													//n = move number
													//n+1 = start position
													//n+2 = end position
				string[,] board = new string[8,8];	//Representation of board in 8x8 array
				boardSetUp(board);					//Fills board with pieces at start of game
				
				for(int i = 0; (i+3) < split.Length; i+=3) //Loop to parse the game, jumps by 3's
				{
					string whiteMove = "";			//String to represent the raw data of white's move
					string whiteCoor = "";			//String to represent the coordinates of whites move ex: a1, b3, f5
					string whitePiece = "";			//String to represent the peice white is moving (determined dynamically later)
					string blackMove = "";			//String to represent the raw data of black's move
					string blackCoor = "";			//String to represent the coordinates of whites move ex: a1, b3, f5
					string blackPiece = "";			//String to represent the peice black is moving (determined dynamically later)
					bool castle = false;			//Bool used to stop piece placement if a castle was found (Castles are handled differently
					
					whiteMove = split[i+1];					//Raw string of whites move
					blackMove = split[i+2];					//Raw string of blacks move
						
					blackCoor = GetLast(split[i+2],2);		//Needs to check for castling o-o-o!
					
					if(whiteMove.Equals("0-1") || whiteMove.Equals("1-0")||whiteMove.Equals("1/2-1/2")
					   ||whiteMove.Equals("")||whiteMove.Contains("#")) //Catch all to stop parsing if the end of the game is found
						break;											//Break loop
					
					if(whiteMove.Equals("0-0-0") || whiteMove.ToLower().Equals("o-o-o") 
					   || whiteMove.Equals("0-0-0+") || whiteMove.ToLower().Equals("o-o-o+")) //All Queenside Castle move for white
					{
						board[2,0] = "W_King";	//Setting king piece around as specified by queenside castle
						board[3,0] = "W_Rook";  //Setting rook piece around as specified by queenside castle
						castle = true;			//Setting the castle bool here
					}
					else if(whiteMove.Equals("0-0") || whiteMove.Equals("0-0+")|| whiteMove.ToLower().Equals("o-o") || whiteMove.ToLower().Equals("o-o+"))	//Kingside Castle
					{
						board[5,0] = "W_Rook"; //Setting rook piece around as specified by queenside castle
						board[6,0] = "W_King"; //Setting king piece around as specified by kingside castle
						castle = true;		   //Setting the castle bool here
					}					
					else	//Move was not castle and can be handled somewhat normally
					{
						int white_col = 0;	//Integer used to hold the column the white piece has moved to, converted from ascii
						int white_row = 0;  //Integer used to hold the row the white piece has moved to, converted from ascii
						
						if(whiteMove.Contains("="))	//Any tag with the "=" represents a promotion, which are currently handled differently
						{
							whitePiece = "W_Queen";	//Set the peice white is moving to a queen
							this.w_points+=(QUEEN_VAL - PAWN_VAL);	//Change whites strength to add a queen and subtract a pawn
							string[] promotionSplit = split[i+1].Split('=');	//Split the tag by the equal sign, promotionSplit[0] hold the move coordinates
							whiteCoor = GetLast(promotionSplit[0],2);			//Getting the last two characters of the first half of the tag, represents coordinates
							white_col = ((int)whiteCoor[0])-97;			//Columns in file are represented by lower case a-h, subtract 97 from ascii and get the column number
							white_row = ((int)whiteCoor[1])-49;		    //Rows in the file are rperesentd by 1-8, subtract 49 from ascii value and get row number	
						}
						else	//Any tag without an "=" can be handled somewhat normally
						{
							if(whiteMove.Contains("+") || whiteMove.Contains("#")) //A "+" or "#" represents a check or checkmate at the end of a tag, and we need to increase the letters taken
								whiteCoor = GetLast(split[i+1],3);	//If they're found, we need to take the last 3 letters of the string because they appear as a1+
							else
								whiteCoor = GetLast(split[i+1],2);	//If there isn't a check or checkmate found, we only need to grab the last 2 chars
							white_col = ((int)whiteCoor[0])-97;			//Columns in file are represented by lower case a-h, subtract 97 from ascii and get the column number
							white_row = ((int)whiteCoor[1])-49;			//Rows in the file are rperesentd by 1-8, subtract 49 from ascii value and get row number
							
							if(whiteMove.Contains("K"))					//If the white move tag contains a capital K, we know the king has moved
							{
								whitePiece = "W_King";					//Set white's move piece to a king
							}
							else if(whiteMove.Contains("Q"))			//If the white move tag contains a capital Q, we know the queen has moved
							{
								whitePiece = "W_Queen";					//Set white's move piece to a queen
							}
							else if(whiteMove.Contains("R"))			//If the white move tag contains a capital R, we know a rook has moved
							{
								whitePiece = "W_Rook";					//Set white's move piece to a rook
							}
							else if(whiteMove.Contains("B"))			//If the white move tag contains a capital B, we know a bishop has moved
							{
								whitePiece = "W_Bishop";				//Set white's move piece to a bishop
							}
							else if(whiteMove.Contains("N"))			//If the white move tag contains a capital N, we know a knight has moved
							{
								whitePiece = "W_Knight";				//Set white's move piece to a knight
							}
							else										//If the white move tag contains no capital letters, or a capital P, we know a pawn has moved
							{
								whitePiece = "W_Pawn";					//Set white's move piece to a pawn
							}							
						}
						
						//This section here handles the value change in the event of a capture
						if(whiteMove.ToLower().Contains("x"))			//X in the move string signifies a capture at that spot
						{
						   	string piece = board[white_col,white_row];	//Get the piece, if there is one, at the end move coordinates
						   	switch (piece) 								//Simple switch statement to determine what if anything was captured
						   	{
						   	   case "B_Rook":							//If the location holds B_Rook, a rook had been captured
							      this.b_points -= ROOK_VAL;			//Subtract the value of a rook from black's points
							      break;								//And break
							   case "B_Knight":							//If the location holds B_Knight, a knight had been captured
							      this.b_points -= KNIGHT_VAL;			//Subtract the value of a knight from black's points
							      break;								//And break
							   case "B_Bishop":							//If the location holds B_Bishop, a bishop had been captured
							      this.b_points -= BISHOP_VAL;			//Subtract the value of a rook from black's points
							      break;								//And break
							   case "B_Queen":							//If the location holds B_Queen, a queen had been captured
							      this.b_points -= QUEEN_VAL; 			//Subtract the value of a queen from black's points
							      break;								//And break
							   case "B_King":							//If the location holds B_King, a king had been captured
							      this.b_points -= KING_VAL; 			//Subtract the value of a king from black's points
							      break;								//And break
							   case "B_Pawn":							//If the location holds B_Rook, a rook had been captured
							      this.b_points -= PAWN_VAL;			//Subtract the value of a rook from black's points
							      break;								//And break
							   default:									//If not piece is found, we assume nothing was captured						
							      break;								//And break			  
						    }								   	
						}
						
						if(castle == false)								//If the caslte bool is still false
							board[white_col,white_row] = whitePiece;	//Place whites piece in its coordinates														   
					}
					
					castle = false;										//Reset castle bool for black's turn
					
					//Below is the code for black's turn. If any questions just refer to comments on white's turn
					if(blackMove.Equals("0-1") || blackMove.Equals("1-0") || blackMove.Equals("1/2-1/2") || blackMove.Equals("") || blackMove.Contains("#"))
						break;
					
					if(blackMove.Equals("0-0-0") || blackMove.ToLower().Equals("o-o-o") || blackMove.Equals("0-0-0+") || blackMove.ToLower().Equals("o-o-o+")) //Queenside Castle
					{
						board[2,7] = "W_King";
						board[3,7] = "W_Rook";
						castle = true;
						
					}
					else if(blackMove.Equals("0-0") || blackMove.ToLower().Equals("o-o") || blackMove.Equals("0-0+") || blackMove.ToLower().Equals("o-o+"))	//Kingside Castle
					{
						board[5,7] = "W_Rook";
						board[6,7] = "W_King";
						castle = true;
					}					
					else
					{
						int s_col = 0;
						int s_row = 0;
						if(blackMove.Contains("="))
						{
							blackPiece = "B_Queen";
							this.b_points+=(QUEEN_VAL - PAWN_VAL);
							string[] promotionSplit = split[i+2].Split('=');
							blackCoor = GetLast(promotionSplit[0],2);
							s_col = ((int)blackCoor[0])-97;	
							s_row = ((int)blackCoor[1])-49;
						}
						else
						{
							if(blackMove.Contains("+"))
								blackCoor = GetLast(split[i+2],3);
							else
								blackCoor = GetLast(split[i+2],2);	
							
							s_col = ((int)blackCoor[0])-97;			
							s_row = ((int)blackCoor[1])-49;
							
							if(blackMove.Contains("K"))
							{
								blackPiece = "B_King";
							}
							else if(blackMove.Contains("Q"))
							{
								blackPiece = "B_Queen";
							}
							else if(blackMove.Contains("R"))
							{
								blackPiece = "B_Rook";
							}
							else if(blackMove.Contains("B"))
							{
								blackPiece = "B_Bishop";
							}
							else if(blackMove.Contains("N"))
							{
								blackPiece = "B_Knight";
							}
							else
							{
								blackPiece = "B_Pawn";
							}							
						}
						
						if(blackMove.ToLower().Contains("x"))			
						{
						   	string piece = board[s_col,s_row];
						   	switch (piece) 
						   	{
						   	   case "W_Rook":
							      this.w_points -= ROOK_VAL;
							      break;
							   case "W_Knight":
							      this.w_points -= KNIGHT_VAL;
							      break;
							   case "W_Bishop":
							      this.w_points -= BISHOP_VAL;
							      break;
							   case "W_Queen":
							      this.w_points -= QUEEN_VAL; 
							      break;
							   case "W_King":
							      this.w_points -= KING_VAL; 
							      break;
							   case "W_Pawn":
							      this.w_points -= PAWN_VAL;
							      break;
							   default:
							      break;				  
						    }								   	
						}
						if(castle == false) 
							board[s_col,s_row] = blackPiece;
					}
					g_strength_by_move+=(w_points-b_points)+","; //At the end of every turn, record the difference between white and blacks current strengths
				}											
			}
			public string GetLast(string source, int tail_length)	//Simple function to get the last number of characters in a provided string
		    {
		       if(tail_length >= source.Length)						//If the tail length is greater than the source length
		          return source;									//Return source
		       return source.Substring(source.Length - tail_length);	//Otherwise return a substring
		    }
	
			public override string ToString()						//Override to change the ToString of a game.ToString()
			{
				string s = "Event:   {0}\n"+						//Creating string format
				           "Site:    {1}\n"+
				           "Date:    {2}\n"+
				           "Round:   {3}\n"+
				           "White:   {4}\n"+
				           "Black:   {5}\n"+
				           "Result:  {6}\n"+
						   "White Elo: {7}\n"+
						   "Black Elo: {8}\n"+
						   "ECO:     {9}\n"+
						   "Text:	 {10}\n";
				return String.Format(s, g_event, g_site, g_date, g_round, g_white, g_black, g_result, g_w_elo, g_b_elo, g_ECO, g_text);			                         
			}
			public void boardSetUp(string[,] b)		//Function to set up board for game, called at the begining of every game
			{
				b[0,0] = "W_Rook";					//Create white rook at a1
				b[1,0] = "W_Knight";				//Create white knight at b1
				b[2,0] = "W_Bishop";				//Create white bishop at c1
				b[3,0] = "W_Queen";					//Create white queen at d1				
				b[4,0] = "W_King";					//Create white king at e1
				b[5,0] = "W_Bishop";				//Create white bishop at f1
				b[6,0] = "W_Knight";				//Create white knight at g1
				b[7,0] = "W_Rook";					//Create white rook at h1
				for(int i = 0; i < 8; i++)			//Loop to create pawns
				{
					b[i,1] = "W_Pawn";				//Create white pawn at a-h2
				}
				
				b[0,7] = "B_Rook";					//Create black rook at a8
				b[1,7] = "B_Knight";				//Create black rook at b8
				b[2,7] = "B_Bishop";				//Create black rook at c8
				b[3,7] = "B_Queen";					//Create black rook at d8
				b[4,7] = "B_King";					//Create black rook at e8
				b[5,7] = "B_Bishop";				//Create black rook at f8
				b[6,7] = "B_Knight";				//Create black rook at g8
				b[7,7] = "B_Rook";					//Create black rook at h8
				for(int i = 0; i < 8; i++)			//Loop to create pawns
				{
					b[i,6] = "B_Pawn";				//Create black pawn at a-h7
				}
				
			}
			/*Simple function to print board as seen by: 	a b c d e f g h
			 * 											 
			 * 											 1	W B W B W B W B
			 * 											 2  B W B W B W B W
			 * 											 3  W B W B W B W B
			 * 											 4  B W B W B W B W
			 * 											 5  W B W B W B W B
			 * 											 6  B W B W B W B W
			 * 											 7  W B W B W B W B
			 * 											 8  B W B W B W B W 
			 */
			public string printBoard(string[,] b)														
			{
				string s = "";					//String to hold the board			
				for(int i = 0; i < 8; i++)		//Loop 1-8
				{
					for(int j = 7; j > -1; j--)	//Loop 8-1
					{
						s+= string.Format("[{0}]  ", b[j,i]);	//Get the space
					}
					s+="\n";					//Add new line char
				}
				return s;						//Return board string
			}
		}
		
	}
}
