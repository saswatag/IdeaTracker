using System.Collections.Generic;

namespace ThoughtsAndIdeas
{
    public class Thoughts
    {
        private List<string> ThoughtsCollection { get; } = new List<string>();
                
        public void NoteDown(string thoughtText)
        {
            ThoughtsCollection.Add(thoughtText);
        }
        public void NoteDown(IReadOnlyCollection<string> thoughts)
        {
            ThoughtsCollection.AddRange(thoughts);
        }

        public IReadOnlyList<string> AllThoughts()
        {
            return ThoughtsCollection.AsReadOnly();
        }
    }
}