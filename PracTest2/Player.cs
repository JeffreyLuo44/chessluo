using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PracTest2
{
    class Player
    {
        //Squares occupied by pieces
        protected List<SquareOnBoard> _squaresOccupied;
        protected SquareOnBoard _selectedSquare;
        protected Piece.Colour _colour;
        protected bool _inCheck;
        public Player(Piece.Colour colour)
        {
            _colour = colour;
            _squaresOccupied = new List<SquareOnBoard>();
        }

        public Piece.Colour Colour
        {
            get { return _colour; }
            set { _colour = value; }
        }

        public List<SquareOnBoard> SquaresOccupied
        {
            get { return _squaresOccupied; }
        }

        public SquareOnBoard SelectedSquare
        {
            get { return _selectedSquare; }
            set { _selectedSquare = value; }
        }

        public void AssignPieces(ChessBoard chessBoard)
        {
            int pieceSpecificRow = 0;
            //int numOfPiece = 0;
            if (_colour == Piece.Colour.BLACK)
            {
                pieceSpecificRow = 0;
            }
            else
            {
                pieceSpecificRow = 6;
            }

            //Assign squares containing player's pieces
            for (int row = pieceSpecificRow; row <= pieceSpecificRow+1; row++)
            {
                for (int col = 0; col <= chessBoard.NUM_SQUARES_ON_SIDE - 1; col++)
                {
                    _squaresOccupied.Add(chessBoard.squares[row, col]);
                    //MessageBox.Show(_colour.ToString() + " added " + SquaresOccupied[numOfPiece].PieceOnSquare.GetType().ToString());
                    //numOfPiece++;
                }
            }
        }

        public bool InCheck
        {
            get { return _inCheck; }
            set { _inCheck = value; }
        }

        public bool PlayMove(Graphics canvas, ChessBoard chessBoard, Player opponentPlayer, int rowPos, int colPos)
        {
            SquareOnBoard newSquareToMoveTo;
            bool clickPieceAgain = false;
            bool movedPiece = false;

            //If already selected a square
            if (SelectedSquare != null)
            {
                if (SelectedSquare.PossibleSquaresToMoveTo.Count != 0)
                {
                    for (int squareNum = SelectedSquare.PossibleSquaresToMoveTo.Count - 1; squareNum >= 0; squareNum--)
                    {
                        SelectedSquare.PossibleSquaresToMoveTo[squareNum].DrawSquare(canvas, SelectedSquare.PossibleSquaresToMoveTo[squareNum].DefaultColour);
                        if (SelectedSquare.PossibleSquaresToMoveTo[squareNum].PieceOnSquare != null)
                        {
                            SelectedSquare.PossibleSquaresToMoveTo[squareNum].DrawPiece(canvas);
                        }
                        SelectedSquare.PossibleSquaresToMoveTo.RemoveAt(squareNum);
                    }
                }

                //Check if there a new square to move to
                newSquareToMoveTo = SelectedSquare.PieceOnSquare.Move(canvas,chessBoard, SelectedSquare, rowPos, colPos, this);

                if (newSquareToMoveTo != null)
                {
                    //Selected piece moves to new square for player
                    newSquareToMoveTo.PieceOnSquare = _selectedSquare.PieceOnSquare;

                    //If piece is pawn and reaches end row, then promote to queen
                    if (newSquareToMoveTo.PieceOnSquare is Pawn && newSquareToMoveTo.RowPos == 0 || newSquareToMoveTo.PieceOnSquare is Pawn && newSquareToMoveTo.RowPos == 7)
                    {
                        Queen promotedToQueen = new Queen(_colour);
                        newSquareToMoveTo.PieceOnSquare = promotedToQueen;
                    }

                    //Remove previous selected square and add new square to squares occupied. 
                    SquaresOccupied.Remove(_selectedSquare);
                    _selectedSquare.PieceOnSquare = null;
                    _squaresOccupied.Add(newSquareToMoveTo);

                    //Check if not revealing check to self
                    foreach (SquareOnBoard squares in SquaresOccupied)
                    {
                        if (squares.PieceOnSquare is King)
                        {
                            King detectKing = (King)squares.PieceOnSquare;
                            if (detectKing.InDanger(chessBoard, squares.RowPos, squares.ColPos, this) == true)
                            {
                                MessageBox.Show("Invalid move. You will or will still be in check!");
                                
                                //Reverse the new move
                                SquaresOccupied.Add(_selectedSquare);
                                _selectedSquare.PieceOnSquare = newSquareToMoveTo.PieceOnSquare;

                                if (_selectedSquare.PieceOnSquare is Pawn)
                                {
                                    //Give pawn right to move two squares forward again
                                    Pawn setBackPawn = (Pawn)_selectedSquare.PieceOnSquare;
                                    if (setBackPawn.FirstMove == false)
                                    {
                                        setBackPawn.FirstMove = true;
                                    }
                                }

                                _squaresOccupied.Remove(newSquareToMoveTo);
                                newSquareToMoveTo.PossibleSquaresToMoveTo.Clear();
                                newSquareToMoveTo.PieceOnSquare = null;

                                //Unselect the selected square
                                SelectedSquare.DrawSquare(canvas, SelectedSquare.DefaultColour);
                                SelectedSquare.DrawPiece(canvas);
                                _selectedSquare = null;

                                return movedPiece;
                            }
                            break;
                        }
                    }

                    //Drawing piece at new square
                    newSquareToMoveTo.DrawSquare(canvas, newSquareToMoveTo.DefaultColour);
                    newSquareToMoveTo.DrawPiece(canvas);

                    //Set the previous selected square to default colour
                    SelectedSquare.DrawSquare(canvas, SelectedSquare.DefaultColour);

                    foreach (SquareOnBoard squares in opponentPlayer.SquaresOccupied)
                    {
                        if (squares.PieceOnSquare is King)
                        {
                            King detectKing = (King)squares.PieceOnSquare;
                            if (detectKing.InDanger(chessBoard, squares.RowPos, squares.ColPos, opponentPlayer) == true)
                            {
                                MessageBox.Show("Check!");
                            }
                            break;
                        }
                    }

                    //Clears the possible squares that were from the previously occupied pieces
                    _selectedSquare.PossibleSquaresToMoveTo.Clear();
                    movedPiece = true;
                }
                //Deselecting (no piece moves). Set the previous selected square to default colour
                else
                {
                    //If clicked same square again
                    if (chessBoard.squares[rowPos, colPos] == SelectedSquare)
                    {
                        clickPieceAgain = true;
                    }

                    SelectedSquare.DrawSquare(canvas, SelectedSquare.DefaultColour);
                    SelectedSquare.DrawPiece(canvas);
                    //Clear possible squares to move to in case a newly moved piece is blocking
                    SelectedSquare.PossibleSquaresToMoveTo.Clear();
                }
                _selectedSquare = null;
            }

            //If there is a piece on square to select (and the piece was not clicked twice in a row)
            if (chessBoard.squares[rowPos, colPos].PieceOnSquare != null && movedPiece == false && clickPieceAgain == false)
            {
                if (chessBoard.squares[rowPos, colPos].PieceOnSquare.PieceColour != _colour)
                {
                    MessageBox.Show("That is not your piece!");
                }
                else
                {
                    _selectedSquare = chessBoard.squares[rowPos, colPos];
                    SelectedSquare.PieceOnSquare.Selected = true;
                    SelectedSquare.Highlight(canvas);
                    SelectedSquare.DrawPiece(canvas);
                    SelectedSquare.PieceOnSquare.Move(canvas, chessBoard, SelectedSquare, rowPos, colPos, this);
                    SelectedSquare.PieceOnSquare.ShowPossibleMoves(canvas, SelectedSquare);
                }
            }

            return movedPiece;
        }
    }
}
