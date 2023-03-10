namespace ConsoleChess;

public class Chess
{
    public static Vector2 BoardSize = new Vector2(8, 8);
    
    public List<Piece> Pieces = new List<Piece>()
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
        
        new Piece(PieceType.Rook,   Symbols.BlackRook,   Team.Black, new Vector2(0, 7)),
        new Piece(PieceType.Knight, Symbols.BlackKnight, Team.Black, new Vector2(1, 7)),
        new Piece(PieceType.Bishop, Symbols.BlackBishop, Team.Black, new Vector2(2, 7)),
        new Piece(PieceType.Queen,  Symbols.BlackQueen,  Team.Black, new Vector2(3, 7)),
        new Piece(PieceType.King,   Symbols.BlackKing,   Team.Black, new Vector2(4, 7)),
        new Piece(PieceType.Bishop, Symbols.BlackBishop, Team.Black, new Vector2(5, 7)),
        new Piece(PieceType.Knight, Symbols.BlackKnight,   Team.Black, new Vector2(6, 7)),
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

    private bool _whiteTurn = true;
    
    public void DoMove()
    {
        DisplayBoard();
        
        Console.WriteLine(Player() + "'s turn");
        Vector2[] move = GetMove();

        Piece? piece1 = FindPiece(move[0]);
        Piece? piece2 = FindPiece(move[1]);

        if (piece1 != null)
            piece1.Pos = move[1];

        if (piece2 != null)
            Pieces.Remove(piece2);

        _whiteTurn = !_whiteTurn;
        
        DoMove();
    }
    
    public Piece? FindPiece(Vector2 pos)
    {
        Piece[] res = Pieces.Where(p => p.Pos.Equals(pos)).ToArray();
        
        return res.Length == 0 ? null : res[0];
    }
    
    public void DisplayBoard()
    {
        List<string> board = new List<string>()
        {
               "     A    B    C    D    E    F    G    H  ",
               "  ┌────┬────┬────┬────┬────┬────┬────┬────┐",
               "8 │ X  │ X  │ X  │ X  │ X  │ X  │ X  │ X  │",
               "  ├────┼────┼────┼────┼────┼────┼────┼────┤",
               "7 │ X  │ X  │ X  │ X  │ X  │ X  │ X  │ X  │",
               "  ├────┼────┼────┼────┼────┼────┼────┼────┤",
               "6 │ X  │ X  │ X  │ X  │ X  │ X  │ X  │ X  │",
               "  ├────┼────┼────┼────┼────┼────┼────┼────┤",
               "5 │ X  │ X  │ X  │ X  │ X  │ X  │ X  │ X  │",
               "  ├────┼────┼────┼────┼────┼────┼────┼────┤",
               "4 │ X  │ X  │ X  │ X  │ X  │ X  │ X  │ X  │",
               "  ├────┼────┼────┼────┼────┼────┼────┼────┤",
               "3 │ X  │ X  │ X  │ X  │ X  │ X  │ X  │ X  │",
               "  ├────┼────┼────┼────┼────┼────┼────┼────┤",
               "2 │ X  │ X  │ X  │ X  │ X  │ X  │ X  │ X  │",
               "  ├────┼────┼────┼────┼────┼────┼────┼────┤",
               "1 │ X  │ X  │ X  │ X  │ X  │ X  │ X  │ X  │",
               "  └────┴────┴────┴────┴────┴────┴────┴────┘"
        };

        for (int y = 0; y < BoardSize.Y; y++)
        {
            for (int x = 0; x < BoardSize.X; x++)
            {
                Vector2 bIndex = new Vector2(5 * x + 4, 2 * y + 2);

                Piece? piece = FindPiece(new Vector2(x, y));

                char[] line = board[^(bIndex.Y)].ToCharArray();
                line[bIndex.X] = piece == null ? ' ' : (char)piece.Symbol;
                board[^(bIndex.Y)] = string.Join("", line);
            }
        }
        
        board.ForEach(l => Console.WriteLine(l));
    }

    private string Player() => _whiteTurn ? "White" : "Black";

    private Vector2[] GetMove()
    {
        Console.WriteLine("Enter move:");
        string input = (Console.ReadLine() ?? "").ToUpper();

        if (input.Length == 0)
        {
            Console.WriteLine("Invalid move");
            return GetMove();
        }

        string[] coords = input.Split(' ');
        
        if (coords.Length != 2)
        {
            Console.WriteLine("Invalid move");
            return GetMove();
        }

        string letters = "ABCDEFGH";
        string numbers = "12345678";
        
        foreach (string c in coords)
        {
            if (!letters.Contains(c[0]) || !numbers.Contains(c[1]))
            {
                Console.WriteLine("Invalid move");
                return GetMove();
            }
        }

        Vector2 fromPos = new Vector2(letters.IndexOf(coords[0][0]), int.Parse(coords[0][1].ToString()) - 1);
        Vector2 toPos = new Vector2(letters.IndexOf(coords[1][0]), int.Parse(coords[1][1].ToString())- 1);

        Piece? piece = FindPiece(fromPos);

        if ((piece?.Team == Team.White && !_whiteTurn) || (piece?.Team == Team.Black && _whiteTurn))
        {
            Console.WriteLine("Invalid move");
            return GetMove();
        }

        if (piece == null || !piece.CanMove(Pieces, toPos))
        {
            Console.WriteLine("Invalid move");
            return GetMove();
        }
        
        return new Vector2[2] { fromPos, toPos };
    }
}
