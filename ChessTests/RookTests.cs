using ConsoleChess;

namespace ChessTests;

class RookTests
{
    [Test]
    public void TestStraight()
    {
        bool res = MovementPattern.Rook_CanMove(Data.Board, new Vector2(0, 2), new Vector2(0, 4));
        Assert.That(res);
    }
    
    [Test]
    public void TestSide()
    {
        bool res = MovementPattern.Rook_CanMove(Data.Board, new Vector2(0, 2), new Vector2(2, 2));
        Assert.That(res);
    }
    
    [Test]
    public void TestDiagonal()
    {
        bool res = MovementPattern.Rook_CanMove(Data.Board, new Vector2(0, 2), new Vector2(2, 4));
        Assert.That(!res);
    }
}