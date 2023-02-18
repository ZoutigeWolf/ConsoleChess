using ConsoleChess;

namespace ChessTests;

static class Data
{
    public static List<Piece> Board = new List<Piece>()
    {
        new Piece(PieceType.Rook,   Symbols.WhiteRook,   Team.White, new Vector2(0, 0)),
        new Piece(PieceType.Knight, Symbols.WhiteKnight, Team.White, new Vector2(1, 0)),
        new Piece(PieceType.Bishop, Symbols.WhiteBishop, Team.White, new Vector2(2, 0)),
        new Piece(PieceType.Queen,  Symbols.WhiteQueen,  Team.White, new Vector2(3, 0)),
        new Piece(PieceType.King,   Symbols.WhiteKing,   Team.White, new Vector2(4, 0)),
        new Piece(PieceType.Bishop, Symbols.WhiteBishop, Team.White, new Vector2(5, 0)),
        new Piece(PieceType.Knight, Symbols.WhiteKnight, Team.White, new Vector2(6, 0)),
        new Piece(PieceType.Rook,   Symbols.WhiteRook,   Team.White, new Vector2(7, 0)),
        
        new Piece(PieceType.Pawn, Symbols.WhitePawn, Team.White, new Vector2(0, 1)),
        new Piece(PieceType.Pawn, Symbols.WhitePawn, Team.White, new Vector2(1, 1)),
        new Piece(PieceType.Pawn, Symbols.WhitePawn, Team.White, new Vector2(2, 1)),
        new Piece(PieceType.Pawn, Symbols.WhitePawn, Team.White, new Vector2(3, 1)),
        new Piece(PieceType.Pawn, Symbols.WhitePawn, Team.White, new Vector2(4, 1)),
        new Piece(PieceType.Pawn, Symbols.WhitePawn, Team.White, new Vector2(5, 1)),
        new Piece(PieceType.Pawn, Symbols.WhitePawn, Team.White, new Vector2(6, 1)),
        new Piece(PieceType.Pawn, Symbols.WhitePawn, Team.White, new Vector2(7, 1)),
        
        new Piece(PieceType.Rook,   Symbols.BlackPawn,   Team.Black, new Vector2(0, 7)),
        new Piece(PieceType.Knight, Symbols.BlackKnight, Team.Black, new Vector2(1, 7)),
        new Piece(PieceType.Bishop, Symbols.BlackBishop, Team.Black, new Vector2(2, 7)),
        new Piece(PieceType.Queen,  Symbols.BlackQueen,  Team.Black, new Vector2(3, 7)),
        new Piece(PieceType.King,   Symbols.BlackKing,   Team.Black, new Vector2(4, 7)),
        new Piece(PieceType.Bishop, Symbols.BlackBishop, Team.Black, new Vector2(5, 7)),
        new Piece(PieceType.Knight, Symbols.BlackPawn,   Team.Black, new Vector2(6, 7)),
        new Piece(PieceType.Rook,   Symbols.BlackRook,   Team.Black, new Vector2(7, 7)),
        
        new Piece(PieceType.Pawn, Symbols.BlackPawn, Team.Black, new Vector2(0, 6)),
        new Piece(PieceType.Pawn, Symbols.BlackPawn, Team.Black, new Vector2(1, 6)),
        new Piece(PieceType.Pawn, Symbols.BlackPawn, Team.Black, new Vector2(2, 6)),
        new Piece(PieceType.Pawn, Symbols.BlackPawn, Team.Black, new Vector2(3, 6)),
        new Piece(PieceType.Pawn, Symbols.BlackPawn, Team.Black, new Vector2(4, 6)),
        new Piece(PieceType.Pawn, Symbols.BlackPawn, Team.Black, new Vector2(5, 6)),
        new Piece(PieceType.Pawn, Symbols.BlackPawn, Team.Black, new Vector2(6, 6)),
        new Piece(PieceType.Pawn, Symbols.BlackPawn, Team.Black, new Vector2(7, 6)),
    };
}