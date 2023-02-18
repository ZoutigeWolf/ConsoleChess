using ConsoleChess;

namespace ChessTests;

class MovementTests
{
    public List<Piece> TestBoard1 = new List<Piece>()
    {
        new Piece(PieceType.King, Symbols.WhiteKing, Team.White, new Vector2(4, 7)),
        
        new Piece(PieceType.Queen, Symbols.BlackQueen, Team.Black, new Vector2(4, 6)),
        new Piece(PieceType.Knight, Symbols.BlackKnight, Team.Black, new Vector2(3, 4)),
    };
    
    public List<Piece> TestBoard2 = new List<Piece>()
    {
        new Piece(PieceType.Queen, Symbols.BlackQueen, Team.Black, new Vector2(1, 1)),
        new Piece(PieceType.Knight, Symbols.WhiteKnight, Team.White, new Vector2(0, 0)),
    };

    [Test]
    public void TestNoCheck()
    {
        bool res = MovementPattern.IsInCheck(Data.Board, Team.White);
        Assert.That(!res);
    }

    [Test]
    public void TestNoCheckmate()
    {
        bool res = MovementPattern.IsCheckmate(Data.Board, Team.White);
        Assert.That(!res);
    }
    
    [Test]
    public void TestCheck()
    {
        bool res = MovementPattern.IsInCheck(TestBoard1, Team.White);
        Assert.That(res);
    }

    [Test]
    public void TestCheckmate()
    {
        bool res = MovementPattern.IsCheckmate(TestBoard1, Team.White);
        Assert.That(res);
    }

    [Test]
    public void TestValidCapture()
    {
        bool res = MovementPattern.IsValidCapture(TestBoard2, new Vector2(1, 1), new Vector2(0, 0));
        Assert.That(res);
    }
    
    [Test]
    public void TesInvalidCapture()
    {
        bool res = MovementPattern.IsValidCapture(TestBoard2, new Vector2(0, 0), new Vector2(1, 1));
        Assert.That(!res);
    }
}