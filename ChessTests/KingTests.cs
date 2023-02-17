using ConsoleChess;

namespace ChessTests;

class KingTests
{
    [Test]
    public void TestStraightOne()
    {
        bool res = MovementPattern.King_CanMove(Data.Board, new Vector2(0, 2), new Vector2(0, 3));
        Assert.That(res);
    }
    
    [Test]
    public void TestSideOne()
    {
        bool res = MovementPattern.King_CanMove(Data.Board, new Vector2(0, 2), new Vector2(1, 2));
        Assert.That(res);
    }
    
    [Test]
    public void TestDiagonalOne()
    {
        bool res = MovementPattern.King_CanMove(Data.Board, new Vector2(0, 2), new Vector2(1, 3));
        Assert.That(res);
    }
    
    [Test]
    public void TestStraightTwo()
    {
        bool res = MovementPattern.King_CanMove(Data.Board, new Vector2(0, 2), new Vector2(0, 4));
        Assert.That(!res);
    }
    
    [Test]
    public void TestSideTwo()
    {
        bool res = MovementPattern.King_CanMove(Data.Board, new Vector2(0, 2), new Vector2(2, 2));
        Assert.That(!res);
    }
    
    [Test]
    public void TestDiagonalTwo()
    {
        bool res = MovementPattern.King_CanMove(Data.Board, new Vector2(0, 2), new Vector2(2, 4));
        Assert.That(!res);
    }
}