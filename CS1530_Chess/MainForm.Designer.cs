/*
 * Created by SharpDevelop.
 * User: Drew
 * Date: 6/9/2015
 * Time: 8:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CS1530_Chess
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.DirectoryButton = new System.Windows.Forms.Button();
			this.DirectoryLabel = new System.Windows.Forms.Label();
			this.SelectAllButton = new System.Windows.Forms.Button();
			this.DeselectAllButton = new System.Windows.Forms.Button();
			this.DisplayButton = new System.Windows.Forms.Button();
			this.FileCheckedBox = new System.Windows.Forms.CheckedListBox();
			this.kingBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.queenBox = new System.Windows.Forms.TextBox();
			this.rookBox = new System.Windows.Forms.TextBox();
			this.bishopBox = new System.Windows.Forms.TextBox();
			this.knightBox = new System.Windows.Forms.TextBox();
			this.pawnBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.recomendedBttn = new System.Windows.Forms.Button();
			this.MinimumELO = new System.Windows.Forms.GroupBox();
			this.ELObox = new System.Windows.Forms.TextBox();
			this.ELObttn = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.MinimumELO.SuspendLayout();
			this.SuspendLayout();
			// 
			// DirectoryButton
			// 
			this.DirectoryButton.Location = new System.Drawing.Point(12, 404);
			this.DirectoryButton.Name = "DirectoryButton";
			this.DirectoryButton.Size = new System.Drawing.Size(75, 23);
			this.DirectoryButton.TabIndex = 0;
			this.DirectoryButton.Text = "Directory";
			this.DirectoryButton.UseVisualStyleBackColor = true;
			this.DirectoryButton.Click += new System.EventHandler(this.DirectoryClick);
			// 
			// DirectoryLabel
			// 
			this.DirectoryLabel.Location = new System.Drawing.Point(12, 9);
			this.DirectoryLabel.Name = "DirectoryLabel";
			this.DirectoryLabel.Size = new System.Drawing.Size(254, 24);
			this.DirectoryLabel.TabIndex = 5;
			// 
			// SelectAllButton
			// 
			this.SelectAllButton.Location = new System.Drawing.Point(110, 404);
			this.SelectAllButton.Name = "SelectAllButton";
			this.SelectAllButton.Size = new System.Drawing.Size(75, 23);
			this.SelectAllButton.TabIndex = 6;
			this.SelectAllButton.Text = "Select All";
			this.SelectAllButton.UseVisualStyleBackColor = true;
			this.SelectAllButton.Visible = false;
			this.SelectAllButton.Click += new System.EventHandler(this.SelectAllClick);
			// 
			// DeselectAllButton
			// 
			this.DeselectAllButton.Location = new System.Drawing.Point(191, 404);
			this.DeselectAllButton.Name = "DeselectAllButton";
			this.DeselectAllButton.Size = new System.Drawing.Size(75, 23);
			this.DeselectAllButton.TabIndex = 7;
			this.DeselectAllButton.Text = "Deselect All";
			this.DeselectAllButton.UseVisualStyleBackColor = true;
			this.DeselectAllButton.Visible = false;
			this.DeselectAllButton.Click += new System.EventHandler(this.DeselectAllClick);
			// 
			// DisplayButton
			// 
			this.DisplayButton.Location = new System.Drawing.Point(297, 404);
			this.DisplayButton.Name = "DisplayButton";
			this.DisplayButton.Size = new System.Drawing.Size(75, 23);
			this.DisplayButton.TabIndex = 9;
			this.DisplayButton.Text = "Display";
			this.DisplayButton.UseVisualStyleBackColor = true;
			this.DisplayButton.Click += new System.EventHandler(this.DisplayButtonClick);
			// 
			// FileCheckedBox
			// 
			this.FileCheckedBox.FormattingEnabled = true;
			this.FileCheckedBox.Location = new System.Drawing.Point(12, 17);
			this.FileCheckedBox.Name = "FileCheckedBox";
			this.FileCheckedBox.Size = new System.Drawing.Size(254, 379);
			this.FileCheckedBox.TabIndex = 10;
			// 
			// kingBox
			// 
			this.kingBox.Location = new System.Drawing.Point(60, 23);
			this.kingBox.Name = "kingBox";
			this.kingBox.Size = new System.Drawing.Size(40, 20);
			this.kingBox.TabIndex = 11;
			this.kingBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 17);
			this.label1.TabIndex = 12;
			this.label1.Text = "King:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 17);
			this.label3.TabIndex = 14;
			this.label3.Text = "Queen:";
			// 
			// queenBox
			// 
			this.queenBox.Location = new System.Drawing.Point(60, 49);
			this.queenBox.Name = "queenBox";
			this.queenBox.Size = new System.Drawing.Size(40, 20);
			this.queenBox.TabIndex = 15;
			this.queenBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// rookBox
			// 
			this.rookBox.Location = new System.Drawing.Point(60, 75);
			this.rookBox.Name = "rookBox";
			this.rookBox.Size = new System.Drawing.Size(40, 20);
			this.rookBox.TabIndex = 16;
			this.rookBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// bishopBox
			// 
			this.bishopBox.Location = new System.Drawing.Point(60, 101);
			this.bishopBox.Name = "bishopBox";
			this.bishopBox.Size = new System.Drawing.Size(40, 20);
			this.bishopBox.TabIndex = 17;
			this.bishopBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// knightBox
			// 
			this.knightBox.Location = new System.Drawing.Point(60, 127);
			this.knightBox.Name = "knightBox";
			this.knightBox.Size = new System.Drawing.Size(40, 20);
			this.knightBox.TabIndex = 18;
			this.knightBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// pawnBox
			// 
			this.pawnBox.Location = new System.Drawing.Point(60, 153);
			this.pawnBox.Name = "pawnBox";
			this.pawnBox.Size = new System.Drawing.Size(40, 20);
			this.pawnBox.TabIndex = 19;
			this.pawnBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 78);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 17);
			this.label4.TabIndex = 20;
			this.label4.Text = "Rook:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(54, 17);
			this.label5.TabIndex = 21;
			this.label5.Text = "Bishop:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 130);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(54, 17);
			this.label6.TabIndex = 22;
			this.label6.Text = "Knight:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 156);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(36, 17);
			this.label7.TabIndex = 23;
			this.label7.Text = "Pawn:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.pawnBox);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.knightBox);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.bishopBox);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.rookBox);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.queenBox);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.kingBox);
			this.groupBox1.Location = new System.Drawing.Point(272, 19);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(117, 189);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Piece Values";
			// 
			// recomendedBttn
			// 
			this.recomendedBttn.Location = new System.Drawing.Point(272, 214);
			this.recomendedBttn.Name = "recomendedBttn";
			this.recomendedBttn.Size = new System.Drawing.Size(117, 23);
			this.recomendedBttn.TabIndex = 25;
			this.recomendedBttn.Text = "Recomended";
			this.recomendedBttn.UseVisualStyleBackColor = true;
			this.recomendedBttn.Click += new System.EventHandler(this.Button1Click);
			// 
			// MinimumELO
			// 
			this.MinimumELO.Controls.Add(this.ELObox);
			this.MinimumELO.Location = new System.Drawing.Point(272, 243);
			this.MinimumELO.Name = "MinimumELO";
			this.MinimumELO.Size = new System.Drawing.Size(117, 52);
			this.MinimumELO.TabIndex = 26;
			this.MinimumELO.TabStop = false;
			this.MinimumELO.Text = "Minimum ELO";
			// 
			// ELObox
			// 
			this.ELObox.Location = new System.Drawing.Point(6, 19);
			this.ELObox.Name = "ELObox";
			this.ELObox.Size = new System.Drawing.Size(105, 20);
			this.ELObox.TabIndex = 0;
			this.ELObox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ELObttn
			// 
			this.ELObttn.Location = new System.Drawing.Point(272, 301);
			this.ELObttn.Name = "ELObttn";
			this.ELObttn.Size = new System.Drawing.Size(117, 23);
			this.ELObttn.TabIndex = 27;
			this.ELObttn.Text = "All Games";
			this.ELObttn.UseVisualStyleBackColor = true;
			this.ELObttn.Click += new System.EventHandler(this.ELObttnClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(408, 439);
			this.Controls.Add(this.ELObttn);
			this.Controls.Add(this.MinimumELO);
			this.Controls.Add(this.recomendedBttn);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.FileCheckedBox);
			this.Controls.Add(this.DisplayButton);
			this.Controls.Add(this.DeselectAllButton);
			this.Controls.Add(this.SelectAllButton);
			this.Controls.Add(this.DirectoryLabel);
			this.Controls.Add(this.DirectoryButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "PGN Analyzer";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.MinimumELO.ResumeLayout(false);
			this.MinimumELO.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button ELObttn;
		private System.Windows.Forms.TextBox ELObox;
		private System.Windows.Forms.GroupBox MinimumELO;
		private System.Windows.Forms.Button recomendedBttn;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox pawnBox;
		private System.Windows.Forms.TextBox knightBox;
		private System.Windows.Forms.TextBox bishopBox;
		private System.Windows.Forms.TextBox rookBox;
		private System.Windows.Forms.TextBox queenBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox kingBox;
		private System.Windows.Forms.Button DisplayButton;
		private System.Windows.Forms.Button DeselectAllButton;
		private System.Windows.Forms.Button SelectAllButton;
		private System.Windows.Forms.Label DirectoryLabel;
		private System.Windows.Forms.CheckedListBox FileCheckedBox;
		private System.Windows.Forms.Button DirectoryButton;
		

		

	}
}
