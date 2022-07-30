using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PracTest2
{
    class Bishop:Piece
    {
        public Bishop(Colour pieceColour) : base(pieceColour)
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

            canvas.DrawString("B", TEXT_FONT, TEXT_BRUSH[wOrB], square);

            if (PieceColour == Colour.BLACK)
            {
                canvas.DrawImage(Properties.Resources.BlackBishop, square);
            }
            else
            {
                canvas.DrawImage(Properties.Resources.WhiteBishop, square);
            }
        }

        public override SquareOnBoard Move(Graphics canvas, ChessBoard chessBoard, SquareOnBoard previousSquare, int rowPos, int colPos, Player player)
        {
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

            return null;
        }
    }
}
