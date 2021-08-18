using System;
using System.Collections;
using System.Collections.Generic;

namespace ThoughtsAndIdeasTests
{
    internal class Thoughts
    {
        internal static void NoteDown(string thoughtText)
        {
            
        }

        internal static IEnumerable<string> AllThoughts()
        {
            //return new List<string>() { "This is a thought that I want to note down" };

            yield return "This is a thought that I want to note down";

        }
    }
}