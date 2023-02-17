using ConsoleChess;

namespace ChessTests;

class KnightTests
{
    [Test]
    public void TestLShape()
    {
        bool res = MovementPattern.Knight_CanMove(Data.Board, new Vector2(1, 0), new Vector2(0, 2));
        Assert.That(res);
    }
    
    [Test]
    public void TestStraight()
    {
        bool res = MovementPattern.Knight_CanMove(Data.Board, new Vector2(1, 0), new Vector2(1, 3));
        Assert.That(!res);
    }
}