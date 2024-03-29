/// UnityUtils https://github.com/mortennobel/UnityUtils
/// By Morten Nobel-Jørgensen
/// License lgpl 3.0 (http://www.gnu.org/licenses/lgpl-3.0.txt)


using System;
using System.Collections.Generic;

/// <summary>
/// Based on uniform-cost-search/A* from the book
/// Artificial Intelligence: A Modern Approach 3rd Ed by Russell/Norvig 
/// </summary>
/// 
namespace UnityAstar
{
    public class ShortestPathGraphSearch<State, Action>
    {
        /// <summary>
        /// Workaround for http://monotouch.net/Documentation/Limitations Value types as Dictionary Keys (iOS)
        /// </summary>
        class Float : IComparable<Float>
        {
            public readonly float f;

            public Float(float f)
            {
                this.f = f;
            }

            public int CompareTo(Float other)
            {
                return f.CompareTo(other.f);
            }

            public override bool Equals(System.Object obj)
            {
                // If parameter is null return false.
                if (obj == null)
                {
                    return false;
                }

                // If parameter cannot be cast to Point return false.
                Float p = obj as Float;
                if ((System.Object)p == null)
                {
                    return false;
                }

                // Return true if the fields match:
                return (f == p.f);
            }

            public bool Equals(Float p)
            {
                // If parameter is null return false:
                if ((object)p == null)
                {
                    return false;
                }

                // Return true if the fields match:
                return (f == p.f);
            }
            public override int GetHashCode()
            {
                return f.GetHashCode();
            }
        }

        public IShortestPath<State, Action> info;
        public PriorityQueue<float, SearchNode<State, Action>> frontier;
        public HashSet<State> exploredSet;
        public Dictionary<State, SearchNode<State, Action>> frontierMap;

        public ShortestPathGraphSearch(IShortestPath<State, Action> info)
        {
            this.info = info; 
            frontier = new PriorityQueue<float, SearchNode<State, Action>>();
            exploredSet = new HashSet<State>();
            frontierMap = new Dictionary<State, SearchNode<State, Action>>();
        }

        public List<Action> GetShortestPath(State fromState, State toState)
        {
#if UNITY_IPHONE
		PriorityQueue<Float,SearchNode<State,Action>> frontier = new PriorityQueue<Float,SearchNode<State,Action>>();
#else
             frontier = new PriorityQueue<float, SearchNode<State, Action>>();
#endif
            exploredSet = new HashSet<State>();
             frontierMap = new Dictionary<State, SearchNode<State, Action>>();

            SearchNode<State, Action> startNode = new SearchNode<State, Action>(null, 0, 0, fromState, default(Action));
#if UNITY_IPHONE
		frontier.Enqueue(startNode,new Float(0));
#else
            frontier.Enqueue(startNode, 0);
#endif

            frontierMap.Add(fromState, startNode);

            int cycleGuard = 0;

            while (!frontier.IsEmpty)
            {
                /*if (++cycleGuard > 256)
                {
                    Debug.LogFormat("cycleguard = {0}", cycleGuard);
                    return null;
                }*/

                SearchNode<State, Action> node = frontier.Dequeue();
                frontierMap.Remove(node.state);

                if (info.IsToState(node.state, toState))
                {
                    //Debug.LogFormat("cycleguard = {0}", cycleGuard);
                    return BuildSolution(node);
                }
                exploredSet.Add(node.state);
                // dirty hack to prevent jumping overhead
                if (exploredSet.Count > 2048)
                    return null;
                // expand node and add to frontier
                List<Action> exp = info.Expand(node.state);
                for (int i = 0; i < exp.Count; i++)
                {
                    Action action = exp[i];
                    State child = info.ApplyAction(node.state, action);

                    SearchNode<State, Action> frontierNode = null;
                    bool isNodeInFrontier = frontierMap.TryGetValue(child, out frontierNode);
                    if (!exploredSet.Contains(child) && !isNodeInFrontier)
                    {
                        SearchNode<State, Action> searchNode = CreateSearchNode(node, action, child, toState);
#if UNITY_IPHONE
					frontier.Enqueue(searchNode,new Float(searchNode.f));
#else
                        frontier.Enqueue(searchNode, searchNode.f);
#endif
                        frontierMap.Add(child, searchNode);
                    }
                    else if (isNodeInFrontier)
                    {
                        SearchNode<State, Action> searchNode = CreateSearchNode(node, action, child, toState);
                        if (frontierNode.f > searchNode.f)
                        {
#if UNITY_IPHONE
						frontier.Replace(frontierNode,new Float(frontierNode.f), new Float(searchNode.f));
#else
                            frontier.Replace(frontierNode, frontierNode.f, searchNode.f);
#endif
                        }
                    }
                }
            }
            //Debug.LogFormat("cycleguard = {0}", cycleGuard);
            return null;
        }

        private SearchNode<State, Action> CreateSearchNode(SearchNode<State, Action> node, Action action, State child, State toState)
        {
            float cost = info.ActualCost(node.state, action);
            float heuristic = info.Heuristic(child, toState);
            return new SearchNode<State, Action>(node, node.g + cost, node.g + cost + heuristic, child, action);
        }

        private List<Action> BuildSolution(SearchNode<State, Action> seachNode)
        {
            List<Action> list = new List<Action>();
            while (seachNode != null)
            {
                if ((seachNode.action != null) && (!seachNode.action.Equals(default(Action))))
                {
                    list.Insert(0, seachNode.action);
                }
                seachNode = seachNode.parent;
            }
            return list;
        }
    }

    public class SearchNode<State, Action> : IComparable<SearchNode<State, Action>>
    {
        public SearchNode<State, Action> parent;

        public State state;
        public Action action;
        public float g; // cost
        public float f; // estimate

        public SearchNode(SearchNode<State, Action> parent, float g, float f, State state, Action action)
        {
            this.parent = parent;
            this.g = g;
            this.f = f;
            this.state = state;
            this.action = action;
        }

        /// <summary>
        /// Reverse sort order (smallest numbers first)
        /// </summary>
        public int CompareTo(SearchNode<State, Action> other)
        {
            return other.f.CompareTo(f);
        }

        public override string ToString()
        {
            return "SN {f:" + f + ", state: " + state + " action: " + action + "}";
        }
    }
}