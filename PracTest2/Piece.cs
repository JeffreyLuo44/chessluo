using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PracTest2
{
    abstract class Piece
    {
        public enum Colour { WHITE, BLACK};
        public static Font TEXT_FONT = new Font("Times New Roman", 16);
        public static SolidBrush[] TEXT_BRUSH = new SolidBrush[] { new SolidBrush(Color.White), new SolidBrush(Color.Black) };

        protected Colour _colour;
        protected bool _selected;
        public Piece(Colour colour)
        {
            _colour = colour;
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public Colour PieceColour
        {
            get { return _colour; }
        }

        public virtual void AddToBeHighlighted(ChessBoard chessBoard, SquareOnBoard previousSquare, int possibleSquareRowPos, int possibleSquareColPos)
        {
            if (chessBoard.squares[possibleSquareRowPos, possibleSquareColPos].PieceOnSquare != null && chessBoard.squares[possibleSquareRowPos, possibleSquareColPos].PieceOnSquare.PieceColour != previousSquare.PieceOnSquare.PieceColour
                       || chessBoard.squares[possibleSquareRowPos, possibleSquareColPos].PieceOnSquare == null)
            {
                previousSquare.PossibleSquaresToMoveTo.Add(chessBoard.squares[possibleSquareRowPos, possibleSquareColPos]);
            }
        }

        public virtual void ShowPossibleMoves(Graphics canvas, SquareOnBoard squaresPossibleMoves)
        {
            foreach (SquareOnBoard possibleSquare in squaresPossibleMoves.PossibleSquaresToMoveTo)
            {
                if (possibleSquare.PieceOnSquare != null && possibleSquare.PieceOnSquare.PieceColour != squaresPossibleMoves.PieceOnSquare.PieceColour)
                {
                    canvas.FillEllipse(Brushes.Red, possibleSquare.XPos + possibleSquare.WIDTH/4, possibleSquare.YPos+possibleSquare.HEIGHT/4, possibleSquare.WIDTH/2, possibleSquare.HEIGHT/2);
                    possibleSquare.DrawPiece(canvas);
                }
                else
                {
                    canvas.FillEllipse(Brushes.Gray, possibleSquare.XPos + possibleSquare.WIDTH / 4, possibleSquare.YPos + possibleSquare.HEIGHT / 4, possibleSquare.WIDTH / 2, possibleSquare.HEIGHT / 2);
                }
            }
        }

        public virtual SquareOnBoard Move(Graphics canvas, ChessBoard chessBoard, SquareOnBoard previousSquare, int rowPos, int colPos, Player player)
        {
            return null;
        }

        public abstract void Draw(Graphics canvas, Rectangle square); 

    }
}
