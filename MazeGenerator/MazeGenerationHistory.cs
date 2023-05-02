// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="MazeGenerationHistory.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cursors;

public class MazeGenerationHistory : IReadOnlyList<IEnumerable<MazeGenerationAction>>
{
    private readonly List<List<MazeGenerationAction>> _history = new ();

    /// <inheritdoc />
    public int Count => _history.Count;

    /// <inheritdoc />
    public IEnumerable<MazeGenerationAction> this[int index] => _history[index];

    /// <inheritdoc />
    public IEnumerator<IEnumerable<MazeGenerationAction>> GetEnumerator()
    {
        return _history.GetEnumerator();
    }

    internal void AddCursorHistory(Cursor cursor)
    {
        CursorHistory cursorHistory = cursor.ActionHistory;

        for (int i = 0; i < cursorHistory.Count; i++)
        {
            CursorAction action = cursorHistory[i];

            if (_history.Count <= i)
            {
                _history.Add(new ());
            }

            if (!_history[i].Any(c => c.Position == action.Position && c.Direction == action.Direction))
            {
                _history[i].Add(new (action.Position, action.Direction, cursor.Id));
            }
        }
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
