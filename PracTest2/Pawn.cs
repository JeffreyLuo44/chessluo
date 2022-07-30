using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms; //Temporarily

namespace PracTest2
{
    class Pawn : Piece
    {
        private bool _firstMove;
        private bool _playedDoubleMove;
        public Pawn(Colour pieceColour) : base(pieceColour)
        {
            _firstMove = true;
            _playedDoubleMove = false;
        }

        public bool FirstMove
        {
            get { return _firstMove; }
            set { _firstMove = value; }
        }

        public bool PlayedDoubleMove
        {
            get { return _playedDoubleMove; }
            set { _playedDoubleMove = value; }
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

            canvas.DrawString("P", TEXT_FONT, TEXT_BRUSH[wOrB], square);

            if (PieceColour == Colour.BLACK)
            {
                canvas.DrawImage(Properties.Resources.BlackPawn, square);
            }
            else
            {
                canvas.DrawImage(Properties.Resources.WhitePawn, square);
            }
        }

        public override SquareOnBoard Move(Graphics canvas, ChessBoard chessBoard, SquareOnBoard previousSquare, int rowPos, int colPos, Player player)
        {
            int wOrB = 0;
            int firstMoveBlocked = 0;
            int firstMoveWOrB = 0;

            if (FirstMove == true)
            {
                if (PieceColour == Colour.BLACK)
                {
                    firstMoveWOrB = 2;
                    firstMoveBlocked = 1;
                }
                else
                {
                    firstMoveWOrB = -2;
                    firstMoveBlocked = -1;
                }

                //Check there is no piece block the pawn's first move
                if (chessBoard.squares[previousSquare.RowPos + firstMoveBlocked, previousSquare.ColPos].PieceOnSquare != null)
                {

                }
                else
                {
                    try
                    {
                        //Check if the move is made
                        if (chessBoard.squares[previousSquare.RowPos + firstMoveWOrB, previousSquare.ColPos].PieceOnSquare == null && chessBoard.squares[previousSquare.RowPos + firstMoveWOrB, previousSquare.ColPos] == chessBoard.squares[rowPos, colPos])
                        {
                            _firstMove = false;
                            //_playedDoubleMove = true;
                            return chessBoard.squares[previousSquare.RowPos + firstMoveWOrB, previousSquare.ColPos];
                        }

                        //Possible move and pawn cannot use virtual piece highlight method
                        if (chessBoard.squares[previousSquare.RowPos + firstMoveWOrB, previousSquare.ColPos].PieceOnSquare == null)
                        {
                            previousSquare.PossibleSquaresToMoveTo.Add(chessBoard.squares[previousSquare.RowPos + firstMoveWOrB, previousSquare.ColPos]);
                        }
                    }
                    catch { }
                }   
            }

            if (PieceColour == Colour.BLACK)
            {
                wOrB = 1;
            }
            else
            {
                wOrB = -1;
            }

            //Diagonal opposition piece present and clicked on square to move

            try
            {
                //Possible move
                if (chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos - 1].PieceOnSquare != null && chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos - 1].PieceOnSquare.PieceColour != previousSquare.PieceOnSquare.PieceColour)
                {
                    previousSquare.PossibleSquaresToMoveTo.Add(chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos - 1]);
                }

                if (chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos - 1].PieceOnSquare != null && chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos - 1].PieceOnSquare.PieceColour != previousSquare.PieceOnSquare.PieceColour
                    && chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos - 1] == chessBoard.squares[rowPos, colPos])
                {
                    _firstMove = false;

                    return chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos - 1];
                }
            }
            catch { }

            try
            {
                //Possible move
                if (chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos + 1].PieceOnSquare != null && chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos + 1].PieceOnSquare.PieceColour != previousSquare.PieceOnSquare.PieceColour)
                {
                    previousSquare.PossibleSquaresToMoveTo.Add(chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos + 1]);
                }

                if (chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos + 1].PieceOnSquare != null && chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos + 1].PieceOnSquare.PieceColour != previousSquare.PieceOnSquare.PieceColour
                    && chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos + 1] == chessBoard.squares[rowPos, colPos])
                {
                    _firstMove = false;

                    return chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos + 1];
                }
            }
            catch { }

            try
            {
                //Possible move
                if (chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos].PieceOnSquare == null)
                {
                    previousSquare.PossibleSquaresToMoveTo.Add(chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos]);
                }

                //Cannot move forward if there is a piece in the way and clicked on square to move
                if (chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos].PieceOnSquare == null && chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos] == chessBoard.squares[rowPos, colPos])
                {
                    _firstMove = false;

                    return chessBoard.squares[previousSquare.RowPos + wOrB, previousSquare.ColPos];
                }
            }
            catch { }

            return null;
        }
    }
}
