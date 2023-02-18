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
    
    public static bool IsCheckmate(List<Piece> pieces, Team team)
    {
        // Check if the team is in check
        if (!IsInCheck(pieces, team)) {
            return false;
        }
        
        // Check if the king can move to a safe position
        Piece? king = pieces.Find(p => p.Type == PieceType.King && p.Team == team);

        if (king == null)
        {
            return false;
        }
        
        foreach (var move in GetKingMoves(pieces, king.Pos))
        {
            // Move the king to the new position and check if it's still in check
            var oldPos = king.Pos;
            king.Pos = move;
            bool stillInCheck = IsInCheck(pieces, team);
            king.Pos = oldPos;

            // If the king is not in check in the new position, it's not checkmate
            if (!stillInCheck) {
                return false;
            }
        }

        // Check if any piece can capture the attacking piece
        Piece? attacker = GetAttackingPiece(pieces, king);
        if (attacker == null) {
            // There is no attacking piece, so it can't be checkmate
            return false;
        }

        foreach (var piece in pieces)
        {
            if (piece.Team == team && piece.Type != PieceType.King)
            {
                foreach (var move in GetPossibleMoves(pieces, piece.Pos))
                {
                    // Move the piece to the new position and check if the king is still in check
                    var oldPos = piece.Pos;
                    Piece? capturedPiece = pieces.Find(p => p.Pos == move);

                    // If the move is a capture and the captured piece is the attacking piece, the king is not in checkmate
                    if (capturedPiece != null && capturedPiece == attacker) {
                        return false;
                    }

                    // Move the piece and check if the king is still in check
                    piece.Pos = move;
                    bool stillInCheck = IsInCheck(pieces, team);
                    piece.Pos = oldPos;

                    // If the king is not in check in the new position, it's not checkmate
                    if (!stillInCheck) {
                        return false;
                    }
                }
            }
        }

        // The king is in checkmate
        return true;
    }

    public static bool IsInCheck(List<Piece> pieces, Team team)
    {
        // Get the king for the specified team
        Piece? king = pieces.Find(p => p.Type == PieceType.King && p.Team == team);
        if (king == null) {
            // The king is missing, so this should never happen in a valid game
            throw new InvalidOperationException($"No {team} king found");
        }

        // Check if any of the opposing team's pieces can capture the king
        Team opposingTeam = team == Team.White ? Team.Black : Team.White;
        foreach (Piece piece in pieces) {
            if (piece.Team == opposingTeam && IsValidCapture(pieces, piece.Pos, king.Pos)) {
                return true;
            }
        }

        return false;
    }

    public static bool IsValidCapture(List<Piece> pieces, Vector2 currentPos, Vector2 targetPos)
    {
        // Check if the current position and the target position are the same
        if (currentPos == targetPos) {
            // The target position is the same as the current position, so it is not a valid capture
            return false;
        }

        // Check if there is a piece at the current position
        Piece? currentPiece = pieces.Find(p => p.Pos == currentPos);
        if (currentPiece == null) {
            // There is no piece at the current position, so it is not a valid capture
            return false;
        }

        // Check if there is a piece at the target position
        Piece? targetPiece = pieces.Find(p => p.Pos == targetPos);
        if (targetPiece == null) {
            // There is no piece at the target position, so it is not a valid capture
            return false;
        }

        // Check if the pieces are on different teams
        if (currentPiece.Team == targetPiece.Team) {
            // The pieces are on the same team, so it is not a valid capture
            return false;
        }

        // Check if the attacking piece can capture the defending piece
        if (!GetPossibleMoves(pieces, currentPiece.Pos).Contains(targetPos)) {
            // The attacking piece cannot capture the defending piece, so it is not a valid capture
            return false;
        }

        // The capture is valid
        return true;
    }
    
    public static Piece? GetAttackingPiece(List<Piece> pieces, Piece king)
    {
        foreach (Piece piece in pieces)
        {
            if (piece.Team != king.Team)
            {
                List<Vector2> possibleMoves = GetPossibleMoves(pieces, piece.Pos);
                if (possibleMoves.Contains(king.Pos))
                {
                    return piece;
                }
            }
        }
        return null;
    }
    
    public static List<Vector2> GetPossibleMoves(List<Piece> pieces, Vector2 pos)
    {
        // Get the piece at the given position
        Piece? piece = pieces.Find(p => p.Pos == pos);

        // Check if the piece exists
        if (piece == null) {
            return new List<Vector2>();
        }

        // Call the appropriate movement method based on the piece type
        if (piece.Type == PieceType.Pawn) {
            return GetPawnMoves(pieces, pos);
        } else if (piece.Type == PieceType.Knight) {
            return GetKnightMoves(pieces, pos);
        } else if (piece.Type == PieceType.Bishop) {
            return GetDiagonalMoves(pieces, pos);
        } else if (piece.Type == PieceType.Rook) {
            return GetStraightMoves(pieces, pos, 16);
        } else if (piece.Type == PieceType.Queen) {
            List<Vector2> diagonalMoves = GetDiagonalMoves(pieces, pos);
            List<Vector2> straightMoves = GetStraightMoves(pieces, pos, 16);
            diagonalMoves.AddRange(straightMoves);
            return diagonalMoves;
        } else if (piece.Type == PieceType.King) {
            return GetKingMoves(pieces, pos);
        } else {
            // Invalid piece type
            return new List<Vector2>();
        }
    }
    
    public static List<Vector2> GetPawnMoves(List<Piece> pieces, Vector2 pos)
    {
        List<Vector2> moves = new List<Vector2>();
        Piece? pawn = pieces.Find(p => p.Pos == pos && p.Type == PieceType.Pawn);

        // Determine the direction of movement based on the team
        int direction = pawn?.Team == Team.White ? -1 : 1;

        // Check for a one-square move
        Vector2 targetPos = new Vector2(pos.X, pos.Y + direction);
        Piece? captured = pieces.Find(p => p.Pos == pos);
        if (captured == null || captured.Team != pawn?.Team) moves.Add(targetPos);

        // Check for a two-square move from the starting position
        if ((pawn?.Team == Team.White && pos.Y == 6) || (pawn?.Team == Team.Black && pos.Y == 1))
        {
            targetPos = new Vector2(pos.X, pos.Y + 2 * direction);
            captured = pieces.Find(p => p.Pos == pos);
            if (captured == null || captured.Team != pawn.Team) moves.Add(targetPos);
        }

        // Check for captures
        targetPos = new Vector2(pos.X - 1, pos.Y + direction);
        if (IsValidCapture(pieces, pos, targetPos))
        {
            moves.Add(targetPos);
        }

        targetPos = new Vector2(pos.X + 1, pos.Y + direction);
        if (IsValidCapture(pieces, pos, targetPos))
        {
            moves.Add(targetPos);
        }

        return moves;
    }

    public static List<Vector2> GetKnightMoves(List<Piece> pieces, Vector2 pos)
    {
        Piece? piece = pieces.Find(p => p.Pos == pos);

        if (piece == null)
        {
            return new List<Vector2>();
        }
        
        List<Vector2> moves = new List<Vector2>();
        int[,] offsets = new int[,] { { -1, -2 }, { -2, -1 }, { -2, 1 }, { -1, 2 }, { 1, 2 }, { 2, 1 }, { 2, -1 }, { 1, -2 } };

        for (int i = 0; i < 8; i++)
        {
            int x1 = piece.Pos.X + offsets[i, 0];
            int y1 = piece.Pos.Y + offsets[i, 1];
            if (x1 < 0 || x1 > 7 || y1 < 0 || y1 > 7) continue;
            Piece? captured = pieces.Find(p => p.Pos.X == x1 && p.Pos.Y == y1);
            if (captured == null || captured.Team != piece.Team) moves.Add(new Vector2(x1, y1));
        }

        return moves;
    }
    
    public static List<Vector2> GetDiagonalMoves(List<Piece> pieces, Vector2 currentPos)
    {
        List<Vector2> moves = new List<Vector2>();
        Piece? currentPiece = pieces.Find(p => p.Pos == currentPos);
        int x = currentPos.X;
        int y = currentPos.Y;
        
        // Check moves to the top-right
        while (x < 7 && y > 0) {
            x++;
            y--;
            Vector2 pos = new Vector2(x, y);
            Piece? pieceAtPos = pieces.Find(p => p.Pos == pos);
            if (pieceAtPos == null) {
                moves.Add(pos);
            } else {
                if (pieceAtPos.Team != currentPiece?.Team) {
                    moves.Add(pos);
                }
                break;
            }
        }
        
        // Check moves to the bottom-right
        x = currentPos.X;
        y = currentPos.Y;
        while (x < 7 && y < 7) {
            x++;
            y++;
            Vector2 pos = new Vector2(x, y);
            Piece? pieceAtPos = pieces.Find(p => p.Pos == pos);
            if (pieceAtPos == null) {
                moves.Add(pos);
            } else {
                if (pieceAtPos.Team != currentPiece?.Team) {
                    moves.Add(pos);
                }
                break;
            }
        }
        
        // Check moves to the top-left
        x = currentPos.X;
        y = currentPos.Y;
        while (x > 0 && y > 0) {
            x--;
            y--;
            Vector2 pos = new Vector2(x, y);
            Piece? pieceAtPos = pieces.Find(p => p.Pos == pos);
            if (pieceAtPos == null) {
                moves.Add(pos);
            } else {
                if (pieceAtPos.Team != currentPiece?.Team) {
                    moves.Add(pos);
                }
                break;
            }
        }
        
        // Check moves to the bottom-left
        x = currentPos.X;
        y = currentPos.Y;
        while (x > 0 && y < 7) {
            x--;
            y++;
            Vector2 pos = new Vector2(x, y);
            Piece? pieceAtPos = pieces.Find(p => p.Pos == pos);
            if (pieceAtPos == null) {
                moves.Add(pos);
            } else {
                if (pieceAtPos.Team != currentPiece?.Team) {
                    moves.Add(pos);
                }
                break;
            }
        }
        
        return moves;
    }
    
    public static List<Vector2> GetStraightMoves(List<Piece> pieces, Vector2 pos, int maxSteps)
    {
        List<Vector2> moves = new List<Vector2>();

        int x = pos.X;
        int y = pos.Y;

        // Check for moves in all four directions
        for (int i = 1; i <= maxSteps; i++)
        {
            // Check up
            if (y - i >= 0)
            {
                Vector2 move = new Vector2(x, y - i);
                Piece? p = pieces.Find(piece => piece.Pos == move);
                if (p == null)
                {
                    moves.Add(move);
                }
                else
                {
                    // If there is a piece of the opposite color, add it as a valid capture
                    if (p.Team != pieces.Find(piece => piece.Pos == pos)?.Team)
                    {
                        moves.Add(move);
                    }
                    // If there is a piece of the same color, we can't move any further in this direction
                    break;
                }
            }

            // Check down
            if (y + i <= 7)
            {
                Vector2 move = new Vector2(x, y + i);
                Piece? p = pieces.Find(piece => piece.Pos == move);
                if (p == null)
                {
                    moves.Add(move);
                }
                else
                {
                    if (p.Team != pieces.Find(piece => piece.Pos == pos)?.Team)
                    {
                        moves.Add(move);
                    }
                    break;
                }
            }

            // Check left
            if (x - i >= 0)
            {
                Vector2 move = new Vector2(x - i, y);
                Piece? p = pieces.Find(piece => piece.Pos == move);
                if (p == null)
                {
                    moves.Add(move);
                }
                else
                {
                    if (p.Team != pieces.Find(piece => piece.Pos == pos)?.Team)
                    {
                        moves.Add(move);
                    }
                    break;
                }
            }

            // Check right
            if (x + i <= 7)
            {
                Vector2 move = new Vector2(x + i, y);
                Piece? p = pieces.Find(piece => piece.Pos == move);
                if (p == null)
                {
                    moves.Add(move);
                }
                else
                {
                    if (p.Team != pieces.Find(piece => piece.Pos == pos)?.Team)
                    {
                        moves.Add(move);
                    }
                    break;
                }
            }
        }

        return moves;
    }
    
    public static List<Vector2> GetKingMoves(List<Piece> pieces, Vector2 pos)
    {
        List<Vector2> moves = new List<Vector2>();
    
        // Define all possible moves for a king
        int[,] kingMoves = {
            { -1, -1 }, { -1, 0 }, { -1, 1 },
            { 0, -1 },             { 0, 1 },
            { 1, -1 }, { 1, 0 }, { 1, 1 }
        };
    
        // Loop through all possible moves for the king
        for (int i = 0; i < kingMoves.GetLength(0); i++)
        {
            int x = pos.X + kingMoves[i, 0];
            int y = pos.Y + kingMoves[i, 1];
        
            // Check if the move is on the board
            if (x < 0 || x > 7 || y < 0 || y > 7) {
                continue;
            }
        
            Vector2 targetPos = new Vector2(x, y);
        
            // Check if the target position is occupied by a piece on the same team
            if (pieces.Any(p1 => p1.Pos == targetPos && p1.Team == pieces.Find(p2 => p2.Pos == pos)?.Team)) {
                continue;
            }
        
            // Add the valid move to the list of possible moves
            moves.Add(targetPos);
        }
    
        return moves;
    }
}