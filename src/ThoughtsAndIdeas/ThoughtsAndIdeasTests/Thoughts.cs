using System;
using System.Collections;
using System.Collections.Generic;

namespace ThoughtsAndIdeasTests
{
    internal class Thoughts
    {
        private List<string> ThoughtsCollection { get; } = new List<string>();
                
        internal void NoteDown(string thoughtText)
        {
            ThoughtsCollection.Add(thoughtText);
        }

        internal IReadOnlyList<string> AllThoughts()
        {
            return ThoughtsCollection.AsReadOnly();
        }
    }
}