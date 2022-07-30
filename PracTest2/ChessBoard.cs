using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PracTest2
{
    class ChessBoard
    {
        public SquareOnBoard[,] squares;

        //The minimum size of the board
        public int NUM_SQUARES_ON_SIDE = 8;

        //the colour of a Dark square (a variable since Color cannot be a const)
        Color DarkBrown = Color.SaddleBrown;

        //the colour of a Light square (a variable since Color cannot be a const)
        Color LightBrown = Color.SandyBrown;

        //Width of a square
        int WIDTH = 80;
        //Height of a square
        int HEIGHT = 80;

        Piece piecePlace;

        public ChessBoard()
        {
            squares = new SquareOnBoard[NUM_SQUARES_ON_SIDE, NUM_SQUARES_ON_SIDE];
        }

        /// <summary>
        /// Draws a row of squares for the chess board
        /// </summary>
        /// <param name="canvas">The graphics object where the square is drawn</param>
        /// <param name="boardSize">The size of the board</param>
        /// <param name="rowNum">The row number of the square that is being drawn</param>
        /// <param name="ypos">The current position of y</param>
        private void DrawRow(Graphics canvas, int rowNum, int ypos, bool gameStart)
        {
            int xpos = 0;
            //Creates a square in each column for the board size number of columns
            for (int colNum = 1; colNum <= NUM_SQUARES_ON_SIDE; colNum++)
            {
                if (gameStart == false)
                {
                    squares[rowNum - 1, colNum - 1] = new SquareOnBoard(xpos, ypos, rowNum - 1, colNum - 1);
                }
                //If the sum divided by 2 is even, then draw a square with light brown colour
                if ((colNum + rowNum) % 2 == 0)
                {
                    squares[rowNum - 1, colNum - 1].DefaultColour = LightBrown;
                    squares[rowNum-1, colNum-1].DrawSquare(canvas, LightBrown);
                }
                //If the sum divided by 2 is odd, then draw a square with dark brown colour
                else
                {
                    squares[rowNum - 1, colNum - 1].DefaultColour = DarkBrown;
                    squares[rowNum-1, colNum-1].DrawSquare(canvas, DarkBrown);
                }

                //Will only draw default pieces once and not when refreshing
                if (gameStart == false && DefaultPiecePlacement(canvas, rowNum, colNum) == true)
                {
                    squares[rowNum - 1, colNum - 1].DrawPiece(canvas);
                }

                xpos += WIDTH;
            }
        }

        public void DrawBoard(Graphics canvas, bool gameStart)
        {
            int ypos = 0;

            //Creates a row of squares for the board size number of rows
            for (int rowNum = 1; rowNum <= NUM_SQUARES_ON_SIDE; rowNum++)
            {
                DrawRow(canvas, rowNum, ypos, gameStart);
                ypos += HEIGHT;
            }
        }

        public (int i, int j) GetArrayPositionOfClickedSquare(int x, int y)
        {
            for (int i = 0; i < NUM_SQUARES_ON_SIDE; i++)
            {
                for (int j = 0; j < NUM_SQUARES_ON_SIDE; j++)
                {
                    //Determines whether the mouse clicked position is within a particular rectangle
                    if (squares[i, j].ClickableSquare.Contains(x, y))
                    {
                        return (i, j);
                    }
                }
            }
            //Code after will be an appropriate error message (expected in the player class)
            return (-1, -1);
        }

        public bool DefaultPiecePlacement(Graphics canvas, int rowNum, int colNum)
        {
            bool squareHasPiece = false;
            if (rowNum-1 == 0)
            {
                if (colNum - 1 == 0 || colNum - 1 == 7)
                {
                    piecePlace = new Rook(Piece.Colour.BLACK);
                }

                if (colNum - 1 == 1 || colNum - 1 == 6)
                {
                    piecePlace = new Knight(Piece.Colour.BLACK);
                }

                if (colNum - 1 == 2 || colNum - 1 == 5)
                {
                    piecePlace = new Bishop(Piece.Colour.BLACK);
                }

                if (colNum - 1 == 3)
                {
                    piecePlace = new Queen(Piece.Colour.BLACK);
                }

                if (colNum - 1 == 4)
                {
                    piecePlace = new King(Piece.Colour.BLACK);
                }

                squareHasPiece = true;
            }
            else if (rowNum-1 == 7)
            {
                if (colNum - 1 == 0 || colNum - 1 == 7)
                {
                    piecePlace = new Rook(Piece.Colour.WHITE);
                }

                if (colNum - 1 == 1 || colNum - 1 == 6)
                {
                    piecePlace = new Knight(Piece.Colour.WHITE);
                }

                if (colNum - 1 == 2 || colNum - 1 == 5)
                {
                    piecePlace = new Bishop(Piece.Colour.WHITE);
                }

                if (colNum - 1 == 3)
                {
                    piecePlace = new Queen(Piece.Colour.WHITE);
                }

                if (colNum - 1 == 4)
                {
                    piecePlace = new King(Piece.Colour.WHITE);
                }
                squareHasPiece = true;
            }
            else if (rowNum-1 == 1)
            {
                piecePlace = new Pawn(Piece.Colour.BLACK);
                squareHasPiece = true;
            }
            else if (rowNum - 1 == 6)
            {
                piecePlace = new Pawn(Piece.Colour.WHITE);
                squareHasPiece = true;
            }

            if (squareHasPiece == true)
            {
                squares[rowNum - 1, colNum - 1].PieceOnSquare = piecePlace;
            }

            return squareHasPiece;
        }
     
    }
}
