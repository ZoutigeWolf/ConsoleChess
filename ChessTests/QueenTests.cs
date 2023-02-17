using ConsoleChess;

namespace ChessTests;

class QueenTests
{
    [Test]
    public void TestStraight()
    {
        bool res = MovementPattern.Queen_CanMove(Data.Board, new Vector2(0, 2), new Vector2(0, 4));
        Assert.That(res);
    }
    
    [Test]
    public void TestSide()
    {
        bool res = MovementPattern.Queen_CanMove(Data.Board, new Vector2(0, 2), new Vector2(2, 2));
        Assert.That(res);
    }
    
    [Test]
    public void TestDiagonal()
    {
        bool res = MovementPattern.Queen_CanMove(Data.Board, new Vector2(0, 2), new Vector2(2, 4));
        Assert.That(res);
    }

    [Test]
    public void TestOddDiagonal()
    {
        bool res = MovementPattern.Queen_CanMove(Data.Board, new Vector2(0, 2), new Vector2(2, 5));
        Assert.That(!res);
    }
}