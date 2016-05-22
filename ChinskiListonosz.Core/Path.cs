using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public class Path
    {
        public LinkedList<Edge> Edges = new LinkedList<Edge>();
        private int start;
        public int Start
        {
            get { return start; }
            private set { start = value; }
        }

        private int end;
        public int End
        {
            get { return end; }
            private set { end = value; }
        }

        public List<int> VisitedVertices
        {
            get
            {
                return Edges.SelectMany(e => new List<int>() { e.V, e.U }).Distinct().ToList();
            }
        }

        public Path(Edge e, bool reverse = false)
        {
            Edges.AddLast(e);
            if (reverse)
            {
                Start = e.U;
                End = e.V;
            }
            else
            {
                Start = e.V;
                End = e.U;
            }
        }
        public Path(Path p)
        {
            Start = p.Start;
            End = p.End;
            Edges = new LinkedList<Edge>(p.Edges.Select(e => e.Clone()));
        }
        public Path(int startVertex)
        {
            this.Start = startVertex;
            this.End = startVertex;
        }
        public Path(IEnumerable<Edge> edges, int start) : this(start)
        {
            foreach (var e in edges)
                this.AddToEnd(e);
        }
        public Path(IEnumerable<Edge> edges) : this(edges, edges.First().U) { }
        public Path Clone()
        {
            return new Path(this);
        }

        public int Length
        {
            get
            {
                return Edges.Sum(e => e.W);
            }
        }

        public Path AddToEnd(Edge e)
        {
            if (End == e.U)
            {
                Edges.AddLast(e);
                End = e.V;
            }
            else if (End == e.V)
            {
                Edges.AddLast(e);
                End = e.U;
            }
            else
                throw new ArgumentException("The edge is not connecting to the end of the Path");
            return this;
        }
        public Path AddToStart(Edge e)
        {
            if (Start == e.U)
            {
                Edges.AddFirst(e);
                Start = e.V;
            }
            else if (Start == e.V)
            {
                Edges.AddFirst(e);
                Start = e.U;
            }
            else
                throw new ArgumentException("The edge is not connecting to the start of the Path");
            return this;
        }
        public Path InsertAtSuitable(Path path)
        {
            if (path.Start != path.End)
                throw new ArgumentException("Edges to insert create not a valid cycle");

            int commonVertex = path.Start;
            var node = Edges.First;
            if (path.Start == this.Start)
            {
                foreach (var edge in path.Edges)
                    Edges.AddBefore(node, edge);
                return this;
            }

            node = Edges.Find(Edges.First(e => e.IsIncident(commonVertex)));
            if (node == null)
                throw new ArgumentException("Path doesn't have a common element with Edges to insert");

            foreach (var edge in path.Edges) {
                Edges.AddAfter(node, edge);
                node = node.Next;
            }
            return this;
        }

        public bool Connects(int u, int v)
        {
            return (Start == u && End == v) || (Start == v && End == u);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var theOther = obj as Path;

            var sameLength = this.Edges.Count == theOther.Edges.Count;
            List<Edge> compareTo;
            if (Start == theOther.Start && End == theOther.End)
                compareTo = theOther.Edges.ToList();
            else if (Start == theOther.End && End == theOther.Start)
                compareTo = theOther.Edges.Reverse().ToList();
            else
                return false;

            var result = true;
            var edgesList = this.Edges.ToList();
            for (int i = 0; i < Edges.Count; i++)
            {
                if (!edgesList[i].Equals(compareTo[i]))
                    result = false;
            }
            return result;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            return Edges.Count;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(Start.ToString());
            var v = Start;
            foreach (var e in this.Edges)
            {
                var u = e.OtherEndTo(v);
                sb.AppendFormat("->{0}", u);
                v = u;
            }
            return sb.ToString();
        }

    }
}
