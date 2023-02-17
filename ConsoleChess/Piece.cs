namespace ConsoleChess;

public class Piece
{
    public char Symbol { get; private set; }
    public Team Team { get; private set; }
    
    public Vector2 Pos;
    
    private Func<List<Piece>, Vector2, Vector2, bool> _canMove;

    public Piece(char symbol, Team team, Vector2 pos,  Func<List<Piece>, Vector2, Vector2, bool> canMove)
    {
        this.Symbol = symbol;
        this.Team = team;
        this.Pos = pos;
        this._canMove = canMove;
    }

    public bool CanMove(List<Piece> board, Vector2 pos) => _canMove(board, this.Pos, pos);
}
