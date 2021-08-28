using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using ThoughtsAndIdeas;

namespace ThoughtsAndIdeasTests
{
    public class ThoughtsTests
    {
        [Fact]
        public void ThoughtsCanBeNotedDown()
        {
            string thoughtText = "This is a thought that I want to note down";
            var thoughts = new Thoughts();
            thoughts.NoteDown(thoughtText);
            thoughts.AllThoughts().Should().Contain(thoughtText);
        }

        [Fact]
        public void MultipleThoughtsCanBeNotedDown()
        {
            string firstThoughtText = "This is the first thought that I want to note down";
            string secondThoughtText = "This is the second thought that I want to note down";
            string thirdThoughtText = "This is the third thought that I want to note down";

            var thoughts = new Thoughts();
            thoughts.NoteDown(firstThoughtText);
            thoughts.NoteDown(secondThoughtText);
            thoughts.NoteDown(thirdThoughtText);
            thoughts.AllThoughts().Should().Contain(firstThoughtText).And.Contain(secondThoughtText).And.Contain(thirdThoughtText);
        }

        [Fact]
        public void NoteMultipleThoughtsAtOnce()
        {
            string firstThoughtText = "This is the first thought that I want to note down";
            string secondThoughtText = "This is the second thought that I want to note down";
            string thirdThoughtText = "This is the third thought that I want to note down";
            var multipleThoughts = new string[] { firstThoughtText, secondThoughtText, thirdThoughtText };

            var thoughts = new Thoughts();
            thoughts.NoteDown(Array.AsReadOnly(multipleThoughts));
            thoughts.AllThoughts().Should().Contain(firstThoughtText).And.Contain(secondThoughtText).And.Contain(thirdThoughtText);
        }
    }
}
