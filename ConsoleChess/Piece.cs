namespace ConsoleChess;

public enum PieceType
{
    Pawn,
    Knight,
    Bishop,
    Rook,
    Queen,
    King
}

public class Piece
{
    public PieceType Type;
    public char Symbol { get; private set; }
    public Team Team { get; private set; }
    
    public Vector2 Pos;
    
    private Func<List<Piece>, Vector2, Vector2, bool> _canMove;

    public Piece(PieceType type, char symbol, Team team, Vector2 pos)
    {
        this.Type = type;
        this.Symbol = symbol;
        this.Team = team;
        this.Pos = pos;

        this._canMove = type switch
        {
            PieceType.Pawn => MovementPattern.Pawn_CanMove,
            PieceType.Knight => MovementPattern.Knight_CanMove,
            PieceType.Bishop => MovementPattern.Bishop_CanMove,
            PieceType.Rook => MovementPattern.Rook_CanMove,
            PieceType.Queen => MovementPattern.Queen_CanMove,
            PieceType.King => MovementPattern.King_CanMove
        };
    }

    public bool CanMove(List<Piece> board, Vector2 pos) => _canMove(board, this.Pos, pos);
}
