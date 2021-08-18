using System;
using Xunit;
using FluentAssertions;

namespace ThoughtsAndIdeasTests
{
    public class ThoughtsTests
    {
        [Fact]
        public void ThoughtsCanBeNotedDown()
        {
            string thoughtText = "This is a thought that I want to note down";
            Thoughts.NoteDown(thoughtText);
            Thoughts.AllThoughts().Should().Contain(thoughtText);
        }
    }
}
