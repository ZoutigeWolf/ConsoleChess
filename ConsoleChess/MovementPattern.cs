namespace ConsoleChess;

// ChatGPT go brr

public static class MovementPattern
{
    public static bool Pawn_CanMove(List<Piece> pieces, Vector2 currentPos, Vector2 targetPos)
    {
        // Check if the current position and the target position are the same
        if (currentPos.X == targetPos.X && currentPos.Y == targetPos.Y) {
            // The piece is already at the target position, so it can't move there
            return false;
        }

        // Determine the direction of movement based on the team
        int direction = pieces.Find(p => p.Pos == currentPos)?.Team == Team.White ? 1 : -1;

        // Check if the pawn is moving forward
        if (currentPos.X == targetPos.X && targetPos.Y == currentPos.Y + direction) {
            // Check if there is a piece at the target position
            if (pieces.Find(p => p.Pos == targetPos) == null) {
                // The pawn can move to the target position
                return true;
            }
        }
        // Check if the pawn is moving two squares forward from its starting position
        else if (currentPos.X == targetPos.X && targetPos.Y == currentPos.Y + 2 * direction && currentPos.Y == (pieces.Find(p => p.Pos == currentPos)?.Team == Team.White ? 1 : 6)) {
            // Check if there are no pieces in the way and no pieces at the target position
            if (pieces.Find(p => p.Pos.X == currentPos.X && p.Pos.Y == currentPos.Y + direction) == null && pieces.Find(p => p.Pos == targetPos) == null) {
                // The pawn can move to the target position
                return true;
            }
        }
        // Check if the pawn is capturing a piece diagonally
        else if (Math.Abs(targetPos.X - currentPos.X) == 1 && targetPos.Y == currentPos.Y + direction) {
            Piece? pieceAtTarget = pieces.Find(p => p.Pos == targetPos);
            if (pieceAtTarget != null && pieceAtTarget.Team != pieces.Find(p => p.Pos == currentPos)?.Team) {
                // The pawn can capture the opposing piece at the target position
                return true;
            }
        }

        // The pawn can't move to the target position based on its movement pattern
        return false;
    }
    
    public static bool Knight_CanMove(List<Piece> pieces, Vector2 currentPos, Vector2 targetPos)
    {
        // Check if the current position and the target position are the same
        if (currentPos.X == targetPos.X && currentPos.Y == targetPos.Y) {
            // The piece is already at the target position, so it can't move there
            return false;
        }

        int deltaX = Math.Abs(targetPos.X - currentPos.X);
        int deltaY = Math.Abs(targetPos.Y - currentPos.Y);

        // Check if the target position is in an L shape (2 squares horizontally and 1 square vertically or 2 squares vertically and 1 square horizontally)
        if ((deltaX == 2 && deltaY == 1) || (deltaX == 1 && deltaY == 2))
        {
            // Check if there is no piece at the target position or if there is a piece at the target position of a different team
            Piece? pieceAtTarget = pieces.Find(p => p.Pos == targetPos);
            if (pieceAtTarget == null || pieceAtTarget.Team != pieces.Find(p => p.Pos == currentPos)?.Team)
            {
                // The knight can move to the target position
                return true;
            }
        }

        // The knight can't move to the target position based on its movement pattern
        return false;
    }
    
    public static bool Bishop_CanMove(List<Piece> pieces, Vector2 currentPos, Vector2 targetPos)
    {
        // Check if the current position and the target position are the same
        if (currentPos.X == targetPos.X && currentPos.Y == targetPos.Y) {
            // The piece is already at the target position, so it can't move there
            return false;
        }
    
        // Check if the target position is on the same diagonal as the current position
        int deltaX = targetPos.X - currentPos.X;
        int deltaY = targetPos.Y - currentPos.Y;
        if (Math.Abs(deltaX) != Math.Abs(deltaY)) {
            // The target position is not on the same diagonal, so the bishop can't move there
            return false;
        }
    
        // Check if there are any pieces in the way
        int xDirection = Math.Sign(deltaX);
        int yDirection = Math.Sign(deltaY);
        for (int i = 1; i < Math.Abs(deltaX); i++) {
            Vector2 posToCheck = new Vector2(currentPos.X + i * xDirection, currentPos.Y + i * yDirection);
            if (pieces.Find(p => p.Pos == posToCheck) != null) {
                // There is a piece in the way, so the bishop can't move to the target position
                return false;
            }
        }
    
        // Check if there is a piece at the target position
        Piece? pieceAtTarget = pieces.Find(p => p.Pos == targetPos);
        if (pieceAtTarget == null || pieceAtTarget.Team != pieces.Find(p => p.Pos == currentPos)?.Team) {
            // There is no piece at the target position, or it is an opposing piece, so the bishop can move there
            return true;
        }
    
        // There is a piece of the same team at the target position, so the bishop can't move there
        return false;
    }
    
