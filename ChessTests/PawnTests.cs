using ConsoleChess;

namespace ChessTests;

class PawnTests
{
    [Test]
    public void TestStraight()
    {
        bool res = MovementPattern.Pawn_CanMove(Data.Board, new Vector2(0, 1), new Vector2(0, 2));
        Assert.That(res);
    }

    [Test]
    public void TestTwoStepsAtStart()
    {
        bool res = MovementPattern.Pawn_CanMove(Data.Board, new Vector2(0, 1), new Vector2(0, 3));
        Assert.That(res);
    }
    
    [Test]
    public void TestThreeStepsAtStart()
    {
        bool res = MovementPattern.Pawn_CanMove(Data.Board, new Vector2(0, 1), new Vector2(0, 4));
        Assert.That(!res);
    }
    
    [Test]
    public void TestDiagonal()
    {
        bool res = MovementPattern.Pawn_CanMove(Data.Board, new Vector2(0, 1), new Vector2(1, 2));
        Assert.That(!res);
    }
    
    [Test]
    public void TestSide()
    {
        bool res = MovementPattern.Pawn_CanMove(Data.Board, new Vector2(0, 1), new Vector2(1, 1));
        Assert.That(!res);
    }
    
    [Test]
    public void TestBackwards()
    {
        bool res = MovementPattern.Pawn_CanMove(Data.Board, new Vector2(0, 1), new Vector2(0, 0));
        Assert.That(!res);
    }
}