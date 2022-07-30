using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PracTest2
{
    class Knight:Piece
    {
        public Knight(Colour pieceColour) : base(pieceColour)
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

            canvas.DrawString("N", TEXT_FONT, TEXT_BRUSH[wOrB], square);

            if (PieceColour == Colour.BLACK)
            {
                canvas.DrawImage(Properties.Resources.BlackKnight, square);
            }
            else
            {
                canvas.DrawImage(Properties.Resources.WhiteKnight, square);
            }
        }

        public override SquareOnBoard Move(Graphics canvas, ChessBoard chessBoard, SquareOnBoard previousSquare, int rowPos, int colPos, Player player)
        {
            for (int rowAdjust = -2; rowAdjust <= 2; rowAdjust=rowAdjust+4)
            {
                for (int colAdjust = -1; colAdjust <= 1; colAdjust=colAdjust+2)
                {
                    try
                    {
                        AddToBeHighlighted(chessBoard, previousSquare, previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjust);

                        if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjust] == chessBoard.squares[rowPos, colPos])
                        {
                            if (chessBoard.squares[rowPos, colPos].PieceOnSquare != null && chessBoard.squares[rowPos, colPos].PieceOnSquare.PieceColour == previousSquare.PieceOnSquare.PieceColour)
                            {
                                return null;
                            }
                            else
                            {
                                return chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjust];
                            }
                        }
                    }
                    catch { }
                }
            }

            for (int rowAdjust = -1; rowAdjust <= 1; rowAdjust = rowAdjust + 2)
            {
                for (int colAdjust = -2; colAdjust <= 2; colAdjust = colAdjust + 4)
                {
                    try
                    {
                        AddToBeHighlighted(chessBoard, previousSquare, previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjust);

                        if ( chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjust] == chessBoard.squares[rowPos, colPos])
                        {
                            if (chessBoard.squares[rowPos, colPos].PieceOnSquare != null && chessBoard.squares[rowPos, colPos].PieceOnSquare.PieceColour == previousSquare.PieceOnSquare.PieceColour)
                            {
                                return null;
                            }
                            else
                            {
                                return chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjust];
                            }
                        }
                    }
                    catch { }
                }
            }
            return null;
        }
    }
}
