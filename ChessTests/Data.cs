using ConsoleChess;

namespace ChessTests;

static class Data
{
    public static List<Piece> Board = new List<Piece>()
    {
        new Piece('♖', Team.White, new Vector2(0, 0), MovementPattern.Rook_CanMove),
        new Piece('♘', Team.White, new Vector2(1, 0), MovementPattern.Knight_CanMove),
        new Piece('♗', Team.White, new Vector2(2, 0), MovementPattern.Bishop_CanMove),
        new Piece('♕', Team.White, new Vector2(3, 0), MovementPattern.Queen_CanMove),
        new Piece('♔', Team.White, new Vector2(4, 0), MovementPattern.King_CanMove),
        new Piece('♗', Team.White, new Vector2(5, 0), MovementPattern.Bishop_CanMove),
        new Piece('♘', Team.White, new Vector2(6, 0), MovementPattern.Knight_CanMove),
        new Piece('♖', Team.White, new Vector2(7, 0), MovementPattern.Rook_CanMove),
        
        new Piece('♙', Team.White, new Vector2(0, 1), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.White, new Vector2(1, 1), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.White, new Vector2(2, 1), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.White, new Vector2(3, 1), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.White, new Vector2(4, 1), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.White, new Vector2(5, 1), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.White, new Vector2(6, 1), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.White, new Vector2(7, 1), MovementPattern.Pawn_CanMove),
        
        new Piece('♜', Team.Black, new Vector2(0, 7), MovementPattern.Rook_CanMove),
        new Piece('♞', Team.Black, new Vector2(1, 7), MovementPattern.Knight_CanMove),
        new Piece('♝', Team.Black, new Vector2(2, 7), MovementPattern.Bishop_CanMove),
        new Piece('♛', Team.Black, new Vector2(3, 7), MovementPattern.Queen_CanMove),
        new Piece('♚', Team.Black, new Vector2(4, 7), MovementPattern.King_CanMove),
        new Piece('♝', Team.Black, new Vector2(5, 7), MovementPattern.Bishop_CanMove),
        new Piece('♞', Team.Black, new Vector2(6, 7), MovementPattern.Knight_CanMove),
        new Piece('♜', Team.Black, new Vector2(7, 7), MovementPattern.Rook_CanMove),
        
        new Piece('♙', Team.Black, new Vector2(0, 6), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.Black, new Vector2(1, 6), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.Black, new Vector2(2, 6), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.Black, new Vector2(3, 6), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.Black, new Vector2(4, 6), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.Black, new Vector2(5, 6), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.Black, new Vector2(6, 6), MovementPattern.Pawn_CanMove),
        new Piece('♙', Team.Black, new Vector2(7, 6), MovementPattern.Pawn_CanMove),
    };
}