    public static bool Rook_CanMove(List<Piece> pieces, Vector2 currentPos, Vector2 targetPos)
    {
        // Check if the current position and the target position are the same
        if (currentPos.X == targetPos.X && currentPos.Y == targetPos.Y) {
            // The piece is already at the target position, so it can't move there
            return false;
        }
        
        // Check if the rook is moving horizontally
        if (currentPos.Y == targetPos.Y) {
            // Check if there are no pieces in the way
            int startX = Math.Min(currentPos.X, targetPos.X) + 1;
            int endX = Math.Max(currentPos.X, targetPos.X);
            for (int x = startX; x < endX; x++) {
                if (pieces.Find(p => p.Pos.X == x && p.Pos.Y == currentPos.Y) != null) {
                    // There is a piece in the way, so the rook can't move to the target position
                    return false;
                }
            }
            // Check if there is no piece at the target position, or if it is an opposing piece
            Piece? pieceAtTarget = pieces.Find(p => p.Pos == targetPos);
            if (pieceAtTarget == null || pieceAtTarget.Team != pieces.Find(p => p.Pos == currentPos)?.Team) {
                // The rook can move to the target position
                return true;
            }
        }
        // Check if the rook is moving vertically
        else if (currentPos.X == targetPos.X) {
            // Check if there are no pieces in the way
            int startY = Math.Min(currentPos.Y, targetPos.Y) + 1;
            int endY = Math.Max(currentPos.Y, targetPos.Y);
            for (int y = startY; y < endY; y++) {
                if (pieces.Find(p => p.Pos.X == currentPos.X && p.Pos.Y == y) != null) {
                    // There is a piece in the way, so the rook can't move to the target position
                    return false;
                }
            }
            // Check if there is no piece at the target position, or if it is an opposing piece
            Piece? pieceAtTarget = pieces.Find(p => p.Pos == targetPos);
            if (pieceAtTarget == null || pieceAtTarget.Team != pieces.Find(p => p.Pos == currentPos)?.Team) {
                // The rook can move to the target position
                return true;
            }
        }
        
        // The rook can't move to the target position based on its movement pattern
        return false;
    }
    
    public static bool Queen_CanMove(List<Piece> pieces, Vector2 currentPos, Vector2 targetPos)
    {
        // Check if the current position and the target position are the same
        if (currentPos.X == targetPos.X && currentPos.Y == targetPos.Y) {
            // The piece is already at the target position, so it can't move there
            return false;
        }

        // Check if the queen can move like a rook
        if (Rook_CanMove(pieces, currentPos, targetPos)) {
            return true;
        }

        // Check if the queen can move like a bishop
        if (Bishop_CanMove(pieces, currentPos, targetPos)) {
            return true;
        }

        // The queen can't move to the target position based on its movement pattern
        return false;
    }
    
    public static bool King_CanMove(List<Piece> pieces, Vector2 currentPos, Vector2 targetPos)
    {
        // Check if the current position and the target position are the same
        if (currentPos.X == targetPos.X && currentPos.Y == targetPos.Y) {
            // The piece is already at the target position, so it can't move there
            return false;
        }
    
        // Check if the target position is within one square of the current position
        if (Math.Abs(targetPos.X - currentPos.X) <= 1 && Math.Abs(targetPos.Y - currentPos.Y) <= 1) {
            // Check if there is a piece at the target position and it's not on the same team
            Piece? pieceAtTarget = pieces.Find(p => p.Pos == targetPos);
            if (pieceAtTarget == null || pieceAtTarget.Team != pieces.Find(p => p.Pos == currentPos)?.Team) {
                // The king can move to the target position
                return true;
            }
        }
    
        // The king can't move to the target position based on its movement pattern
        return false;
    }
}