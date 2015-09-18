/*
 * Created by SharpDevelop.
 * User: Drew
 * Date: 6/9/2015
 * Time: 8:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace CS1530_Chess
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Functions f = new Functions();
		
		public MainForm()
		{
			InitializeComponent();		
		}
		void SelectAllClick(object sender, System.EventArgs e)	//Button to select all the files in the checked list box
		{
			for(int i = 0; i < FileCheckedBox.Items.Count; i++)	//Loop through all the items in the box
     			FileCheckedBox.SetItemChecked (i, true);		//Set their value to checked
		}
		
		void Button1Click(object sender, System.EventArgs e)	//Button to set all piece values to standard values
		{
			kingBox.Text = "0";		//Set king value to 0
			queenBox.Text = "8";	//Set queen value to 8
			rookBox.Text = "5";		//Set rook value to 5
			bishopBox.Text = "3";	//Set bishop value to 3
			knightBox.Text = "3";	//Set knight value to 3
			pawnBox.Text = "1";		//Set pawn value to 1
		}
		
		void DeselectAllClick(object sender, System.EventArgs e) //Button to deselect all files in the file checked box
		{
			for(int i = 0; i < FileCheckedBox.Items.Count; i++)  //Loop through all the items in the box
     			FileCheckedBox.SetItemChecked (i, false);		 //Set their value to unchecked
		}		
		void DisplayButtonClick(object sender, System.EventArgs e) //Button used to parse all the selected games
		{
			
			int king_val = 0;
			int queen_val = 0;
			int rook_val = 0;
			int bishop_val = 0;
			int knight_val = 0;
			int pawn_val = 0;
			int ELO_val = 0;
			
			try //Try and parse the values of the textboxes for piece values from user
			{
				king_val = int.Parse(kingBox.Text);	
				queen_val = int.Parse(queenBox.Text);
				rook_val = int.Parse(rookBox.Text);
				bishop_val = int.Parse(bishopBox.Text);
				knight_val = int.Parse(knightBox.Text);
				pawn_val = int.Parse(pawnBox.Text);
				ELO_val = int.Parse(ELObox.Text);
			}
			catch(Exception ex) //If there's an issue with that
			{
				MessageBox.Show("There was an error with your piece values or ELO. Using default values." +ex.ToString()); 
				//Tell the user about the error
				king_val = 0;	//And set the values to their standard values
				queen_val = 8;
				rook_val = 5;
				bishop_val = 3;
				knight_val = 3;
				pawn_val = 1;
				ELO_val = 0;
			}
			finally //Then actually parse each file
			{
				foreach(object itemChecked in FileCheckedBox.CheckedItems) //For each item in the checked file box that is checked
				{
					BoxFile tempBoxFile = new BoxFile();	//Create a new temporary BoxFile
					tempBoxFile = (BoxFile)itemChecked;		//Cast it from the object passed by the loop
					FileInfo tempFileInfo = new FileInfo(tempBoxFile.fullpath); //Create a fileInfo from its full path
					f.parsePGN(tempFileInfo, king_val, queen_val, rook_val, bishop_val, knight_val, pawn_val, ELO_val); 
					//Parse the file with the piece values and elo value
    		    }	
				f.print(); //After each file has been parsed, print the file to csv
			}
		}		
		void DirectoryClick(object sender, EventArgs e)	//Function to allow the user to select the directory they'd like to find files in
		{			
			FolderBrowserDialog fbd = new FolderBrowserDialog();	//Create a new FolderBrowser
 			DialogResult result = fbd.ShowDialog();					//Open FolderBrowser
 			
 			string[] filepaths = {};								//Create an array that will hold the file paths
 			
 			try
 			{
 				filepaths = Directory.GetFiles(fbd.SelectedPath,"*.pgn", SearchOption.TopDirectoryOnly);
 				//Convert all the file names in the directory with the .pgn file extension to the array of filepaths
 				Array.Sort(filepaths); //Make sure they're sorted for the user
 				f.addFilePaths(filepaths);	//Make sure functions knows what files we're operating on
 			}
 			catch(Exception exception)
 			{			
 				Debug.WriteLine(exception.ToString());
 				return; 				
 			}
 			
 			SelectAllButton.Visible = true;	//Make select all button visible
 			DeselectAllButton.Visible = true; //Make deselect all button visible
 			
 			for(int i = 0; i < filepaths.Length; i++)
 			{	
 				string[] split = filepaths[i].Split('\\');	//Split the file path by the \\ to get file name
 				BoxFile temp = new BoxFile(filepaths[i],split[split.Length-1]);	//Create a new BoxFile object with file path and file name
 				FileCheckedBox.Items.Add(temp, true);	//Add it to the checkedFileBox with the value true
 			}		
			 			
		}
		void ELObttnClick(object sender, EventArgs e)	//Button to set the ELO to accept all games
		{
			ELObox.Text = "0";
		}
		public class BoxFile //Object used to maintain file path and file name for the checkedFileBox
		{
			public string fullpath = "";	//Full path
			public string displaypath = "";	//Display path
			public BoxFile()	//Empty constructor
			{
				
			}
			public BoxFile(string full, string display)	
			{
				fullpath = full;
				displaypath = display;		
			}
			public override string ToString()
			{
				return displaypath;
			}

		}
	}
}
