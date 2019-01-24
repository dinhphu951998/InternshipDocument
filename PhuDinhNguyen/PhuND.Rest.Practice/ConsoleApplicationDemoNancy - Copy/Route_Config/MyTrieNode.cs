using Nancy.Routing.Trie.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Routing.Trie;

namespace ConsoleApplicationDemoNancy.RouteConfig
{
    public class MyTrieNode : TrieNode
    {
        private const int score = 1000;
        private bool checkForEven = false;
        private string segmentName;

        public MyTrieNode(TrieNode parent, string segment, ITrieNodeFactory nodeFactory) : base(parent, segment, nodeFactory)
        {
            ExtractSegment(segment);
        }

        public override int Score
        {
            get
            {
                return score;
            }
        }

        public override SegmentMatch Match(string segment)
        {
            int numberValue;

            if (!int.TryParse(segment, out numberValue))
            {
                return SegmentMatch.NoMatch;
            }

            if (numberValue % 2 == 0 && checkForEven || !checkForEven && numberValue % 2 != 0)
            {
                var match = new SegmentMatch(true);
                match.CapturedParameters.Add(segmentName, numberValue);
                return match;
            }
            return SegmentMatch.NoMatch;
        }

        private void ExtractSegment(string segment)
        {
            if (segment.Contains(":"))
            {
                string innerSegment = this.RouteDefinitionSegment.Trim('[', ']');
                string[] segmentSplit = innerSegment.Split(':');
                segmentName = segmentSplit[0];
                checkForEven = segmentSplit[1].Equals("even");
            }
        }


    }
}
