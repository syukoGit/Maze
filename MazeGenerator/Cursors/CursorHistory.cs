// -----------------------------------------------------------------------
//  <copyright project="MazeGenerator" file="CursorHistory.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MazeGenerator.Cursors;

using System.Collections;
using System.Collections.Generic;

internal sealed class CursorHistory : IReadOnlyList<CursorAction>
{
    private readonly List<CursorAction> _generationHistory = new ();

    public CursorHistory()
    {
    }

    public CursorHistory(CursorHistory parentActionHistory)
    {
        _generationHistory.AddRange(parentActionHistory._generationHistory);
    }

    /// <inheritdoc />
    public int Count => _generationHistory.Count;

    /// <inheritdoc />
    public CursorAction this[int index] => _generationHistory[index];

    /// <inheritdoc />
    public IEnumerator<CursorAction> GetEnumerator()
    {
        return _generationHistory.GetEnumerator();
    }

    internal void Add((int, int) position, EDirection direction)
    {
        _generationHistory.Add(new (position, direction));
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
