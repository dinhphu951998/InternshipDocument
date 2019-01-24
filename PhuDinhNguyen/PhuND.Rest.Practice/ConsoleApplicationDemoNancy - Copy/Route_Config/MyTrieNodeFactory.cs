using Nancy.Routing.Trie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Routing.Constraints;
using Nancy.Routing.Trie.Nodes;
using ConsoleApplicationDemoNancy.RouteConfig;
using Nancy;
using Nancy.Bootstrapper;

namespace ConsoleApplicationDemoNancy.Route_Config
{
    public class MyTrieNodeFactory : TrieNodeFactory
    {
        public MyTrieNodeFactory(IEnumerable<IRouteSegmentConstraint> routeSegmentConstraints) : base(routeSegmentConstraints)
        {
        }

        public override TrieNode GetNodeForSegment(TrieNode parent, string segment)
        {
            if(parent == null)
            {
                return new RootNode(this);
            }

            if(segment.StartsWith("[") && segment.EndsWith("]") && segment.Contains(":"))
            {
                return new MyTrieNode(parent, segment, this);
            }

            return base.GetNodeForSegment(parent, segment);
        }

    }

    

}
