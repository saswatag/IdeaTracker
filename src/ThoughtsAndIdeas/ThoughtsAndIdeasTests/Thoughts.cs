using System;
using System.Collections;
using System.Collections.Generic;

namespace ThoughtsAndIdeasTests
{
    internal class Thoughts
    {
        private static readonly List<string> ThoughtsCollection = new List<string>();
        internal static void NoteDown(string thoughtText)
        {
            ThoughtsCollection.Add(thoughtText);
        }

        internal static IEnumerable<string> AllThoughts()
        {
            return ThoughtsCollection;
        }
    }
}