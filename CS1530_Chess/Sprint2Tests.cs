/*
 * Created by SharpDevelop.
 * User: Drew
 * Date: 6/23/2015
 * Time: 8:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace CS1530_Chess
{
	[TestFixture]
	public class Sprint2Tests
	{
		[Test]
		public void TestParse()
		{
			FileInfo finfo = new FileInfo("INVALIDNAME");
				
			Debug.WriteLine("parsing...");
			
			try
			{
				FileStream fs = finfo.Open(FileMode.Open);
				int size = (int)finfo.Length;
				byte[] buffer = new byte[size];
				String str = "";
				
				fs.Read(buffer, 0, size);
				str = Encoding.Default.GetString(buffer);
				fs.Close();

                //REMOVE COMMENTS
                Regex comment = new Regex(@"(;.*(\r\n|\n))|(\{.*\})");
                str = comment.Replace(str, "");
				//Debug.WriteLine(str);


                /*    	PARSE TAG PAIRS
                 * 
                 *      	@"\[(.*)\s+""(.*)""\]\s+"
                 * 
                 *    	PARSE MOVETEXT
                 *      
                 *      	@"(\d+)\.\s+(\w+\d|O-O|O-O-O|1/2-1/2|1-0|0-1|\w+\d=\w)\+?#?\s+(\w+\d|O-O|O-O-O|1/2-1/2|1-0|0-1|\w+\d=\w)\+?#?\s*"
                 * 
                 * 		PARSE ROUND
                 * 	
                 * 			  (      TAG PAIRS       ) (            MOVETEXT                      MOVETEXT                      MOVETEXT                              )
                 * 				 (K )     (V )          (TRN)     (                WHITE MOVE			   )        (                 BLACK MOVE             )
                 * 			@"(\[(.*)\s+""(.*)""\]\s+)*((\d+)\.\s+(\w+\d|O-O|O-O-O|1/2-1/2|1-0|0-1|\w+\d=\w)\+?#?\s+(\w+\d|O-O|O-O-O|1/2-1/2|1-0|0-1|\w+\d=\w)\+?#?\s*)+"
                 * 
                 * SAN - Standard Algebraic Notation
				 * Movetext:
				 *  capture:		x (lowercase)
				 *  king:			K
				 *  queen:			Q
				 *  rook:			R
				 *  bishop:			B
				 *  knight:			N
				 *  pawn:			(empty)|P
                 *  
                 *  
                 * */
                
                //Groups:				1  2        3            45         6                                                 7 
                Regex round=new Regex(@"(\[(.*)\s+""(.*)""\]\s+)*((\d+)\.\s+(\w+\d|O-O|O-O-O|1/2-1/2|1-0|0-1|\w+\d=\w)\+?#?\s+(\w+\d|O-O|O-O-O|1/2-1/2|1-0|0-1|\w+\d=\w)\+?#?\s*)+");
                
                Match roundmatch = round.Match(str);
                int roundctr = 0;
                while(roundmatch.Success)
                {
                	roundctr++;
                	
                	Debug.WriteLine("ROUND "+roundctr+":");
                	Debug.WriteLine("	Tagpairs:");
                	Group key = roundmatch.Groups[2]; //tagpair key
                	Group val = roundmatch.Groups[3]; //tagpair value
                	for(int i = 0; i<key.Captures.Count;i++)
                	{
                		Debug.WriteLine("	"+key.Captures[i]+": "+val.Captures[i]);
                	}
                	
                	Debug.WriteLine("		Movetext:");
                	Group turn = roundmatch.Groups[5];
                	Group w = roundmatch.Groups[6]; //white move
                	Group b = roundmatch.Groups[7]; //black move
                	for(int i = 0; i<turn.Captures.Count;i++)
                	{
                		Debug.WriteLine("		"+turn.Captures[i]+". "+w.Captures[i]+" "+b.Captures[i]);
                	}
                	
                	roundmatch = roundmatch.NextMatch();
                }

                Assert.Fail("Read Broken File");
			}
			catch(Exception e)
			{
				Assert.Pass("Didn't read broken file:" + e.ToString());
			}
			
		}
	}
}
