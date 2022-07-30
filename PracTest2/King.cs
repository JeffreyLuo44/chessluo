using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PracTest2
{
    class King:Piece
    {
        private bool _firstMove;
        public King(Colour pieceColour) : base(pieceColour)
        {
            _firstMove = true;
        }

        public bool FirstMove
        {
            get { return _firstMove; }
            set { _firstMove = value; }
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

            canvas.DrawString("K", TEXT_FONT, TEXT_BRUSH[wOrB], square);

            if (PieceColour == Colour.BLACK)
            {
                canvas.DrawImage(Properties.Resources.BlackKing, square);
            }
            else
            {
                canvas.DrawImage(Properties.Resources.WhiteKing, square);
            }
        }

        public bool InDanger(ChessBoard chessBoard, int kingRowPos, int kingColPos, Player player)
        {
            //For diagonal
            int colAdjustIncOrDec = 0;
            int wOrB = 0;

            if (this.PieceColour == Colour.BLACK)
            {
                wOrB = 1;
            }
            else
            {
                wOrB = -1;
            }

            try
            {
                if (chessBoard.squares[kingRowPos + wOrB, kingColPos - 1].PieceOnSquare != null && (chessBoard.squares[kingRowPos + wOrB, kingColPos - 1].PieceOnSquare is Pawn)
                       && chessBoard.squares[kingRowPos + wOrB, kingColPos - 1].PieceOnSquare.PieceColour != this.PieceColour)
                {
                    return true;
                }
            }
            catch { }

            try
            {
                if (chessBoard.squares[kingRowPos + wOrB, kingColPos + 1].PieceOnSquare != null && (chessBoard.squares[kingRowPos + wOrB, kingColPos + 1].PieceOnSquare is Pawn)
                       && chessBoard.squares[kingRowPos + wOrB, kingColPos + 1].PieceOnSquare.PieceColour != this.PieceColour)
                {
                    return true;
                }
            }
            catch { }

            for (int rowAdjust = -2; rowAdjust <= 2; rowAdjust = rowAdjust + 4)
            {
                for (int colAdjust = -1; colAdjust <= 1; colAdjust = colAdjust + 2)
                {
                    try
                    {
                        if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjust].PieceOnSquare != null && chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjust].PieceOnSquare is Knight
                            && chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjust].PieceOnSquare.PieceColour != this.PieceColour)
                        {
                            return true;
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
                        if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjust].PieceOnSquare != null && chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjust].PieceOnSquare is Knight
                            && chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjust].PieceOnSquare.PieceColour != this.PieceColour)
                        {
                            return true;
                        }
                    }
                    catch { }
                }
            }

            for (int rowAdjust = -1; rowAdjust >= -7; rowAdjust--)
            {
                try
                {
                    if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos].PieceOnSquare != null && (chessBoard.squares[kingRowPos + rowAdjust, kingColPos].PieceOnSquare is Rook || chessBoard.squares[kingRowPos + rowAdjust, kingColPos].PieceOnSquare is Queen)
                        && chessBoard.squares[kingRowPos + rowAdjust, kingColPos].PieceOnSquare.PieceColour != this.PieceColour)
                    {
                        return true;
                    }

                    if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos].PieceOnSquare != null)
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
                    if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos].PieceOnSquare != null && (chessBoard.squares[kingRowPos + rowAdjust, kingColPos].PieceOnSquare is Rook || chessBoard.squares[kingRowPos + rowAdjust, kingColPos].PieceOnSquare is Queen)
                        && chessBoard.squares[kingRowPos + rowAdjust, kingColPos].PieceOnSquare.PieceColour != this.PieceColour)
                    {
                        return true;
                    }

                    if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos].PieceOnSquare != null)
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
                    if (chessBoard.squares[kingRowPos, kingColPos + colAdjust].PieceOnSquare != null && (chessBoard.squares[kingRowPos, kingColPos + colAdjust].PieceOnSquare is Rook || chessBoard.squares[kingRowPos, kingColPos + colAdjust].PieceOnSquare is Queen)
                        && chessBoard.squares[kingRowPos, kingColPos + colAdjust].PieceOnSquare.PieceColour != this.PieceColour)
                    {
                        return true;
                    }

                    if (chessBoard.squares[kingRowPos, kingColPos + colAdjust].PieceOnSquare != null)
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
                    if (chessBoard.squares[kingRowPos, kingColPos + colAdjust].PieceOnSquare != null && (chessBoard.squares[kingRowPos, kingColPos + colAdjust].PieceOnSquare is Rook || chessBoard.squares[kingRowPos, kingColPos + colAdjust].PieceOnSquare is Queen)
                       && chessBoard.squares[kingRowPos, kingColPos + colAdjust].PieceOnSquare.PieceColour != this.PieceColour)
                    {
                        return true;
                    }

                    if (chessBoard.squares[kingRowPos, kingColPos + colAdjust].PieceOnSquare != null)
                    {
                        break;
                    }
                }
                catch { }
            }

            for (int rowAdjust = -1; rowAdjust >= -7; rowAdjust--)
            {
                colAdjustIncOrDec--;
                try
                {
                    if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare != null && (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare is Bishop || chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare is Queen)
                       && chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare.PieceColour != this.PieceColour)
                    {
                        return true;
                    }

                    if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare != null)
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
                    if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare != null && (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare is Bishop || chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare is Queen)
                           && chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare.PieceColour != this.PieceColour)
                    {
                        return true;
                    }

                    if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare != null)
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
                    if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare != null && (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare is Bishop || chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare is Queen)
                           && chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare.PieceColour != this.PieceColour)
                    {
                        return true;
                    }

                    if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare != null)
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
                    if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare != null && (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare is Bishop || chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare is Queen)
                           && chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare.PieceColour != this.PieceColour)
                    {
                        return true;
                    }

                    if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjustIncOrDec].PieceOnSquare != null)
                    {
                        break;
                    }
                }
                catch { }
            }

            for (int rowAdjust = -1; rowAdjust <= 1; rowAdjust++)
            {
                for (int colAdjust = -1; colAdjust <= 1; colAdjust++)
                {
                    if (rowAdjust == 0 && colAdjust == 0)
                    {

                    }
                    else
                    {
                        try
                        {
                            if (chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjust].PieceOnSquare != null && chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjust].PieceOnSquare is King
                            && chessBoard.squares[kingRowPos + rowAdjust, kingColPos + colAdjust].PieceOnSquare.PieceColour != this.PieceColour)
                            {
                                return true;
                            }
                        }
                        catch { }
                    }
                }
            }


        return false;
        }


        public override SquareOnBoard Move(Graphics canvas, ChessBoard chessBoard, SquareOnBoard previousSquare, int rowPos, int colPos, Player player)
        {
            int topOrBottomRowNum = 0;
            bool castlingBlocked = true;
            //For Castling
            if (_colour == Piece.Colour.BLACK)
            {
                topOrBottomRowNum = 0;
            }
            else
            {
                topOrBottomRowNum = 7;
            }
            if (FirstMove == true && chessBoard.squares[topOrBottomRowNum, 0].PieceOnSquare is Rook && chessBoard.squares[topOrBottomRowNum, 0].PieceOnSquare.PieceColour == _colour)
            {
                Rook rookToCastle = (Rook)chessBoard.squares[topOrBottomRowNum, 0].PieceOnSquare;
                if (rookToCastle.FirstMove == false)
                {

                }
                else
                {
                    Player thisPlayer = new Player(_colour);

                    //Castle king side

                    for (int colAdjust = 1; colAdjust <= 2; colAdjust++)
                    {
                        //No checks in way
                        if (InDanger(chessBoard, previousSquare.RowPos, previousSquare.ColPos + colAdjust, thisPlayer) == true)
                        {
                            castlingBlocked = true;
                            break;
                        }
                        else
                        {
                            //No pieces in way
                            if (chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos + colAdjust].PieceOnSquare != null)
                            {
                                castlingBlocked = true;
                                break;
                            }
                            else
                            {
                                castlingBlocked = false;
                            }
                        }
                    }

                    if (castlingBlocked == false)
                    {
                        try
                        {
                            AddToBeHighlighted(chessBoard, previousSquare, previousSquare.RowPos, previousSquare.ColPos + 2);

                            if (chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos + 2].PieceOnSquare == null && chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos + 2] == chessBoard.squares[rowPos, colPos])
                            {
                                //Set to empty square
                                chessBoard.squares[topOrBottomRowNum, 7].DrawSquare(canvas, chessBoard.squares[topOrBottomRowNum, 7].DefaultColour);
                                chessBoard.squares[topOrBottomRowNum, 5].PieceOnSquare = rookToCastle;

                                player.SquaresOccupied.Remove(chessBoard.squares[topOrBottomRowNum, 7]);
                                chessBoard.squares[topOrBottomRowNum, 5].PieceOnSquare = rookToCastle;

                                chessBoard.squares[topOrBottomRowNum, 7].PieceOnSquare = null;
                                player.SquaresOccupied.Add(chessBoard.squares[topOrBottomRowNum, 5]);

                                //Move rook to castled square
                                chessBoard.squares[topOrBottomRowNum, 5].DrawSquare(canvas, chessBoard.squares[topOrBottomRowNum, 5].DefaultColour);
                                chessBoard.squares[topOrBottomRowNum, 5].DrawPiece(canvas);

                                rookToCastle.FirstMove = false;
                                this._firstMove = false;

                                //Clears the possible squares that were from the previously occupied pieces for rook
                                chessBoard.squares[topOrBottomRowNum, 5].PossibleSquaresToMoveTo.Clear();

                                return chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos + 2];
                            }
                        }
                        catch { }
                    }

                    castlingBlocked = true;

                    //Castle queen side

                    for (int colAdjust = -1; colAdjust >= -3; colAdjust--)
                    {
                        //No checks in way
                        if (InDanger(chessBoard, previousSquare.RowPos, previousSquare.ColPos + colAdjust, thisPlayer) == true)
                        {
                            castlingBlocked = true;
                            break;
                        }
                        else
                        {
                            //No pieces in way
                            if (chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos + colAdjust].PieceOnSquare != null)
                            {
                                castlingBlocked = true;
                                break;
                            }
                            else
                            {
                                castlingBlocked = false;
                            }
                        }

                    }

                    if (castlingBlocked == false)
                    {
                        try
                        {
                            AddToBeHighlighted(chessBoard, previousSquare, previousSquare.RowPos, previousSquare.ColPos - 2);

                            if (chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos - 2].PieceOnSquare == null && chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos - 2] == chessBoard.squares[rowPos, colPos])
                            {
                                //Set to empty square
                                chessBoard.squares[topOrBottomRowNum, 0].DrawSquare(canvas, chessBoard.squares[topOrBottomRowNum, 0].DefaultColour);
                                chessBoard.squares[topOrBottomRowNum, 3].PieceOnSquare = rookToCastle;

                                player.SquaresOccupied.Remove(chessBoard.squares[topOrBottomRowNum, 0]);
                                chessBoard.squares[topOrBottomRowNum, 3].PieceOnSquare = rookToCastle;

                                chessBoard.squares[topOrBottomRowNum, 0].PieceOnSquare = null;
                                player.SquaresOccupied.Add(chessBoard.squares[topOrBottomRowNum, 3]);

                                //Move rook to castled square
                                chessBoard.squares[topOrBottomRowNum, 3].DrawSquare(canvas, chessBoard.squares[topOrBottomRowNum, 3].DefaultColour);
                                chessBoard.squares[topOrBottomRowNum, 3].DrawPiece(canvas);

                                rookToCastle.FirstMove = false;
                                this._firstMove = false;

                                //Clears the possible squares that were from the previously occupied pieces for rook
                                chessBoard.squares[topOrBottomRowNum, 3].PossibleSquaresToMoveTo.Clear();

                                return chessBoard.squares[previousSquare.RowPos, previousSquare.ColPos - 2];
                            }
                        }
                        catch { }
                    }

                    castlingBlocked = true;
                }
            }

            for (int rowAdjust = -1; rowAdjust<=1; rowAdjust++)
            {
                for(int colAdjust = -1; colAdjust<=1; colAdjust++)
                {
                    if (rowAdjust == 0 && colAdjust == 0)
                    {

                    }
                    else
                    {
                        try
                        {
                            AddToBeHighlighted(chessBoard, previousSquare, previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjust);

                            if (chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjust] == chessBoard.squares[rowPos, colPos])
                            {
                                //Won't allow piece to take pieces of the same colour
                                if (chessBoard.squares[rowPos, colPos].PieceOnSquare != null && chessBoard.squares[rowPos, colPos].PieceOnSquare.PieceColour == previousSquare.PieceOnSquare.PieceColour)
                                {
                                    return null;
                                }
                                else
                                {
                                    _firstMove = false;
                                    return chessBoard.squares[previousSquare.RowPos + rowAdjust, previousSquare.ColPos + colAdjust];
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
  
            return null;
        }
    }
}
