using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PracTest2
{
    public partial class Form1 : Form
    {
        //Name: Jeffrey Luo 
        //ID: 1535901

        public Form1()
        {
            InitializeComponent();
        }

        ChessBoard chessBoard = new ChessBoard();

        Player whitePlayer = new Player(Piece.Colour.WHITE);

        Player blackPlayer = new Player(Piece.Colour.BLACK);

        bool gameStart = false;
        bool whitePlayerTurn = false;

        /// <summary>
        /// Draws a chess board based on the user input of the board size, number of rows/columns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameStart = false;
            //Creates a graphics object for the chess board to be drawn on
            Graphics canvas = pictureBoxDisplay.CreateGraphics();
            chessBoard.DrawBoard(canvas, gameStart);
            whitePlayer.SquaresOccupied.Clear();
            blackPlayer.SquaresOccupied.Clear();
            whitePlayer.AssignPieces(chessBoard);
            blackPlayer.AssignPieces(chessBoard);
            gameStart = true;
            whitePlayerTurn = true;
        }

        /// <summary>
        /// Clears the contents of the picturebox, textbox and gives the textbox the focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBoxDisplay.Refresh();
            gameStart = false;
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            //Creates a graphics object for the chess board to be drawn on
            Graphics canvas = pictureBoxDisplay.CreateGraphics();
          
            //Get blocks array position of clicked square
            (int rowPos, int colPos) = chessBoard.GetArrayPositionOfClickedSquare(e.X, e.Y);
            if (rowPos == -1 && colPos == -1)
            {
                MessageBox.Show("You clicked in an invalid position. Please try again.");
            }

            if (gameStart == true && whitePlayerTurn == true)
            {
                if (whitePlayer.PlayMove(canvas, chessBoard, blackPlayer, rowPos, colPos) == true)
                {
                    whitePlayerTurn = false;
                }
            }
            else if (gameStart == true)
            {
                if (blackPlayer.PlayMove(canvas, chessBoard, whitePlayer, rowPos, colPos) == true)
                {
                    whitePlayerTurn = true;
                }
            }

  
        }

        private void refreshBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBoxDisplay.Refresh();
            //Creates a graphics object for the chess board to be drawn on
            Graphics canvas = pictureBoxDisplay.CreateGraphics();

            if (gameStart == false)
            {
                MessageBox.Show("You have not started a game yet!");
            }
            else
            {
                chessBoard.DrawBoard(canvas, gameStart);

                foreach (SquareOnBoard whiteOccupiedSquare in whitePlayer.SquaresOccupied)
                {
                    whiteOccupiedSquare.DrawSquare(canvas, whiteOccupiedSquare.DefaultColour);
                    whiteOccupiedSquare.DrawPiece(canvas);
                }

                foreach (SquareOnBoard blackOccupiedSquare in blackPlayer.SquaresOccupied)
                {
                    blackOccupiedSquare.DrawSquare(canvas, blackOccupiedSquare.DefaultColour);
                    blackOccupiedSquare.DrawPiece(canvas);
                }

                if (whitePlayer.SelectedSquare != null)
                {
                    whitePlayer.SelectedSquare.Highlight(canvas);
                    whitePlayer.SelectedSquare.DrawPiece(canvas);
                    whitePlayer.SelectedSquare.PieceOnSquare.ShowPossibleMoves(canvas, whitePlayer.SelectedSquare);
                }

                if (blackPlayer.SelectedSquare != null)
                {
                    blackPlayer.SelectedSquare.Highlight(canvas);
                    blackPlayer.SelectedSquare.DrawPiece(canvas);
                    blackPlayer.SelectedSquare.PieceOnSquare.ShowPossibleMoves(canvas, blackPlayer.SelectedSquare);
                }
            }

        }
    }
}
