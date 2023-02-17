using ConsoleChess;

namespace ChessTests;

class BishopTests
{
    [Test]
    public void TestDiagonal()
    {
        bool res = MovementPattern.Bishop_CanMove(Data.Board, new Vector2(0, 2), new Vector2(1, 3));
        Assert.That(res);
    }
    
    [Test]
    public void TestStraight()
    {
        bool res = MovementPattern.Bishop_CanMove(Data.Board, new Vector2(0, 2), new Vector2(0, 4));
        Assert.That(!res);
    }

    [Test]
    public void TestDiagonalWithObstacle()
    {
        bool res = MovementPattern.Bishop_CanMove(Data.Board, new Vector2(2, 0), new Vector2(4, 2));
        Assert.That(!res);
    }
}