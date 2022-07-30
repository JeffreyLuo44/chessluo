using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PracTest2
{
    class Queen:Piece
    {
        public Queen(Colour pieceColour) : base(pieceColour)
        {

        }
        public override void Draw(Graphics canvas, Rectangle square)
        {
            int wOrB = 0;
            if (PieceColour == Colour.BLACK)
            {
                wOrB = 1;
            }
            else
            {
                wOrB = 0;
            }

            canvas.DrawString("Q", TEXT_FONT, TEXT_BRUSH[wOrB], square);

            if (PieceColour == Colour.BLACK)
            {
                canvas.DrawImage(Properties.Resources.BlackQueen, square);
            }
            else
            {
                canvas.DrawImage(Properties.Resources.WhiteQueen, square);
            }
        }

        public override SquareOnBoard Move(Graphics canvas, ChessBoard chessBoard, SquareOnBoard previousSquare, int rowPos, int colPos, Player player)
        {
            //Bishop's moveset

            int colAdjustIncOrDec = 0;

            for (int rowAdjust = -1; rowAdjust >= -7; rowAdjust--)
            {
                colAdjustIncOrDec--;
                try
                {
                    AddToBeHighlighted(chessBoard, previousSquare, previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec);

                    if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec] == chessBoard.squares[rowPos, colPos])
                    {
                        if (chessBoard.squares[rowPos, colPos].PieceOnSquare != null && chessBoard.squares[rowPos, colPos].PieceOnSquare.PieceColour == previousSquare.PieceOnSquare.PieceColour)
                        {
                            return null;
                        }
                        else
                        {
                            return chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec];
                        }
                    }

                    if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec].PieceOnSquare != null)
                    {
                        break;
                    }
                }
                catch { }
            }

            colAdjustIncOrDec = 0;

            for (int rowAdjust = -1; rowAdjust >= -7; rowAdjust--)
            {
                colAdjustIncOrDec++;
                try
                {
                    AddToBeHighlighted(chessBoard, previousSquare, previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec);

                    if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec] == chessBoard.squares[rowPos, colPos])
                    {
                        if (chessBoard.squares[rowPos, colPos].PieceOnSquare != null && chessBoard.squares[rowPos, colPos].PieceOnSquare.PieceColour == previousSquare.PieceOnSquare.PieceColour)
                        {
                            return null;
                        }
                        else
                        {
                            return chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec];
                        }
                    }

                    if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec].PieceOnSquare != null)
                    {
                        break;
                    }
                }
                catch { }
            }

            colAdjustIncOrDec = 0;

            for (int rowAdjust = 1; rowAdjust <= 7; rowAdjust++)
            {
                colAdjustIncOrDec--;
                try
                {
                    AddToBeHighlighted(chessBoard, previousSquare, previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec);

                    if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec] == chessBoard.squares[rowPos, colPos])
                    {
                        if (chessBoard.squares[rowPos, colPos].PieceOnSquare != null && chessBoard.squares[rowPos, colPos].PieceOnSquare.PieceColour == previousSquare.PieceOnSquare.PieceColour)
                        {
                            return null;
                        }
                        else
                        {
                            return chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec];
                        }
                    }

                    if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec].PieceOnSquare != null)
                    {
                        break;
                    }
                }
                catch { }
            }

            colAdjustIncOrDec = 0;

            for (int rowAdjust = 1; rowAdjust <= 7; rowAdjust++)
            {
                colAdjustIncOrDec++;
                try
                {
                    AddToBeHighlighted(chessBoard, previousSquare, previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec);

                    if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec] == chessBoard.squares[rowPos, colPos])
                    {
                        if (chessBoard.squares[rowPos, colPos].PieceOnSquare != null && chessBoard.squares[rowPos, colPos].PieceOnSquare.PieceColour == previousSquare.PieceOnSquare.PieceColour)
                        {
                            return null;
                        }
                        else
                        {
                            return chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec];
                        }
                    }

                    if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjustIncOrDec].PieceOnSquare != null)
                    {
                        break;
                    }
                }
                catch { }
            }

            //Rook's moveset

            for (int rowAdjust = -1; rowAdjust >= -7; rowAdjust--)
            {
                try
                {
                    //Check if there is an opponent piece or a blank square as possible squares
                    AddToBeHighlighted(chessBoard, previousSquare, previousSquare.RowPos + rowAdjust, previousSquare.ColPos);

                    //Check if player has clicked on a square
                    if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos] == chessBoard.squares[rowPos, colPos])
                    {
                        //If player has clicked on square with same colour piece, then deselect
                        if (chessBoard.squares[rowPos, colPos].PieceOnSquare != null && chessBoard.squares[rowPos, colPos].PieceOnSquare.PieceColour == previousSquare.PieceOnSquare.PieceColour)
                        {
                            return null;
                        }
                        else
                        {
                            return chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos];
                        }
                    }

                    //Check if there is a piece in the way
                    if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos].PieceOnSquare != null)
                    {
                        break;
                    }
                }
                catch { }
            }

            for (int rowAdjust = 1; rowAdjust <= 7; rowAdjust++)
            {
                try
                {
                    AddToBeHighlighted(chessBoard, previousSquare, previousSquare.RowPos + rowAdjust, previousSquare.ColPos);

                    if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos] == chessBoard.squares[rowPos, colPos])
                    {
                        if (chessBoard.squares[rowPos, colPos].PieceOnSquare != null && chessBoard.squares[rowPos, colPos].PieceOnSquare.PieceColour == previousSquare.PieceOnSquare.PieceColour)
                        {
                            return null;
                        }
                        else
                        {
                            return chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos];
                        }
                    }

                    if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos].PieceOnSquare != null)
                    {
                        break;
                    }
                }
                catch { }
            }

            for (int colAdjust = -1; colAdjust >= -7; colAdjust--)
            {
                try
                {
                    AddToBeHighlighted(chessBoard, previousSquare, previousSquare.RowPos, previousSquare.ColPos + colAdjust);

                    if (chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos + colAdjust] == chessBoard.squares[rowPos, colPos])
                    {
                        if (chessBoard.squares[rowPos, colPos].PieceOnSquare != null && chessBoard.squares[rowPos, colPos].PieceOnSquare.PieceColour == previousSquare.PieceOnSquare.PieceColour)
                        {
                            return null;
                        }
                        else
                        {
                            return chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos + colAdjust];
                        }
                    }

                    if (chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos + colAdjust].PieceOnSquare != null)
                    {
                        break;
                    }
                }
                catch { }
            }

            for (int colAdjust = 1; colAdjust <= 7; colAdjust++)
            {
                try
                {
                    AddToBeHighlighted(chessBoard, previousSquare, previousSquare.RowPos, previousSquare.ColPos + colAdjust);

                    if (chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos + colAdjust] == chessBoard.squares[rowPos, colPos])
                    {
                        if (chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos + colAdjust] == chessBoard.squares[rowPos, colPos])
                        {
                            if (chessBoard.squares[rowPos, colPos].PieceOnSquare != null && chessBoard.squares[rowPos, colPos].PieceOnSquare.PieceColour == previousSquare.PieceOnSquare.PieceColour)
                            {
                                return null;
                            }
                            else
                            {
                                return chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos + colAdjust];
                            }
                        }
                    }

                    if (chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos + colAdjust].PieceOnSquare != null)
                    {
                        break;
                    }
                }
                catch { }
            }

            return null;
        }
    }
}
